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

namespace WindowsGame1
{
    class Ending
    {
        float angle;
        int timer = 0;

        public void Update()
        {
            

            timer++;
            angle += 0.03f;

        }

        public void Draw(SpriteBatch sb)
        {

            sb.Draw(Assests.hell,
                    new Vector2(400, 230),
                    null,
                    Color.Red,
                    angle,
                    new Vector2(Assests.hell.Width / 2, Assests.hell.Height / 2),
                    1.5f,
                    SpriteEffects.None,
                    0);
            sb.Draw(Assests.hell,
                    new Vector2(400, 230),
                    null,
                    Color.Red,
                    -angle,
                    new Vector2(Assests.hell.Width / 2, Assests.hell.Height / 2),
                    1.5f,
                    SpriteEffects.FlipHorizontally,
                    0);
            if (JvsIMain.player1.alive == true)
            {
                sb.Draw(Assests.jukkaSprite,
                        new Vector2(400, 230),
                        null,
                        Color.White,
                        0,
                        new Vector2(Assests.jukkaSprite.Width / 2, Assests.jukkaSprite.Height / 2),
                        1.5f,
                        SpriteEffects.None,
                        0);
                sb.Draw(Assests.jukkaWon,
                        new Vector2(400, 130),
                        null,
                        Color.Green,
                        0,
                        new Vector2(Assests.jukkaWon.Width / 2, Assests.jukkaWon.Height / 2),
                        1f,
                        SpriteEffects.None,
                        0);
            }
            if (JvsIMain.player2.alive == true)
            {
                sb.Draw(Assests.ippeSprite,
                        new Vector2(400, 230),
                        null,
                        Color.White,
                        0,
                        new Vector2(Assests.ippeSprite.Width / 2, Assests.ippeSprite.Height / 2),
                        1.5f,
                        SpriteEffects.None,
                        0);
                sb.Draw(Assests.ippeWon,
                        new Vector2(400, 130),
                        null,
                        Color.Green,
                        0,
                        new Vector2(Assests.ippeWon.Width / 2, Assests.ippeWon.Height / 2),
                        1f,
                        SpriteEffects.None,
                        0);
            }

        }

    }
}
