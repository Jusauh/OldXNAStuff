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

namespace Dusk.EnemyData
{
    class Bullet : Methods
    {
        List<BulletDataStorage> dataStorage = new List<BulletDataStorage>();

        Vector2 position,tip, velocity,velocityXY;
        float speed,speedX,speedY,acceleration,maxSpeed,accelerationX,accelerationY,maxSpeedX,maxSpeedY, angle, turn, hitBox,graceHitBox,scale = 1.7f,destroyScale;
        float length,maxLength, width;
        float drawAngle;
        int delay,lifeTime = -1,lazerGraceInterval;
        Rectangle crop,delayCrop,destroyCrop;
        bool additive,graced,alive = true,lazer;

        public Bullet(float positionX, float positionY, int delay, string texture)
        {
            this.position = new Vector2(positionX + PlayScreenMinX, positionY + PlayScreenMinY);
            this.delay = -delay;
            SetData(texture);
        }

        public Bullet(float positionX, float positionY, float speed, float angle,int delay, string texture)
        {
            this.position = new Vector2(positionX+PlayScreenMinX, positionY+PlayScreenMinY);
            this.speed = speed;
            this.angle = MathHelper.ToRadians(angle);
            this.delay = -delay;
            SetData(texture);
        }

        public Bullet(float positionX, float positionY, float speed, float acceleration,float maxSpeed, float angle, float turn,int delay, string texture)
        {
            this.position = new Vector2(positionX + PlayScreenMinX, positionY + PlayScreenMinY);
            this.speed = speed;
            this.acceleration = acceleration;
            this.maxSpeed = maxSpeed;
            this.angle = MathHelper.ToRadians(angle);
            this.turn = MathHelper.ToRadians(turn);
            this.delay = -delay;
            SetData(texture);
        }
        public Bullet(float positionX, float positionY, float velocityX, float accelerationX,float maxSpeedX, float velocityY, float accelerationY,float maxSpeedY, int delay, string texture)
        {
            this.position = new Vector2(positionX + PlayScreenMinX, positionY + PlayScreenMinY);
            this.speedX = velocityX;
            this.speedY = velocityY;
            this.accelerationX = accelerationX;
            this.accelerationY = accelerationY;
            this.maxSpeedX = maxSpeedX;
            this.maxSpeedY = maxSpeedY;
            this.delay = -delay;
            SetData(texture);
        }
        public Bullet(float positionX, float positionY, float speed, float angle, float length, float width,int delay, string texture)
        {
            this.position = new Vector2(positionX + PlayScreenMinX, positionY + PlayScreenMinY);
            this.speed = speed;
            this.angle = MathHelper.ToRadians(angle);
            this.width = width;
            this.maxLength = length;
            this.delay = -delay;
            this.lazer = true;
            SetData(texture);
        }

        public void Update()
        {
            delay++;
            lazerGraceInterval--;

            if (Lists.playerList.Count == 0)
                Destroy(false);

            if (delay > -60)
                scale = (float)-delay/40f;

            if (delay >= 0)
            {
                lifeTime--;

                if (lifeTime == 0)
                    Destroy(false);
                CheckDataStorage();
                //Movement
                angle += turn;
                speed += acceleration;
                speedX += accelerationX;
                speedY += accelerationY;
                if (maxSpeed - Math.Abs(acceleration-0.001) <= speed && maxSpeed + Math.Abs(acceleration+0.001) >= speed)
                    speed = maxSpeed;
                if (maxSpeedX - Math.Abs(accelerationX-0.001) <= speedX && maxSpeedX + Math.Abs(accelerationX+0.001) >= speedX)
                {
                    speedX = maxSpeedX;
                }
                if (maxSpeedY - Math.Abs(accelerationY-0.001) <= speedY && maxSpeedY + Math.Abs(accelerationY+0.001) >= speedY)
                {
                    speedY = maxSpeedY;
                }

                if (!lazer)
                {
                    BulletMovement();
                    BulletHitDetection();
                }
                else
                {
                    LazerMovement();
                    LazerHitDetection();
                }



            }
        }

        private void BulletMovement()
        {
            velocity = new Vector2((float)Math.Cos(angle) * speed, (float)Math.Sin(angle) * speed);
            velocityXY = new Vector2(speedX, speedY);
            position += velocity;
            position += velocityXY;

            if (position.X < PlayScreenMinX - BulletBoundryMinX || position.X > PlayScreenMaxX + BulletBoundryMaxX || position.Y < PlayScreenMinY - BulletBoundryMinY || position.Y > PlayScreenMaxY + BulletBoundryMaxY)
                Destroy(false);
        }
        private void BulletHitDetection()
        {
            graceHitBox = hitBox + 15;
            if (Lists.playerList.Count == 1)
            {
                if (Vector2.Distance(this.position, Lists.playerList[0].GetPosition()) < this.graceHitBox)
                {
                    Grace();
                }
                if (Vector2.Distance(this.position, Lists.playerList[0].GetPosition()) < this.hitBox && Lists.playerList[0].GetInvul() == false)
                {
                    Destroy(false);
                    Lists.playerList[0].TakeHit();
                }
            }
        }
        private void LazerMovement()
        {
            velocity = new Vector2((float)Math.Cos(angle) * speed, (float)Math.Sin(angle) * speed);
            velocityXY = new Vector2(speedX, speedY);
            if (delay == 0)
            {
                int effectDuration = (int)(maxLength / speed);
                CreateFX(Assets.bSheet01, delayCrop, new Vector2(delayCrop.Width / 2, delayCrop.Height / 2), Color.White, position, false, Rand(0, 360),0, 0, 0, 1, -1f/effectDuration, effectDuration);
            }
            if (length < maxLength)
            {
                length += speed;
            }
            else
            {
                length = maxLength;
                position += velocity;
            }

            if ((position.X < PlayScreenMinX - BulletBoundryMinX || position.X > PlayScreenMaxX + BulletBoundryMaxX || position.Y < PlayScreenMinY - BulletBoundryMinY || position.Y > PlayScreenMaxY + BulletBoundryMaxY) &&
                (tip.X < PlayScreenMinX - BulletBoundryMinX || tip.X > PlayScreenMaxX + BulletBoundryMaxX || tip.Y < PlayScreenMinY - BulletBoundryMinY || tip.Y > PlayScreenMaxY + BulletBoundryMaxY))
                Destroy(false);
        }
        private void LazerHitDetection()
        {
            if (Lists.playerList.Count == 1)
            {
                tip = new Vector2(position.X + Cos(MathHelper.ToDegrees(angle)) * length, position.Y + Sin(MathHelper.ToDegrees(angle)) * length);

                //CreateFX(Assets.fxSheet, new Rectangle(0, 0, 8, 8), new Vector2(4, 4), Color.White, new Vector2(position.X, position.Y+width/2), false,0, 0, 0, 0, 1, 0, 2);
                //CreateFX(Assets.fxSheet, new Rectangle(0, 0, 8, 8), new Vector2(4, 4), Color.White, new Vector2(tip.X, tip.Y - width / 2), false, 0, 0, 0, 0, 1, 0, 2);
                if (PlayerDistanceFromLazer(GetPlayerX(), GetPlayerY(), position.X, position.Y + width / 2, tip.X, tip.Y - width / 2) <= (width / 2) - (width / 8)+14 && lazerGraceInterval < 0)
                {
                    Grace();
                    lazerGraceInterval = 7;
                }
                if (PlayerDistanceFromLazer(GetPlayerX(), GetPlayerY(), position.X, position.Y+width/2, tip.X, tip.Y-width/2) <= (width / 2)-(width/12))
                {
                    Lists.playerList[0].TakeHit();
                }
            }
        }
        public void Draw(SpriteBatch sb)
        {
            if (delay >= 0)
            {
                drawAngle = angle + MathHelper.ToRadians((GetAngleTo(0,0,velocityXY.X,velocityXY.Y)));
                if (!lazer)
                    sb.Draw(Assets.bSheet01, position, crop, Color.White, drawAngle, new Vector2(crop.Width / 2, crop.Height / 2), 1f, SpriteEffects.None, 0);
                else
                {
                    sb.Draw(Assets.bSheet01, position, crop, Color.White, drawAngle, new Vector2(0,(crop.Height/2)),new Vector2(length/crop.Width,width/crop.Height), SpriteEffects.None, 0);
                }
            }
            else
            {
                sb.Draw(Assets.bSheet01, position, delayCrop, new Color(225,255,255,255), angle, new Vector2(delayCrop.Width / 2, delayCrop.Height / 2), 0.5f+scale, SpriteEffects.None, 0);
            }
        }

        private void SetData(string texture)
        {
            //32 Ammukset--------------------------------
            if (texture == "Purple01")
            {
                crop = new Rectangle(0, 0, 32, 32);
            }
            else if (texture == "Red01")
            {
                crop = new Rectangle(32, 0, 32, 32);
            }
            else if (texture == "Orange01")
            {
                crop = new Rectangle(64, 0, 32, 32);
            }
            else if (texture == "Yellow01")
            {
                crop = new Rectangle(96, 0, 32, 32);
            }
            else if (texture == "Green01")
            {
                crop = new Rectangle(128, 0, 32, 32);
            }
            else if (texture == "Cyan01")
            {
                crop = new Rectangle(160, 0, 32, 32);
            }
            else if (texture == "Blue01")
            {
                crop = new Rectangle(192, 0, 32, 32);
            }
            else if (texture == "Black01")
            {
                crop = new Rectangle(224, 0, 32, 32);
            }
            //16 Ammukset-------------------------------------
            else if (texture == "Purple02")
            {
                crop = new Rectangle(0, 33, 16, 16);
            }
            else if (texture == "Red02")
            {
                crop = new Rectangle(16, 33, 16, 16);
            }
            else if (texture == "Orange02")
            {
                crop = new Rectangle(32, 33, 16, 16);
            }
            else if (texture == "Yellow02")
            {
                crop = new Rectangle(48, 33, 16, 16);
            }
            else if (texture == "Green02")
            {
                crop = new Rectangle(64, 33, 16, 16);
            }
            else if (texture == "Cyan02")
            {
                crop = new Rectangle(80, 33, 16, 16);
            }
            else if (texture == "Blue02")
            {
                crop = new Rectangle(96, 33, 16, 16);
            }
            else if (texture == "Black02")
            {
                crop = new Rectangle(112, 33, 16, 16);
            }
            //8 Ammukset---------------------------------------
            else if (texture == "Purple03")
            {
                crop = new Rectangle(0, 50, 8, 8);
            }
            else if (texture == "Red03")
            {
                crop = new Rectangle(8, 50, 8, 8);
            }
            else if (texture == "Orange03")
            {
                crop = new Rectangle(16, 50, 8, 8);
            }
            else if (texture == "Yellow03")
            {
                crop = new Rectangle(24, 50, 8, 8);
            }
            else if (texture == "Green03")
            {
                crop = new Rectangle(32, 50, 8, 8);
            }
            else if (texture == "Cyan03")
            {
                crop = new Rectangle(40, 50, 8, 8);
            }
            else if (texture == "Blue03")
            {
                crop = new Rectangle(48, 50, 8, 8);
            }
            else if (texture == "Black03")
            {
                crop = new Rectangle(56, 50, 8, 8);
            }
            //16 tuplat-----------------------------------
            else if (texture == "Purple11")
            {
                crop = new Rectangle(0, 59, 16, 16);
            }
            else if (texture == "Red11")
            {
                crop = new Rectangle(16, 59, 16, 16);
            }
            else if (texture == "Orange11")
            {
                crop = new Rectangle(32, 59, 16, 16);
            }
            else if (texture == "Yellow11")
            {
                crop = new Rectangle(48, 59, 16, 16);
            }
            else if (texture == "Green11")
            {
                crop = new Rectangle(64, 59, 16, 16);
            }
            else if (texture == "Cyan11")
            {
                crop = new Rectangle(80, 59, 16, 16);
            }
            else if (texture == "Blue11")
            {
                crop = new Rectangle(96, 59, 16, 16);
            }
            else if (texture == "Black11")
            {
                crop = new Rectangle(112, 59, 16, 16);
            }
            //16 Timantit----------------------------------
            else if (texture == "Purple12")
            {
                crop = new Rectangle(0, 76, 16, 16);
            }
            else if (texture == "Red12")
            {
                crop = new Rectangle(16, 76, 16, 16);
            }
            else if (texture == "Orange12")
            {
                crop = new Rectangle(32, 76, 16, 16);
            }
            else if (texture == "Yellow12")
            {
                crop = new Rectangle(48, 76, 16, 16);
            }
            else if (texture == "Green12")
            {
                crop = new Rectangle(64, 76, 16, 16);
            }
            else if (texture == "Cyan12")
            {
                crop = new Rectangle(80, 76, 16, 16);
            }
            else if (texture == "Blue12")
            {
                crop = new Rectangle(96, 76, 16, 16);
            }
            else if (texture == "Black12")
            {
                crop = new Rectangle(112, 76, 16, 16);
            }
            // Riisit--------------------------------------
            else if (texture == "Purple13")
            {
                crop = new Rectangle(0, 93, 16, 8);
            }
            else if (texture == "Red13")
            {
                crop = new Rectangle(16, 93, 16, 8);
            }
            else if (texture == "Orange13")
            {
                crop = new Rectangle(32, 93, 16, 8);
            }
            else if (texture == "Yellow13")
            {
                crop = new Rectangle(48, 93, 16, 8);
            }
            else if (texture == "Green13")
            {
                crop = new Rectangle(64, 93, 16, 8);
            }
            else if (texture == "Cyan13")
            {
                crop = new Rectangle(80, 93, 16, 8);
            }
            else if (texture == "Blue13")
            {
                crop = new Rectangle(96, 93, 16, 8);
            }
            else if (texture == "Black13")
            {
                crop = new Rectangle(112, 93, 16, 8);
            }
            //32 Ammukset, hehkuvat--------------------------------
            else if (texture == "Purple21")
            {
                crop = new Rectangle(0, 102, 32, 32);
            }
            else if (texture == "Red21")
            {
                crop = new Rectangle(32, 102, 32, 32);
            }
            else if (texture == "Orange21")
            {
                crop = new Rectangle(64, 102, 32, 32);
            }
            else if (texture == "Yellow21")
            {
                crop = new Rectangle(96, 102, 32, 32);
            }
            else if (texture == "Green21")
            {
                crop = new Rectangle(128, 102, 32, 32);
            }
            else if (texture == "Cyan21")
            {
                crop = new Rectangle(160, 102, 32, 32);
            }
            else if (texture == "Blue21")
            {
                crop = new Rectangle(192, 102, 32, 32);
            }
            else if (texture == "Black21")
            {
                crop = new Rectangle(224, 102, 32, 32);
            }


            //Delay graphics && destroy graphics color
            if (texture == "Purple01" || texture == "Purple02" || texture == "Purple03" || texture == "Purple11" || texture == "Purple12" || texture == "Purple13" || texture == "Purple21")
            {
                delayCrop = new Rectangle(0, 208, 32, 32);
                destroyCrop = new Rectangle(0, 191, 16, 16);
            }
            else if (texture == "Red01" || texture == "Red02" || texture == "Red03" || texture == "Red11" || texture == "Red12" || texture == "Red13" || texture == "Red21")
            {
                delayCrop = new Rectangle(32, 208, 32, 32);
                destroyCrop = new Rectangle(16, 191, 16, 16);
            }
            else if (texture == "Orange01" || texture == "Orange02" || texture == "Orange03" || texture == "Orange11" || texture == "Orange12" || texture == "Orange13" || texture == "Orange21")
            {
                delayCrop = new Rectangle(64, 208, 32, 32);
                destroyCrop = new Rectangle(32, 191, 16, 16);
            }
            else if (texture == "Yellow01" || texture == "Yellow02" || texture == "Yellow03" || texture == "Yellow11" || texture == "Yellow12" || texture == "Yellow13" || texture == "Yellow21")
            {
                delayCrop = new Rectangle(96, 208, 32, 32);
                destroyCrop = new Rectangle(48, 191, 16, 16);
            }
            else if (texture == "Green01" || texture == "Green02" || texture == "Green03" || texture == "Green11" || texture == "Green12" || texture == "Green13" || texture == "Green21")
            {
                delayCrop = new Rectangle(128, 208, 32, 32);
                destroyCrop = new Rectangle(64, 191, 16, 16);
            }
            else if (texture == "Cyan01" || texture == "Cyan02" || texture == "Cyan03" || texture == "Cyan11" || texture == "Cyan12" || texture == "Cyan13"||texture == "Cyan21")
            {
                delayCrop = new Rectangle(160, 208, 32, 32);
                destroyCrop = new Rectangle(80, 191, 16, 16);
            }
            else if (texture == "Blue01" || texture == "Blue02" || texture == "Blue03" || texture == "Blue11" || texture == "Blue12" || texture == "Blue13"||texture == "Blue21")
            {
                delayCrop = new Rectangle(192, 208, 32, 32);
                destroyCrop = new Rectangle(96, 191, 16, 16);
            }
            else if (texture == "Black01" || texture == "Black02" || texture == "Black03" || texture == "Black11" || texture == "Black12" || texture == "Black13" || texture == "Black21")
            {
                delayCrop = new Rectangle(224, 208, 32, 32);
                destroyCrop = new Rectangle(112, 191, 16, 16);
            }

            //Hitbox and destroy graphics size
            if (texture == "Purple01" || texture == "Red01" || texture == "Orange01" || texture == "Yellow01" || texture == "Green01" || texture == "Cyan01" || texture == "Blue01" || texture == "Black01")
            {
                hitBox = 14;
                destroyScale = 1.8f;
                additive = false;
            }
            else if (texture == "Purple02" || texture == "Red02" || texture == "Orange02" || texture == "Yellow02" || texture == "Green02" || texture == "Cyan02" || texture == "Blue02" || texture == "Black02")
            {
                hitBox = 6;
                destroyScale = 0.7f;
                additive = false;
            }
            else if (texture == "Purple03" || texture == "Red03" || texture == "Orange03" || texture == "Yellow03" || texture == "Green03" || texture == "Cyan03" || texture == "Blue03" || texture == "Black03")
            {
                hitBox = 4;
                destroyScale = 0.4f;
                additive = false;
            }
            else if (texture == "Purple11" || texture == "Red11" || texture == "Orange11" || texture == "Yellow11" || texture == "Green11" || texture == "Cyan11" || texture == "Blue11" || texture == "Black11")
            {
                hitBox = 6;
                destroyScale = 0.7f;
                additive = false;
            }
            else if (texture == "Purple12" || texture == "Red12" || texture == "Orange12" || texture == "Yellow12" || texture == "Green12" || texture == "Cyan12" || texture == "Blue12" || texture == "Black12")
            {
                hitBox = 7;
                destroyScale = 0.7f;
                additive = false;
            }
            else if (texture == "Purple13" || texture == "Red13" || texture == "Orange13" || texture == "Yellow13" || texture == "Green13" || texture == "Cyan13" || texture == "Blue13" || texture == "Black13")
            {
                hitBox = 5;
                destroyScale = 0.5f;
                additive = false;
            }
            else if (texture == "Purple21" || texture == "Red21" || texture == "Orange21" || texture == "Yellow21" || texture == "Green21" || texture == "Cyan21" || texture == "Blue21" || texture == "Black21")
            {
                hitBox = 12;
                destroyScale = 1.8f;
                additive = true;
            }
        }


        public void SetBulletData(int delay, float speed, float acceleration, float maxSpeed, float angle, float rotation, string texture)
        {
            dataStorage.Add(new BulletDataStorage(delay, speed, acceleration, maxSpeed, angle, rotation, texture));
        }
        public void SetBulletData(int delay, bool speed, float acceleration, float maxSpeed, float angle, float rotation, string texture)
        {
            dataStorage.Add(new BulletDataStorage(delay, speed, acceleration, maxSpeed, angle, rotation, texture));
        }
        public void SetBulletData(int delay, float speed, float acceleration, float maxSpeed, bool angle, float rotation, string texture)
        {
            dataStorage.Add(new BulletDataStorage(delay, speed, acceleration, maxSpeed, angle, rotation, texture));
        }
        public void SetBulletData(int delay, bool speed, float acceleration, float maxSpeed, bool angle, float rotation, string texture)
        {
            dataStorage.Add(new BulletDataStorage(delay, speed, acceleration, maxSpeed, angle, rotation, texture));
        }

        protected void CheckDataStorage()
        {
            for (int i = dataStorage.Count - 1; i >= 0; i--)
            {
                if (dataStorage[i].GetDelay() == this.delay)
                {
                    if(!dataStorage[i].GetKeepSpeed())
                    this.speed = dataStorage[i].GetSpeed();

                    this.acceleration = dataStorage[i].GetAcceleration();

                    this.maxSpeed = dataStorage[i].GetMaxSpeed();
                    if(!dataStorage[i].GetKeepAngle())
                    this.angle = dataStorage[i].GetAngle();

                    this.turn = dataStorage[i].GetRotation();

                    SetData(dataStorage[i].GetTexture());
                }
            }
        }


        public bool IsAlive()
        {
            return alive;
        }

        public void SetLifeTime(int lifeTime)
        {
            this.lifeTime = lifeTime;
        }

        public void Destroy(bool turnIntoItems)
        {
            if (turnIntoItems == true && !lazer)
            {
                CreateItem(8, position.X, position.Y, 0, 5, -1);
                CreateFX(Assets.bSheet01, destroyCrop, new Vector2(8, 8), Color.White, position, false, Rand(0, 360), Rand(-3, 3), 0, 0, destroyScale, 0.12f, 10);
                alive = false;
            }
            else if (turnIntoItems == false && !lazer)
            {
                alive = false;
                CreateFX(Assets.bSheet01, destroyCrop, new Vector2(8, 8), Color.White, position, false, Rand(0, 360), Rand(-3, 3), 0, 0, destroyScale, 0.12f, 10);
            }
            else if (turnIntoItems == false && lazer)
            {
                int itemAmount = (int)(length / 15);
                for (int i = 0; i < itemAmount; i++)
                {
                    CreateFX(Assets.bSheet01, destroyCrop, new Vector2(8, 8), Color.White, new Vector2(position.X + Cos(MathHelper.ToDegrees(angle)) * i * 15, position.Y + width / 2 + Sin(MathHelper.ToDegrees(angle)) * i * 15), false, Rand(0, 360), Rand(-3, 3), 0, 0, destroyScale, 0.12f, 10);
                }
                alive = false;
            }
            else if (turnIntoItems == true && lazer)
            {
                int itemAmount = (int)(length / 15);
                for (int i = 0; i < itemAmount; i++)
                {
                    CreateFX(Assets.bSheet01, destroyCrop, new Vector2(8, 8), Color.White, new Vector2(position.X + Cos(MathHelper.ToDegrees(angle)) * i * 15, position.Y + width / 2 + Sin(MathHelper.ToDegrees(angle)) * i * 15), false, Rand(0, 360), Rand(-3, 3), 0, 0, destroyScale, 0.12f, 10);
                    CreateItem(8, position.X + Cos(MathHelper.ToDegrees(angle)) * i * 9, position.Y + Sin(MathHelper.ToDegrees(angle)) * i * 9, 0, 5, -1);
                }
                alive = false;
            }
        }

        protected float PlayerDistanceFromLazer(float x, float y, float x1, float y1, float x2, float y2)
        {
            float A = x - x1;
            float B = y - y1;
            float C = x2 - x1;
            float D = y2 - y1;

            float dot = A * C + B * D;
            float len_sq = C * C + D * D;
            float param = dot / len_sq;

            float xx, yy;
            double distance;

            if (param < 0 || (x1 == x2 && y1 == y2))
            {
                xx = x1;
                yy = y1;
            }
            else if (param > 1)
            {
                xx = x2;
                yy = y2;
            }
            else
            {
                xx = x1 + param * C;
                yy = y1 + param * D;
            }

            float dx = x - xx;
            float dy = y - yy;
            distance = Math.Sqrt(dx * dx + dy * dy);
            return (float)distance;

        }

        public void Grace()
        {
            if (!graced && !lazer)
            {
                graced = true;
                if (GetPlayerFocus())
                {
                    CreateFX(Assets.fxSheet, new Rectangle(0, 0, 8, 8), new Vector2(4, 4), Color.White, position, false, GetAngleTo(position.X, position.Y, GetPlayerX(), GetPlayerY()) - 180 + Rand(-40, 40), 0, 3, -0.4f, 1, 0, 15);
                    CreateItem(6, position.X, position.Y, Rand(0, 360), 5, -1);
                }
                else
                {
                    CreateFX(Assets.fxSheet, new Rectangle(0, 0, 8, 8), new Vector2(4, 4), Color.White, position, false, GetAngleTo(position.X, position.Y, GetPlayerX(), GetPlayerY()) - 180 + Rand(-40, 40), 0, 3, -0.4f, 0.3f, 0, 15);
                }
                Game.GameStats.AddScore(2, 1);
            }
            else if(lazer)
            {
                if (GetPlayerFocus())
                {
                    CreateFX(Assets.fxSheet, new Rectangle(0, 0, 8, 8), new Vector2(4, 4), Color.White, new Vector2(GetPlayerX(),GetPlayerY()), false, GetAngleTo(position.X, position.Y, GetPlayerX(), GetPlayerY()) - 180 + Rand(-40, 40), 0, 3, -0.4f, 1, 0, 15);
                    CreateItem(6, GetPlayerX(), GetPlayerY(), Rand(0, 360), 5, -1);
                }
                else
                {
                    CreateFX(Assets.fxSheet, new Rectangle(0, 0, 8, 8), new Vector2(4, 4), Color.White, new Vector2(GetPlayerX(), GetPlayerY()), false, GetAngleTo(position.X, position.Y, GetPlayerX(), GetPlayerY()) - 180 + Rand(-40, 40), 0, 3, -0.4f, 0.3f, 0, 15);
                }
                Game.GameStats.AddScore(2, 1);
            }
        }
        public bool GetAdditiveStatus()
        {
            return additive;
        }
        public bool GetDelay()
        {
            if (delay < 0)
                return true;
            else
                return false;
        }
    }
}
