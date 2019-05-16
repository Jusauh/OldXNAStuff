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

namespace IppeBeli
{
    class Particle
    {
        public bool alive;
        Vector2 position;
        Vector2 velocity;
        int sprite;
        float angle;
        Texture2D texture;

        public Particle(Vector2 position, Vector2 velosity, int sprite, float angle)
        {
            alive = true;
            this.position = position;
            this.velocity = velosity;
            this.sprite = sprite;
            this.angle = angle;
            this.texture = Assets.shread;

            this.angle = MathHelper.ToRadians(this.angle);
        }

        public void Update()
        {
            position += velocity;

            velocity.X += 0.01f;
            velocity.Y += 0.04f;

            if (position.X >= 820)
                this.alive = false;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture,
                    position,
                    new Rectangle(10 *sprite, 0, 10, texture.Height),
                    Color.White,
                    angle,
                    new Vector2(5, 5),
                    1,
                    SpriteEffects.None,
                    0);
        }
    }
}
