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
using Dusk.EnemyData;

namespace Dusk.EnemyData.Bosses.Boss01
{
    class Pattern01 : EnemyPrime
    {
        int frame,frame2;
        float angle,angle2,angle3, angleMod = 0.6f,rad = 80;

        public Pattern01()
        {
            SetPosition(0, 0);
            MovePosition01(GetCenterX, 100,60);
            frame = -40;
            frame2 = -40;
            hitBox02 = 45;
            hitBox01 = 25;
            health = 2800;
            maxHealth = health;
            spellsLeft = 6;
            bulletDamageRate = 0.7f;
            bombDamageRate = 0.7f;
            boss = true;
            spellTime = 200 * 60;
            spellName = "Zephyrs of the Echo Ridge";
        }

        public override void Update()
        {
            if (frame == 30)
            {
                for (int i = 0; i <7; i++)
                {
                    CreateLazer01(PlayScreenMinX, PlayScreenMinY, 3, angle, 8, 180, 60, "Blue01");
                    CreateLazer01(PlayScreenMaxX - PlayScreenMinX * 2, PlayScreenMinY, 3, -angle, 8, 180, 60, "Blue01");
                    angle += 360f / 7f;
                }
                angle += 5.5f;
                frame = 20;
            }
            if (frame2 == 90)
            {
                frame2 = -50;
                for (int j = 0; j < 15; j++)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        CreateBullet01(GetX(), GetY(), 1, GetAngleToPlayer() + angle2, 40-(j*2), "Red21");
                        angle2 += 360f / 15f;
                    }
                    angle2 += angleMod;
                }
                angle2 = 0;
                angleMod *= -1;
            }
            frame++;
            frame2++;
            //if (frame == 60)
            //{
            //    for (int i = 0; i < 6; i++)
            //    {
            //        for (int j = 0; j < 3; j++)
            //        {
            //            //CreateBullet02(GetCenterX + Cos(angle + angle2) * (rad), 100 + Sin(angle + angle2) * (rad), 3, 0.01f, AngleTo(GetCenterX + Cos(angle + angle2) * (rad), 100 + Sin(angle + angle2) * (rad), GetPlayerX(), GetPlayerY()) + angle2, 0, "Green11");
            //            CreateBullet02(GetX() + Cos(angle) * rad, GetY() + Sin(angle) * rad, 3, -0.01f,-3,angle2, 0,15, "Blue02");

            //            angle2 += 360f/3f;
            //        }
            //        angle2 += 7.5f;
            //        angle += 360f / 6f;
            //    }
            //    rad -= 5.0f;
            //    if (rad < 0)
            //    {
            //        rad = 100;
            //        frame = -60;
            //    }
            //    angle += angleMod;
            //    frame -= 6;
            //    frame2 = 55;
            //}
            //if (frame2 == 65)
            //{
            //    for (int i = 0; i < 60; i++)
            //    {
            //        CreateBullet01(GetX(), GetY(), 0.8f+Rand(0.2f,0.6f), angle3,15, "Cyan12");
            //        angle3 += 360f / 60f;
            //    }
            //    angle3 += Rand(0, 360);
            //    frame2 = -60;
            //}

            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(Assets.boss01, position, new Rectangle(0,0,64,64), Color.White, 0, new Vector2(32,32), 1f, SpriteEffects.None, 0);
        }

        public override void  Destroy()
        {
 	        base.Destroy();
            for (int i = 0; i < 15; i++)
            {
                float rand = Rand(1, 3);
                CreateItem(2, GetRealX(), GetRealY(), Rand(0,360), rand, -rand/15f);
            }

            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, false, 0, 0, 0, 0, 0.5f, 0.1f, 30);
            for (int i = 0; i < 15; i++)
            {
                CreateFX(Assets.fxSheet, new Rectangle(42, 0, 16, 16), new Vector2(8, 8), new Color(255, 255, 255, 120), position, false,Rand(0,360), 0, Rand(3,5), 0, 1f, -0.02f, 40);
            }
        }

    }
}
