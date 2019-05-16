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

namespace Dusk.Player
{
    class Bomb:Methods
    {
        Vector2 position = new Vector2(300,500);
        int frame,timer;
        float scale = 0;
        bool over = false;
        public void Update()
        {
            timer++;
            frame++;
            if (frame >= 30)
            {
                scale += 0.5f;
            }
            if (frame == 40)
            {
                frame = 10;
                scale = 0;
                position.X = Rand(PlayScreenMinX + 100, PlayScreenMaxX - 100);
                position.Y = Rand(PlayScreenMinY + 100, PlayScreenMaxY - 100);
                for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
                {
                    EnemyPrime enemy = Lists.enemyList[i];
                    enemy.GetHitByBomb(100);
                }
                ClearBullets(true);

            }
            if (timer == 220)
            {
                over = true;
            }
        }

        public bool GetOver()
        {
            return over;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Assets.bomb01, position, new Rectangle(0, 0, 256, 256), Color.White, 0, new Vector2(128, 128), scale, SpriteEffects.None, 0);
        }
    }
}
