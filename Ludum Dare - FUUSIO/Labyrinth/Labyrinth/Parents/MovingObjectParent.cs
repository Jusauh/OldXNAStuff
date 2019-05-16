using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Labyrinth.Engine;
using Labyrinth.Objects;

namespace Labyrinth.Parents
{
    class MovingObjectParent
    {
        // Variables
        protected Vector2 position, speed, direction, lastPosition;
        public Rectangle boundingBox;

        protected float angle;
        public bool alive;
        protected bool aliveOld=true;

        // Constructor
        public MovingObjectParent()
        {
            alive = true;
        }

        // Update Method
        public virtual void Update(float deltaTime, List<Tiles> tiles)
        {
            {
                // Updating positions
                lastPosition = position;
                position += speed * direction * deltaTime;

                boundingBox.X = (int)position.X;
                if (Collision.MapCollision(boundingBox, tiles) || boundingBox.X < Game1.screenSize.X || boundingBox.X + boundingBox.Width > Game1.screenSize.Width)
                {
                    position.X = lastPosition.X;
                    boundingBox.X = (int)position.X;
                }

                boundingBox.Y = (int)position.Y;
                if (Collision.MapCollision(boundingBox, tiles) || boundingBox.Y < Game1.screenSize.Y || boundingBox.Y + boundingBox.Height > Game1.screenSize.Height)
                {
                    position.Y = lastPosition.Y;
                    boundingBox.Y = (int)position.Y;
                }
            }
        }

        // Draw Method
        public void Draw(string objectTextureName)
        {
            DrawSys.Draw(Recources.GetTexture(objectTextureName), position);
        }

        protected bool CanShoot(float shooterAngle, Vector2 shootPosition, Rectangle targetboundingBox, List<Tiles> tiles)
        {
            Rectangle testCollision = new Rectangle((int)shootPosition.X+10, (int)shootPosition.Y+10, 5, 5);

            while (true)
            {
                foreach (Tiles tile in tiles)
                {
                    if (testCollision.Intersects(targetboundingBox))
                    {
                        return true;
                    }
                    else if (testCollision.Intersects(tile.BoundingBox))
                    {
                        return false;
                    }
                }

                testCollision.X += (int)(Math.Cos(shooterAngle) * 26);
                testCollision.Y += (int)(Math.Sin(shooterAngle) * 26);

                if (testCollision.X < Game1.screenSize.X ||
                    testCollision.Y < Game1.screenSize.Y ||
                    testCollision.Width > Game1.screenSize.Width ||
                    testCollision.Height > Game1.screenSize.Height)
                    return false;

            }
        }

        public void Shoot(MovingObjectParent target)
        {
            target.alive = false;
        }

        public float AngleTo(Vector2 target)
        {
            double angle = Math.Atan2(target.Y - position.Y, target.X - position.X);
            return (float)angle;
        }
    }
}
