using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Dusk.Engine;

namespace Dusk.EnemyData.Bosses.Boss01.Familiars
{
    class Familiar03 : EnemyPrime
    {
        int frame, frame2,frame3,delay;
        new float mAngle,mAngleMod,angle,rotation, drawRotation,distance,distanceMod,posX,posY;

        public Familiar03(float angle,float rotation, float distance)
        {
            SetPosition(GetCenterX + Cos(angle)*distance, GetCenterY+Sin(angle)*distance);
            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(8, 8), new Color(255, 255, 255, 120), position, false, 0, 0, 0, 0, 1f, 0.2f, 5);
            hitBox02 = 0;
            health = 10;
            bulletDamageRate = 0;
            bombDamageRate = 0;
            this.distance = distance;
            this.rotation = rotation;
            this.angle = angle;

        }

        public override void Update()
        {
            frame++;
            frame2++;
            angle += rotation;
            SetPosition(GetCenterX + Cos(angle) * distance, GetCenterY + Sin(angle) * distance);
            if (frame == 60 )
            {
                CreateBulletA(GetX(), GetY(), 3, "Green12");
                SetBulletDataA(0, 1, 0, 0, angle, 0, "Green13");
                SetBulletLife(40);
                Shoot();
                CreateBulletA(GetX(), GetY(), 3, "Cyan12");
                SetBulletDataA(0, 1, 0, 0, angle + 180, 0, "Cyan13");
                SetBulletLife(40);
                Shoot();
                if (rotation > 0)
                    rotation += 0.00022f;
                else
                    rotation -= 0.00022f;
                frame = 58;
            }

            if (frame2 == 170)
            {
                CreateBullet01(GetX(), GetY(), 1, GetAngleToPlayer(), 5, "Yellow13");
                frame2 = delay;
                delay += 2;
            }

            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            drawRotation += Rand(0.01f, 0.04f);
            sb.Draw(Assets.familiar01, position, new Rectangle(0, 0, Assets.familiar01.Width, Assets.familiar01.Height), Color.White, drawRotation, new Vector2(Assets.familiar01.Width / 2, Assets.familiar01.Height / 2), 0.7f, SpriteEffects.None, 0);

        }
    }
}