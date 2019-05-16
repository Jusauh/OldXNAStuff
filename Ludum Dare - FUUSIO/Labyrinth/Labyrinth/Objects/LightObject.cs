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
using Labyrinth.Engine;
using Labyrinth.Objects;

namespace Labyrinth.Objects
{
    class LightObject
    {
        Vector2 position;
        Rectangle[] nearByWall;
        float alpha;
        float maxDistance, minDistance, distMod;
        Color color;
        Random rand = new Random();

        public LightObject(Vector2 position, List<Tiles> wall)
        {
            maxDistance = 180;

            int temp = 0;
            foreach (Tiles tile in wall)
            {
                if (Vector2.Distance(position, tile.GetCenterPosition()) <= maxDistance)
                {
                    temp += 1;
                }
            }
            nearByWall = new Rectangle[temp];
            temp = 0;
            foreach (Tiles tile in wall)
            {
                if (Vector2.Distance(position, tile.GetCenterPosition()) <= maxDistance)
                {
                    nearByWall[temp] = tile.BoundingBox;
                    temp += 1;
                }
            }
            this.position = position + new Vector2(8, 8);

            color = Color.Black;

        }


        public void UpdateLightIntencity(Vector2 playerPosition)
        {
            playerPosition += new Vector2(16, 16);

            maxDistance = MaxDistance();
            minDistance = MinDistance();

            if (Vector2.Distance(position, playerPosition) >= maxDistance || IsBehindWall(playerPosition))
                alpha = 255;
            else if (Vector2.Distance(position, playerPosition) >= minDistance)
            {
                alpha = (Vector2.Distance(position, playerPosition) - minDistance) / (maxDistance - minDistance) * 255;
            }
            else
            {
                alpha = 0;
            }
            color.A = (byte)alpha;
        }

        public float AngleTo(Vector2 target)
        {
            double angle = Math.Atan2(target.Y - position.Y, target.X - position.X);
            return (float)angle;
        }


        public bool IsBehindWall(Vector2 playerPosition)
        {
            bool value = false;
            //playerPosition += new Vector2(16, 16);
            Vector2 checkPosition;
            for (float distance = 0; distance < Vector2.Distance(position, playerPosition); distance += 10)
            {
                for (int i = nearByWall.Count() - 1; i >= 0; i--)
                {

                    checkPosition = new Vector2((float)(position.X + Math.Cos(AngleTo(playerPosition)) * distance), (float)(position.Y + (Math.Sin(AngleTo(playerPosition)) * distance)));

                    if (Vector2.Distance(checkPosition, position) <= 16)
                        checkPosition = position;

                    if (checkPosition.X > nearByWall[i].Left && checkPosition.X < nearByWall[i].Right && checkPosition.Y > nearByWall[i].Top && checkPosition.Y < nearByWall[i].Bottom)
                    {
                        value = true;
                    }
                }
            }
            return value;
        }
        protected float MinDistance()
        {
            return 70 + distMod;
        }
        protected float MaxDistance()
        {
            return 180 + distMod;
        }
        public float GetMaxDrawDistance()
        {
            return maxDistance;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        public void Draw()
        {
            DrawSys.Draw(Recources.GetTexture("Light"), position - new Vector2(8, 8), color);
        }
    }
}
