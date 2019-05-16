using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Labyrinth.Engine
{
    class DrawSys
    {
        // Variables
        static SpriteBatch spriteBatch;

        // Initialization
        public static void InitializeDraw(SpriteBatch sb)
        {
            spriteBatch = sb;
        }

        // Draws given texture to the given position
        public static void Draw(Texture2D tex, Vector2 pos)
        {
            spriteBatch.Draw(tex, pos, Color.White);
        }

        // Draws given texture to the given position with given color
        public static void Draw(Texture2D tex, Vector2 pos, Color col)
        {
            spriteBatch.Draw(tex, pos, col);
        }

        //Playerin piirtoon
        public static void Draw(Texture2D texture, Rectangle textureArea, Vector2 position, float angle)
        {
            Vector2 origin = new Vector2(textureArea.Width / 2, textureArea.Height / 2);
            spriteBatch.Draw(texture,
                position,
                textureArea,
                Color.White,
                angle,
                origin,
                1,
                SpriteEffects.None,
                0);
        }

        // Draws given text to the given position with given color and font
        public static void DrawText(string text, SpriteFont font, Vector2 pos, Color color)
        {
            spriteBatch.DrawString(font, text, pos, color);
        }
    }
}
