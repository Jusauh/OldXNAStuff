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
using Dusk.EnemyData.Bosses.Boss01.Familiars;

namespace Dusk.EnemyData.Bosses.Boss01
{
    class Pattern04 : EnemyPrime
    {
        int frame = -40, frame2 = -40,type;
        float angle;

        public Pattern04(Vector2 position)
        {
            this.position = position;
            MovePosition01(GetCenterX, 140, 20);
            type = 1;
            frame = 0;
            hitBox02 = 45;
            hitBox01 = 25;
            health = 2400;
            maxHealth = health;
            spellsLeft = 3;
            bulletDamageRate = 0.7f;
            bombDamageRate = 0.7f;
            boss = true;
            spellTime = 60 * 60;
            spellName = "Dawn of Dusk";
        }

        public override void Update()
        {

            frame2++;
            frame++;
            if (frame == 360f/5f)
            {
                for (int i = 0; i < 9; i++)
                {
                    CreateEnemy(new Familiar01(GetX(), GetY(), GetAngleToPlayer()+angle, 12.5f, 2));
                    CreateEnemy(new Familiar01(GetX(), GetY(), GetAngleToPlayer() + angle+ (360f/36f), 12.5f, 1));
                    CreateEnemy(new Familiar01(GetX(), GetY(), GetAngleToPlayer() + angle + (360f/36f)*2, 12.5f, 3));  
                    angle += 360f / 7f;
                }
                angle = Rand(0, 360);
                frame = -60;
                if (type == 1)
                    type = 2;
                else
                    type = 1;
                CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, false, 0, 0, 0, 0, 5f, -1f, 5);  
            }
            //if (frame2 == 500 || frame2 == 600 || frame2 == 700 || frame2 == 800)
            //{
            //    x = GetX();
            //    y = GetY();
            //    angle = GetAngleToPlayer() - 90;
            //    for (int j = 60; j > 0; j--)
            //    {
            //        for (int i = 0; i < 2; i++)
            //        {
            //            CreateBulletA(x + Cos(angle), y + Sin(angle), 70 - j, "Yellow12");
            //            SetBulletDataA(0, 3, 0, 0, angle, 0, "Yello12");
            //            SetBulletDataA(10, 0, 0, 0, true, 0, "Yellow12");
            //            SetBulletDataA(60, 0, 0.05f, 2, Rand(0, 360), 0, "Yellow12");
            //            Shoot();
            //            angle += 360f / 2f;

            //        }
            //        angle += 50.3f;
            //        x += Cos(GetAngleToPlayer()) * 8;
            //        y += Sin(GetAngleToPlayer()) * 8;
            //    }
            //    frame = -200;
            //    if (frame2 == 800)
            //        frame2 = -200;
            //}


            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(Assets.boss01, position, new Rectangle(0, 0, 64, 64), Color.White, 0, new Vector2(32, 32), 1f, SpriteEffects.None, 0);
        }

        public override void Destroy()
        {
            base.Destroy();
            for (int i = 0; i < 15; i++)
            {
                float rand = Rand(1, 3);
                CreateItem(2, GetRealX(), GetRealY(), Rand(0, 360), rand, -rand / 15f);
            }

            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, false, 0, 0, 0, 0, 0.5f, 0.1f, 30);
            for (int i = 0; i < 15; i++)
            {
                CreateFX(Assets.fxSheet, new Rectangle(42, 0, 16, 16), new Vector2(8, 8), new Color(255, 255, 255, 120), position, false, Rand(0, 360), 0, Rand(3, 5), 0, 1f, -0.02f, 40);
            }
        }

    }
}

