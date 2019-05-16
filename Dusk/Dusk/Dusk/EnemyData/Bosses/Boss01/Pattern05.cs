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
    class Pattern05 : EnemyPrime
    {
        int frame = -40, frame2 = -40,type,delay;
        float xPos,yPos,distance,distanceMod,angle, angle2 = 90, angleMod = 1.5f;

        public Pattern05(Vector2 position)
        {
            this.position = position;
            MovePosition01(GetCenterX, 140, 20);
            type = 1;
            frame = 0;
            distance = 0;
            distanceMod = 10f;
            hitBox02 = 45;
            hitBox01 = 25;
            health = 2800;
            maxHealth = health;
            spellsLeft = 2;
            bulletDamageRate = 0.7f;
            bombDamageRate = 0.7f;
            boss = true;
            spellTime = 60 * 60;
            spellName = "Enimga current";
        }

        public override void Update()
        {

            frame2++;
            frame++;
            if (frame == 90)
            {
                angle = 0;
                for (int i = 0; i < 12; i++)
                {
                    //CreateBullet01(GetX() - 140, GetY(), 5, angle + angle2, 15, "Purple12");
                    //CreateBullet01(GetX() + 140, GetY(), 5, -angle + angle2, 15, "Purple12");
                    CreateBullet01(GetX() +Cos(angle2+90) * 140, GetY() + Sin(angle2+90) *140, 5f, angle + angle2, 15, "Purple12");
                    CreateBullet01(GetX() + Cos(angle2-90) * 140, GetY() + Sin(angle2-90) * 140, 5f, -angle + angle2, 15, "Purple12");
                    angle += 20;
                }
                angle2 += angleMod;
                if (angle2 <= 90)
                    angleMod += 0.04f;
                if (angle2 > 90)
                    angleMod -= 0.04f;
                frame = 88;
            }
            if (frame2 == 120)
            {
                xPos =GetX()+Cos(angle2-90)*distance;
                yPos=GetY()+Sin(angle2-90)*distance;
                for(int i = 0; i < 2; i++)
                {
                    CreateBullet01(xPos, yPos, 2.3f, GetAngleTo(xPos, yPos, GetPlayerX() - PlayScreenMinX, GetPlayerY() - PlayScreenMinY), 10, "Red21");
                    distance += distanceMod;
                }

                

                frame2 = 119;
                if (distance > 140 || distance < -140)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        CreateBullet02(xPos, yPos, Rand(2,7), -0.15f, 1, Rand(0, 360), 0, 10, "Purple21");
                    }
                    distanceMod *= -1;
                    frame2 = 60;
                }


            }
     


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

            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, true, 0, 0, 0, 0, 0.5f, 1f, 20);
            for (int i = 0; i < 15; i++)
            {
                CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(8, 8), new Color(255, 255, 255, 120), position, true, Rand(0, 360), 0, Rand(3, 5), 0, 1f, -0.01f, 20);
            }
        }

    }
}

