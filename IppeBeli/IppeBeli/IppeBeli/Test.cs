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
    enum TestType
    {
        Math,
        Biology
    }

    class Test
    {
        public TestType type;

        public bool alive;
        public Vector2 position;
        public float speed;
        Texture2D texture;

        public bool stamped;

        public bool sweeped;

        public bool beingShredded;

        float lifeTimer;

        public Test(TestType type, Vector2 position, float speed)
        {
            this.type = type;
            alive = true;
            this.position = position;
            this.speed = speed;

            if (type == TestType.Math)
                texture = Assets.test;
            else
                texture = Assets.biologyTest;
        }

        public void Sweep()
        {
            sweeped = true;
        }

        public void Stop()
        {
            this.speed = 0.0f;
        }

        public void Update(float gameTime)
        {

            if (position.X > 0)
                lifeTimer += gameTime;

            if (lifeTimer >= 8.0f)
                alive = false;

            if (!sweeped)
            {
                position.X += speed * gameTime;

                if (this.position.X >= 530)
                    this.speed = 150;
                if (this.position.X >= 600)
                    this.alive = false;
            }
            else
            {
                position += new Vector2(0, 600) * gameTime;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture,
                position,
                null,
                Color.White,
                0.0f,
                new Vector2(texture.Width / 2, texture.Height / 2),
                1.0f,
                SpriteEffects.None,
                1);
        }
    }
}
