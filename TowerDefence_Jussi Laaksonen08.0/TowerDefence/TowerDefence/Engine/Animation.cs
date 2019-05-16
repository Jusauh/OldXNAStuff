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

namespace TowerDefence.Engine
{
    class Animation
    {
        public int idleAnimationSpeed;
        public int idleAnimationFrames;

        public int animationSpeed;
        public int animationDuration;
        public int animationFrames;

        private int frame;
        private int currentAnimationFrame;

        private float angle;
        bool isStatic;

        public Rectangle textureArea, baseTextureArea;
        public Texture2D sprite;
        public Vector2 origin;

        public Animation(Texture2D sprite, Vector2 origin)
        {
            isStatic = true;
            this.origin = origin;
            this.sprite = sprite;
        }

        public Animation(Texture2D sprite, Rectangle spriteArea, int speed, int frames)
        {
            this.sprite = sprite;
            this.textureArea = spriteArea;
            this.baseTextureArea = spriteArea;
            this.idleAnimationSpeed = speed;
            this.idleAnimationFrames = frames;
            origin = new Vector2(textureArea.Width / 2, textureArea.Height / 2);
            isStatic = false;
        }

        public void Update()
        {
            frame--;

            if (animationDuration < 0)
            {
                if (frame <= 0 && isStatic == false)
                {
                    textureArea.X += textureArea.Width;
                    currentAnimationFrame += 1;
                    if (currentAnimationFrame == idleAnimationFrames)
                    {
                        currentAnimationFrame = 0;
                        textureArea = baseTextureArea;
                    }
                    frame = idleAnimationSpeed;
                }
            }
            else
            {
                if (frame <= 0)
                {
                    animationDuration--;
                    textureArea.X += textureArea.Width;
                    currentAnimationFrame += 1;
                    frame = animationSpeed;
                }
                if (currentAnimationFrame == animationFrames)
                {
                    currentAnimationFrame = 0;
                    textureArea = baseTextureArea;
                    frame = idleAnimationSpeed;
                }
            }
        }
 
        public void Draw(SpriteBatch sb,Vector2 position, float angle)
        {
            origin = new Vector2(textureArea.Width / 2, textureArea.Height / 2);
            sb.Draw(sprite,
                position,
                textureArea,
                Color.White,
                MathHelper.ToRadians(angle),
                origin,
                1,
                SpriteEffects.None,
                0);
        }

        public void BeginAnimation(Rectangle startRectangle,float angle, int animationSpeed, int animationFrames)
        {
            this.angle = angle;
            currentAnimationFrame = 0;
            frame = 0;
            textureArea = startRectangle;
            animationDuration = animationFrames;
            this.animationFrames = animationFrames;
            this.animationSpeed = animationSpeed;
        }

    }
}
