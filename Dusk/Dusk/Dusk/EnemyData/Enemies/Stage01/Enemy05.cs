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
    class Enemy05 : EnemyPrime
    {
        int frame = -20, frame2;
        float angle, angle2;

        public Enemy05(float fromX,float fromY,float targetX,float targetY)
        {
            SetPosition(fromX, fromY);
            MovePosition01(targetX, targetY,30);
            hitBox02 = 30;
            hitBox01 = 15;
            health = 120;
            bulletDamageRate = 1;
            bombDamageRate = 1;
        }

        public override void Update()
        {
            frame++;
            frame2++;
            if (frame == 60)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        CreateBulletA(GetX(), GetY(), 10, "Blue02");
                        SetBulletDataA(0, 1, 0.02f, 1.5f,angle2, 0, "Blue02");
                        SetBulletDataA(40, 1, 0.02f, 2, angle+angle2, 0, "Blue03");
                        Shoot();
                        angle += 15f;
                    }
                    angle = -15f;
                    angle2 += 360f / 10f;
                }
                frame = 0;
                angle2 = Rand(0, 360);
            }

            if (frame2 >= 400)
            {
                SetAngle(-90);
                SetSpeed(0.7f);
            }
            if(frame2 == 550)
            {
                this.alive = false;
            }
            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(Assets.enemy01, position, new Rectangle(32,0,32,32), Color.White, 0, new Vector2(16,16), 1f, SpriteEffects.None, 0);
        }
        public override void Destroy()
        {
            base.Destroy();
            for (int i = 0; i < 2; i++)
            {
                CreateItem(2, GetRealX(), GetRealY(), Rand(0, 360), 3, -0.2f);
            }

            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, false, 0, 0, 0, 0, 0.5f, 0.1f, 10);
            for (int i = 0; i < 5; i++)
            {
                CreateFX(Assets.fxSheet, new Rectangle(42, 0, 16, 16), new Vector2(8, 8), new Color(255, 255, 255, 120), position, false, Rand(0, 360), 0, Rand(3, 5), 0, 1f, -0.05f, 10);
            }
        }

    }
}
