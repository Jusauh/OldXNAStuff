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
    class Effect
    {
        public bool alive = true;
        public int lifetime;
        public Vector2 position;
        public Vector2 velosity;
        public Vector2 acceleration;
        public float angle;
        public float rotation;
        public float rotationacceleration;
        public float scale;
        public float scaleMod;
        public Color color;
        public float bluemod;
        public float redmod;
        public float greenmod;
        public float alphamod;
        public Texture2D sprite;

        public Effect(Texture2D sprite, Vector2 position, Vector2 velosity, Vector2 acceleration,float angle, float rotation,float rotationecceleration, Color color, float bluemod, float redmod, float greenmod, float alphamod, int lifetime, float scale, float scaleMod)
        {
            this.lifetime = lifetime;
            this.sprite = sprite;
            this.position = position;
            this.acceleration = acceleration;
            this.angle = angle;
            this.rotationacceleration = rotationecceleration;
            this.rotation = rotation;
            this.scale = scale;
            this.scaleMod = scaleMod;
            this.color = color;
            this.bluemod = bluemod;
            this.redmod = redmod;
            this.greenmod = greenmod;
            this.alphamod = alphamod;
        }

        public void Update()
        {
            position += velosity;
            velosity += acceleration;
            angle += rotation;
            scale += scaleMod;
            rotation += rotationacceleration;
            color.R += (byte)redmod;
            color.B += (byte)bluemod;
            color.G += (byte)greenmod;
            color.A += (byte)alphamod;
            lifetime--;
            if (lifetime <= 0)
                this.alive = false;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite,
                    position,
                    null,
                    color,
                    angle,
                    new Vector2(sprite.Width / 2, sprite.Height / 2),
                    scale,
                    SpriteEffects.None,
                    0);
        }
    }
}
