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
    class Familiar01 : EnemyPrime
    {
        int frame, frame2,type,delay;
        new float angle,angle2, drawRotation;
        string bulletType, bulletType2;

        public Familiar01(float positionX, float positionY,float angle,float speed, int type)
        {
            SetPosition(positionX, positionY);
            hitBox02 = 0;
            health = 10;
            bulletDamageRate = 0;
            bombDamageRate = 1;
            moveSpeed = speed;
            moveAngle = angle;
            angle2 = -0.7f;
            this.type = type;
        }

        public override void Update()
        {
            if (type == 1)
            {
                moveAngle -= 7f;
                angle -= 7;
                bulletType = "Red11";
                bulletType2 = "Red11";
            }
            else if (type == 2)
            {
                moveAngle -= 8.5f;
                angle -= 8.5f;
                bulletType = "Orange11";
                bulletType2 = "Orange11";
            }
            else
            {
                moveAngle -= 10f;
                angle -= 10f;
                bulletType = "Yellow11";
                bulletType2 = "Yellow11";
            }
            if (angle <= -360)
            {
                Destroy();         
            }
            frame++;
            frame2++;
            if (frame == 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    CreateBulletA(GetX(), GetY(),10, bulletType2);
                    SetBulletDataA(0, 0, 0, 0,moveAngle+90, 0, bulletType2);
                    SetBulletDataA(73 - delay, 0, 2f/30f, 2,true, angle2, bulletType);
                    SetBulletDataA(103 - delay, 2, 2f/30f, 2.8f, true, 0, bulletType);
                    Shoot();
                }
                angle2 +=0.35f;
                if (angle2 > 0.7f)
                    angle2 = -0.7f;
                delay += 1;
                frame = 0;
            }

            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            drawRotation += 7f;
            sb.Draw(Assets.familiar01, position, new Rectangle(0, 0, Assets.familiar01.Width, Assets.familiar01.Height), Color.White, drawRotation, new Vector2(Assets.familiar01.Width/2, Assets.familiar01.Height/2), 0.7f, SpriteEffects.None, 0);

        }
    }
}