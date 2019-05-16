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
using Dusk.Engine;
using Dusk.Game;

namespace Dusk.Items
{
    class ItemPrime : Methods
    {
        enum ItemType {scoreBig,scoreSmall,lightBig,lightSmall,darkBig,darkSmall,extraLife,scoreTiny};
        ItemType itemType = new ItemType();

        Vector2 position,velocity;
        Rectangle crop;
        float angle,speed,speedMod;
        bool moveTowardsPlayer,alive=true,playerAlive;

        int xReflect = 1;

        public ItemPrime(int item,float positionX,float positionY,float angle, float speed,float speedMod)
        {
            this.angle = MathHelper.ToRadians(angle);
            this.speed = speed;
            this.speedMod = speedMod;
            this.position = new Vector2(positionX, positionY);
            playerAlive = true;

            if (item == 1)
            {
                this.itemType = ItemType.scoreBig;
                this.crop = new Rectangle(0, 0, 16, 16);
            }
            else if (item == 2)
            {
                this.itemType = ItemType.scoreSmall;
                this.crop = new Rectangle(16, 0, 8, 8);
            }
            else if (item == 3)
            {
                this.itemType = ItemType.darkBig;
                this.crop = new Rectangle(24, 0, 16, 16);
            }
            else if (item == 4)
            {
                this.itemType = ItemType.darkSmall;
                this.crop = new Rectangle(56, 8, 8, 8);
            }
            else if (item == 5)
            {
                this.itemType = ItemType.lightBig;
                this.crop = new Rectangle(40, 0, 16, 16);
            }
            else if (item == 6)
            {
                this.itemType = ItemType.lightSmall;
                this.crop = new Rectangle(56, 0, 8, 8);
            }
            else if (item == 7)
            {
                this.itemType = ItemType.extraLife;
                this.crop = new Rectangle(72, 0, 16, 16);
            }
            else if (item == 8)
            {
                this.itemType = ItemType.scoreTiny;
                this.crop = new Rectangle(16, 8, 8, 8);
            }
        }

        public void Update()
        {
            speed += speedMod;

            if (Lists.playerList.Count == 1)
            {
                if (speed < 0)
                {
                    speed = 0;
                    speedMod = 0.05f;
                    angle = MathHelper.ToRadians(90);
                    if (itemType == ItemType.lightSmall || itemType == ItemType.darkSmall)
                    {
                        moveTowardsPlayer = true;
                        speed = 4;
                    }
                    if (itemType == ItemType.scoreTiny)
                    {
                        moveTowardsPlayer = true;
                        speed = 10;
                    }
                }
                if (speed > 2 && speedMod > 0 && !moveTowardsPlayer)
                {
                    speed = 2;
                }
                if (Vector2.Distance(position, new Vector2(GetPlayerX(), GetPlayerY())) < 60)
                {
                    moveTowardsPlayer = true;
                    speed = 10;
                    speedMod = 1;
                }
                if (GetPlayerY() < 200)
                {
                    moveTowardsPlayer = true;
                    speed = 10;
                    speedMod = 1;
                }
                if (Vector2.Distance(position, new Vector2(GetPlayerX(), GetPlayerY())) < 6)
                {
                    GetGathered();
                }

                if (moveTowardsPlayer)
                {
                    angle = MathHelper.ToRadians(GetAngleTo(position.X, position.Y, GetPlayerX(), GetPlayerY()));
                    xReflect = 1;
                }
                playerAlive = true;
            }
            else
            {
                if (playerAlive == true)
                {
                    speed = 0;
                    speedMod = 0.05f;
                    angle = MathHelper.ToRadians(90);
                    playerAlive = false;
                    moveTowardsPlayer = false;
                }
                if (speed > 2)
                    speed = 2;
            }

            velocity = new Vector2(((float)Math.Cos(angle) * speed)*xReflect, (float)Math.Sin(angle) * speed);
            position += velocity;

            CheckBoundries();


        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Assets.itemSheet, position,crop, Color.White, 0, new Vector2(crop.Width/2, crop.Height/2), 1f, SpriteEffects.None, 0);
        }

        public void GetGathered()
        {
            if (itemType == ItemType.scoreTiny)
            {
                GameStats.AddScore(1, 5);
            }
            if (itemType == ItemType.scoreSmall)
            {
                GameStats.AddScore(1, 100);
            }
            else if (itemType == ItemType.scoreBig)
            {
                GameStats.AddScore(1, 2000);
            }
            else if (itemType == ItemType.darkSmall)
            {
                GameStats.AddScore(3, 2);
            }
            else if (itemType == ItemType.darkBig)
            {
                GameStats.AddScore(3, 100);
            }
            else if (itemType == ItemType.lightSmall)
            {
                GameStats.AddScore(4, 2);
            }
            else if (itemType == ItemType.lightBig)
            {
                GameStats.AddScore(4, 100);
            }

            this.alive = false;
        }
        public bool GetAlive()
        {
            return alive;
        }
        private void CheckBoundries()
        {
            if (position.X < PlayScreenMinX || position.X > PlayScreenMaxX)
            {
                xReflect = -1;
            }
            if (position.Y > PlayScreenMaxY + 12)
            {
                alive = false;
            }
        }
    }
}
