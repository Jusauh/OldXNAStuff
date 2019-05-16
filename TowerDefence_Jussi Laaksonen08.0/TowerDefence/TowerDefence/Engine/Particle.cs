using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace TowerDefence.Engine
{
    class Particle
    {
        //Partikkelin tarvitsemat muuttujat
        Texture2D texture;
        Vector2 position;
        Vector2 speed;
        Rectangle spriteArea;
        int lifeTime;
        int drawLayer;
        int animationSteps;
        int animationFrame;
        int nextFrameCounter;
        int changeTexture;
        int stayOnScreen;
        float scale;

        public Particle(Texture2D texture, Rectangle spriteArea, Vector2 position, Vector2 speed, float scale, int frames, int lifeTime, int drawLayer, int stayOnScreen, float rand)
        {
            this.texture = texture;
            this.spriteArea = spriteArea;
            this.position = position;
            this.speed = speed;
            this.lifeTime = lifeTime;
            this.drawLayer = drawLayer;
            this.scale = scale;
            animationSteps = frames;
            nextFrameCounter = 0;
            animationFrame = 1;
            changeTexture = lifeTime / animationSteps;
            this.stayOnScreen = (int)((float)stayOnScreen * rand);
        }


        public bool Update()
        {
            lifeTime--;
            position += speed;

            if (animationSteps > animationFrame)
            {
                nextFrameCounter++;
                if (nextFrameCounter % changeTexture == 0)
                {
                    spriteArea.X = spriteArea.X + spriteArea.Width;
                    animationFrame++;
                }
            }
            if (lifeTime <= 0)
            {
                speed.X = 0;
                speed.Y = 0;
                stayOnScreen--;
                drawLayer = 2;
            }

            if (lifeTime > 0)
            {
                return true;
            }
            else if (stayOnScreen > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int drawLayer)
        {
            if (this.drawLayer == drawLayer)
            {
                spriteBatch.Draw(texture, position, spriteArea, Color.White, 0, new Vector2(spriteArea.Width / 2, spriteArea.Height / 2), scale, SpriteEffects.None, 0);
            }
        }
    }
}
