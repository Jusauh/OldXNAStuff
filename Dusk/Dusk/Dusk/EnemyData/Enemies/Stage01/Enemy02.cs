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

namespace Dusk.EnemyData.Enemies.Stage01
{
    class Enemy02 : EnemyPrime
    {
        int frame, frame2;
        new float angle,speed = 2f;

        public Enemy02(float positionX, float positionY, float endPositionX, float endPositionY)
        {
            SetPosition(positionX, positionY);
            MovePosition01(endPositionX, endPositionY,440);
            frame = (int)Rand(-20, 0);
            hitBox02 = 30;
            hitBox01 = 15;
            health = 100;
            bulletDamageRate = 1;
            bombDamageRate = 1;

        }

        public override void Update()
        {
            
            frame++;
            frame2++;
            if (frame == 60)
            {
                angle = GetAngleTo(GetRealX(), GetRealY(), GetPlayerX(), GetPlayerY());
                for (int i = 0; i < 22; i++)
                {

                    CreateBullet02(GetX() + Cos(angle) * -25, GetY() + Sin(angle) * -25, 0.3f, 0.02f, speed, angle, 0, 7, "Green13");
                    CreateBullet02(GetX() + Cos(angle + (360f / 60f)) * -25, GetY() + Sin(angle + (360f / 44f)) * -25, 0.3f, 0.02f, speed + 0.4f, angle + (360f / 44f), 0, 7, "Cyan13");
                    angle += 360f / 22f;
                }
                frame = 12-(int)Rand(0,20);
            }



            if(frame2 == 440)
                alive = false;

            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(Assets.enemy01, position, new Rectangle(64,0,32,32), Color.White, 0, new Vector2(16,16), 1f, SpriteEffects.None, 0);
        }

        public override void  Destroy()
        {
 	        base.Destroy();
            for (int i = 0; i < 3; i++)
            {
                CreateItem(2, GetRealX(), GetRealY(), Rand(0,360), 3, -0.1f);
            }

            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, false, 0, 0, 0, 0, 0.5f, 0.1f, 10);
            for (int i = 0; i < 5; i++)
            {
                CreateFX(Assets.fxSheet, new Rectangle(42, 0, 16, 16), new Vector2(8, 8), new Color(255, 255, 255, 120), position, false,Rand(0,360), 0, Rand(3,5), 0, 1f, -0.05f, 10);
            }
        }

    }
}
