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
    class Bullet
    {
        public int master;
        public bool alive = true;
        public Vector2 position;
        public Vector2 velosity;
        public Vector2 acceleration;
        public Texture2D sprite;
        Color color;
        Random rand = new Random();

        public Bullet(int master, Vector2 position, Vector2 velosity,Vector2 acceleration, Texture2D sprite)
        {
            this.master = master;
            this.position = position;
            this.velosity = velosity;
            this.acceleration = acceleration;
            this.sprite = sprite;
        }

        public void Update()
        {
            position += velosity;
            velosity += acceleration;



            if (master == 1)
                color = Color.Red;
            if (master == 2)
                color = Color.Blue;

            InGame.fxlist.Add(new Effect(Assests.shot,
                                this.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                0,
                                0.1f,
                                0.01f,
                                color,
                                0f,
                                0f,
                                0f,
                                0f,
                                18,
                                1f+(float)rand.NextDouble()/4,
                                -1f/18));
            InGame.fxlist.Add(new Effect(Assests.shot,
                                this.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                0,
                                0.1f,
                                0.01f,
                                new Color(255,255,255,25),
                                0f,
                                0f,
                                0f,
                                0f,
                                2,
                                1.3f,
                                0));

            if (this.position.X < -200 || this.position.X > 1000 || this.position.Y < -200 || this.position.Y > 800)
                this.alive = false;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite,
                    position,
                    null,
                    color,
                    0,
                    new Vector2(sprite.Width / 2, sprite.Height / 2),
                    1,
                    SpriteEffects.None,
                    0);
        }
    }
}
