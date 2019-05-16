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
    class Familiar02 : EnemyPrime
    {
        int frame, frame2,frame3,delay;
        new float mAngle,mAngleMod,angle,angle2, drawRotation,distance,distanceMod,posX,posY;
        string bulletType, bulletType2;

        public Familiar02(float positionX, float positionY,float angle,float speed, float distance, int delay)
        {
            posX = positionX - PlayScreenMinX;
            if (posX > PlayScreenMaxX - PlayScreenMinX - 160)
                posX = PlayScreenMaxX - PlayScreenMinX - 160;
            if (posX <  + 160)
                posX =  + 160;
            posY = positionY - PlayScreenMinY;
            if (posY > PlayScreenMaxY - PlayScreenMinY - 160)
                posY = PlayScreenMaxY - PlayScreenMinY - 160;
            if (posY <  + 160)
                posY =  + 160;
            SetPosition(posX + Cos(angle)*distance, posY+Sin(angle)*distance);
            hitBox02 = 0;
            health = 10;
            bulletDamageRate = 0;
            bombDamageRate = 0;
            angle2 = -0.7f;
            mAngle = angle;
            mAngleMod = 1.7f;
            this.delay = delay;
            this.distance = distance;
            distanceMod = 0.1f;
            angle = -25;
        }

        public override void Update()
        {
            frame++;
            frame2++;
            frame3++;

            if (frame == 90 )
            {
                for (int i = 0; i < 3; i++)
                {
                    CreateBullet01(GetX(), GetY(), 6, mAngle+angle, 3, "Green12");
                    angle += 25;
                }
                angle = -25;
                frame = 88;
            }

            if (frame2 == 140 + delay && frame3 < 360)
            {
                CreateBullet01(GetX(), GetY(), 1, GetAngleToPlayer(), 1, "Green03");
                frame2 = 100 + delay;
            }

            if (frame3 > 360)
            {
                if (frame3 > 380)
                {
                    CreateBulletA(GetX(), GetY(), 10, "Green02");
                    SetBulletDataA(0, 0, 0, 0, 0, 0, "Green02");
                    SetBulletDataA(90, 0, 0.01f, 1.5f, mAngle - 180, 0, "Green02");
                    SetBulletLife(165+(int)Math.Floor(distance / 1.5f));
                    Shoot();
                }
                if (frame3 == 385)
                {
                    frame3 = 370;
                }
            }
            MovementUpdate();
            base.Update();
        }

        protected void MovementUpdate()
        {
            distance -= distanceMod;
            mAngle += mAngleMod;
            SetPosition(posX + Cos(mAngle) * distance, posY + Sin(mAngle) * distance);
            if (frame3 < 360)
            {
                if (distance > 130)
                {
                    distanceMod += 0.1f;
                }
                else
                {
                    distanceMod = 0;
                    distance = 130;
                }
                if (mAngleMod < 5)
                    mAngleMod += 0.01f;
            }
            else
            {
                if(distanceMod > -10)
                    distanceMod -= 0.1f;
            }
            if (distance > 600)
                Destroy();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            drawRotation += 7f;
            sb.Draw(Assets.familiar01, position, new Rectangle(0, 0, Assets.familiar01.Width, Assets.familiar01.Height), Color.White, drawRotation, new Vector2(Assets.familiar01.Width/2, Assets.familiar01.Height/2), 0.7f, SpriteEffects.None, 0);

        }
    }
}