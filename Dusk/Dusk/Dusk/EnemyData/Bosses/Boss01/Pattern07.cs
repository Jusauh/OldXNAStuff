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
using Dusk.EnemyData.Bosses.Boss01.Familiars;

namespace Dusk.EnemyData.Bosses.Boss01
{
    class Pattern07 : EnemyPrime
    {
        int frame = 0;
        float angle, rad = 0;

        public Pattern07(Vector2 position)
        {
            this.position = position;
            MovePosition01(GetCenterX, 160, 40);
            frame = 0;
            hitBox02 = 45;
            hitBox01 = 25;
            health = 4100;
            maxHealth = health;
            spellsLeft = 0;
            bulletDamageRate = 0.7f;
            bombDamageRate = 0.7f;
            boss = true;
            spellTime = 120 * 60;
            spellName = "Birth of the fifth Sun";
        }

        public override void Update()
        {


            frame++;
            if (frame == 60)
            {
                for (int i = 0; i < 20; i++)
                {
                    angle = Rand(0, 360);
                    CreateBulletA(GetX()+Cos(angle)*rad+Rand(-2,2), GetY()+Sin(angle)*rad+Rand(-2,2), 60, "Red21");
                    SetBulletDataA(0, 0.05f, 0, 0, Rand(0,360), 0, "Red21");
                    SetBulletLife(60);
                    Shoot();
                }
                frame = 59;
                rad += 5;

                if (rad > 500)
                {
                    rad = 0;
                    frame = 40;
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

            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, false, 0, 0, 0, 0, 0.5f, 0.1f, 30);
            for (int i = 0; i < 15; i++)
            {
                CreateFX(Assets.fxSheet, new Rectangle(42, 0, 16, 16), new Vector2(8, 8), new Color(255, 255, 255, 120), position, false, Rand(0, 360), 0, Rand(3, 5), 0, 1f, -0.02f, 40);
            }
        }

    }
}

