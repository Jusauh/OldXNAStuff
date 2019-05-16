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
    class Enemy03 : EnemyPrime
    {
        int frame, frame2,frame3,delay;

        public Enemy03(float targetX,float targetY)
        {
            SetPosition(GetCenterX, -30);
            MovePosition01(targetX, targetY,30);
            hitBox02 = 40;
            hitBox01 = 25;
            health = 600;
            bulletDamageRate = 1;
            bombDamageRate = 1;
        }

        public override void Update()
        {
            frame++;
            frame2++;
            frame3++;
            if (frame == 60)
            {
                CreateBulletXY(GetX(), GetY(), Rand(-1, 1), 0,0 , Rand(-1, -2), Rand(0.02f, 0.03f), 3.5f, 20, "Red02");
                CreateBulletXY(GetX(), GetY(), Rand(-0.7f, 0.7f), 0, 0, Rand(-0.8f, -1.6f), Rand(0.03f, 0.04f), 3f, 20, "Purple13");


                frame = 53;
            }

            if (frame2 == 140)
            {
                for (int i = 0; i < 10; i++)
                {
                    CreateBulletXY(GetX(), GetY(), -0.6f, 0, 0, -2, 0.05f, 5.3f, 10 + delay, "Purple13");
                    CreateBulletXY(GetX(), GetY(), +0.6f, 0, 0, -2, 0.05f, 5.3f, 10 + delay, "Purple13");
                    CreateBulletXY(GetX(), GetY(), -0.8f, 0, 0, -2.3f, 0.06f, 5.3f, 10 + delay, "Purple13");
                    CreateBulletXY(GetX(), GetY(), +0.8f, 0, 0, -2.3f, 0.06f, 5.3f, 10 + delay, "Purple13");
                    delay += 3;
                }
                delay = 0;
                frame2 = 40;
            }

            if (frame3 >= 320)
            {
                SetAngle(-90);
                SetSpeed(0.5f);
            }
            if (frame3 == 550)
            {
                this.alive = false;
            }

            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(Assets.enemy01, position, new Rectangle(0,0,32,32), Color.White, 0, new Vector2(16,16), 1.5f, SpriteEffects.None, 0);
        }
        public override void Destroy()
        {
            base.Destroy();
            for (int i = 0; i < 5; i++)
            {
                CreateItem(2, GetRealX(), GetRealY(), Rand(0, 360), 4, -0.1f);
            }
            CreateItem(1, GetRealX(), GetRealY(), Rand(0, 360), 2, -0.05f);

            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, false, 0, 0, 0, 0, 0.5f, 0.15f, 10);
            for (int i = 0; i < 8; i++)
            {
                CreateFX(Assets.fxSheet, new Rectangle(42, 0, 16, 16), new Vector2(8, 8), new Color(255, 255, 255, 120), position, false, Rand(0, 360), 0, Rand(5, 7), 0, 1f, -0.05f, 10);
            }
        }
    }
}
