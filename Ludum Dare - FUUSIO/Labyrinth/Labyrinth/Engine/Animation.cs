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

namespace Labyrinth.Engine
{
    class Animation
    {
        public float idleAnimationFrameLength;
        public int idleAnimationFrames;

        public float animationSpeed;
        public int animationDuration;
        public int animationFrames;

        private int frame;
        private int currentAnimationFrame;

        private float angle;
        bool isStatic;

        public Rectangle textureArea, baseTextureArea;
        public Texture2D sprite;
        public Vector2 origin;

        float deltaTimeOld = 0;

        public Animation(Texture2D sprite, Vector2 origin)
        {
            isStatic = true;
            this.origin = origin;
            this.sprite = sprite;
        }

        public Animation(Texture2D sprite, Rectangle spriteArea, float frameLength, int frames)
        {
            this.sprite = sprite;
            this.textureArea = spriteArea;
            this.baseTextureArea = spriteArea;
            this.idleAnimationFrameLength = frameLength;
            this.idleAnimationFrames = frames;
            //this.origin = origin;
            isStatic = false;
            currentAnimationFrame = 0;
        }

        public int Update(float deltaTime)
        {
            deltaTimeOld += deltaTime;
            if (deltaTimeOld >= animationSpeed)
            {
                if (currentAnimationFrame < idleAnimationFrames)
                {
                    textureArea.X += textureArea.Width;
                    currentAnimationFrame++;
                }
                else
                {
                    textureArea.X = 0;
                    currentAnimationFrame = 1;
                }
                deltaTimeOld = 0;

            }
            return currentAnimationFrame;
        }

        public void Reset()
        {
            currentAnimationFrame = 1;

        }

        public void Draw(Vector2 position, float angle)
        {
            DrawSys.Draw(sprite, textureArea, new Vector2(position.X + 16, position.Y +16), angle);
        }

        public void BeginAnimation(Rectangle startRectangle, float angle, float animationSpeed, int animationFrames)
        {
            this.angle = angle;
            currentAnimationFrame = 1;
            frame = 0;
            textureArea = startRectangle;
            animationDuration = animationFrames;
            this.animationFrames = animationFrames;
            this.animationSpeed = animationSpeed;
        }

    }
}
