using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefence.Engine
{
    class Font
    {
        SpriteFont spriteFont;

        public string output;

        Vector2 fontPosition;

        Color color;

        float fontRotation;

        public Font(SpriteFont spriteFont, string output, Vector2 fontPosition, Color color, float fontRotation)
        {
            this.spriteFont = spriteFont;
            this.output = output;
            this.fontPosition = fontPosition;
            this.color = color;
            this.fontRotation = fontRotation;
        }

        public void replaceOutput(string newOutput)
        {
            output = newOutput;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, output, fontPosition, color, fontRotation, spriteFont.MeasureString(output) / 2, 1.0f, SpriteEffects.None, 0);
        }
    }
}

