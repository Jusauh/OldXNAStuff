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

namespace Dusk.Game
{
    class GameStats
    {
        public static int score;
        public static int grace;
        public static int darkPoints;
        public static int lightPoints;
        public static Vector2 playerPosition;

        public static void AddScore(int scoreType, int amount)
        {
            if (scoreType == 1)
            {
                score += amount;
            }
            else if (scoreType == 2)
            {
                grace += amount;
            }
            else if (scoreType == 3)
            {
                darkPoints += amount;
                if(darkPoints > 1000)
                    darkPoints = 1000;
            }
            else if (scoreType == 4)
            {
                lightPoints += amount;
                if (lightPoints > 1000)
                    lightPoints = 1000;
            }
        }

        public static void UpdatePlayerPosition()
        {
            playerPosition = Lists.playerList[0].GetPosition();
        }


        public static void Draw(SpriteBatch sb)
        {
            sb.DrawString(Assets.font01, "" + score, new Vector2(570, 100), Color.White, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 0);
            sb.DrawString(Assets.font01, "" + grace, new Vector2(570, 140), Color.Gray, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 0);
            sb.DrawString(Assets.font01, "" + lightPoints, new Vector2(570, 500), Color.LightGray, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
            sb.DrawString(Assets.font01, "" + darkPoints, new Vector2(570, 525), Color.Black, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }

    }
}
