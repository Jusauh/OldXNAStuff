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
    class Enemy04 : EnemyPrime
    {
        int frame, frame2,frame3,delay;
        float angle, angle2 = 50;

        public Enemy04(float targetX,float targetY)
        {
            SetPosition(GetCenterX, -30);
            MovePosition01(targetX, targetY,60);
            hitBox02 = 40;
            hitBox01 = 25;
            health = 2200;
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
                for (int i = 0; i < 10; i++)
                {
                    CreateBulletA(GetX(), GetY(), 10, "Orange03");
                    SetBulletDataA(0, -5, +0.12f, 0, angle, 0, "Orange03");
                    SetBulletDataA(120 - delay, 2, 0, 0, angle+angle2,0, "Orange13");
                    Shoot();
                    CreateBulletA(GetX(), GetY(), 10, "Yellow03");
                    SetBulletDataA(0, -3.8f, 0.1f, 0, -angle, 0, "Yellow03");
                    SetBulletDataA(120 - delay, 2, 0, 0, -angle-angle2, 0, "Yellow13");
                    Shoot();

                    angle += 360f/10f;
                }
                angle += 16.3f;
                angle2 += 6;
                delay += 4;
                frame = 56;
            }

            if (frame2 == 140)
            {
                angle = Rand(0, 360);
                frame = 0;
                delay = 0;
                angle2 = 50;
                frame2 = 00;
            }
            if (frame3 == 720)
            {
                this.alive = false;
            }
            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(Assets.enemy01, position, new Rectangle(32,0,32,32), Color.White, 0, new Vector2(16,16), 1.5f, SpriteEffects.None, 0);
        }
        public override void Destroy()
        {
            base.Destroy();
            for (int i = 0; i < 5; i++)
            {
                CreateItem(2, GetRealX(), GetRealY(), Rand(0, 360), 4, -0.1f);
            }
            for (int i = 0; i < 2; i++)
            {
                CreateItem(1, GetRealX(), GetRealY(), Rand(0, 360), 2, -0.05f);
            }
            CreateItem(3, GetRealX(), GetRealY(), Rand(0, 360), 2, -0.05f);
            CreateItem(5, GetRealX(), GetRealY(), Rand(0, 360), 2, -0.05f);

            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, false, 0, 0, 0, 0, 0.5f, 0.15f, 10);
            for (int i = 0; i < 8; i++)
            {
                CreateFX(Assets.fxSheet, new Rectangle(42, 0, 16, 16), new Vector2(8, 8), new Color(255, 255, 255, 120), position, false, Rand(0, 360), 0, Rand(4, 6), 0, 1f, -0.05f, 10);
            }
        }

    }
}
