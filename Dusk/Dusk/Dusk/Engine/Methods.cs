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
using Dusk.EnemyData;
using Dusk.Game;


namespace Dusk.Engine
{
    class Methods : Numbers
    {
        Random rand = new Random();
        
        


        //Bullet methods----------------------------------------------------------------------------------------------------------------------------------------------------------------

        protected void SetBulletBoundry(int minX, int maxX, int minY, int maxY)
        {
            BulletBoundryMaxX = maxX;
            BulletBoundryMinX = minX;
            BulletBoundryMaxY = maxY;
            BulletBoundryMinY = minY;
            
        }

        protected void CreateBullet01(float positionX, float positionY, float speed, float angle,int delay, string bullet)
        {
            Lists.bulletList.Add(new Bullet(positionX, positionY, speed, angle,delay,bullet));
        }
        protected void CreateLazer01(float positionX, float positionY, float speed, float angle, float width, float length, int delay, string bullet)
        {
            Lists.bulletList.Add(new Bullet(positionX,positionY,speed,angle,length,width,delay,bullet));
        }
        protected void CreateBullet02(float positionX, float positionY, float speed, float acceleration,float maxSpeed, float angle, float turn,int delay, string bullet)
        {
            Lists.bulletList.Add(new Bullet(positionX,positionY,speed,acceleration,maxSpeed,angle,turn,delay,bullet));
        }
        protected void CreateBulletXY(float positionX, float positionY, float Xspeed, float Xacceleration, float XMaxSpeed, float Yspeed, float Yacceleration, float YmaxSpeed, int delay, string bullet)
        {
            Lists.bulletList.Add(new Bullet(positionX,positionY,Xspeed,Xacceleration,XMaxSpeed,Yspeed,Yacceleration,YmaxSpeed,delay,bullet));
        }
        protected void CreateBulletA(float positionX, float positionY, int delay, string texture)
        {
            Lists.bulletTemp.Add(new Bullet(positionX,positionY,delay,texture));
        }
        protected void SetBulletDataA(int delay,float speed, float acceleration, float maxSpeed, float angle,float rotation,string texture)
        {
            Lists.bulletTemp[0].SetBulletData(delay, speed, acceleration, maxSpeed, angle, rotation, texture);
        }
        protected void SetBulletDataA(int delay,bool speed,float acceleration, float maxSpeed, float angle, float rotation,string texture)
        {
            Lists.bulletTemp[0].SetBulletData(delay, speed, acceleration, maxSpeed, angle, rotation, texture);
        }
        protected void SetBulletDataA(int delay, float speed, float acceleration, float maxSpeed, bool angle, float rotation, string texture)
        {
            Lists.bulletTemp[0].SetBulletData(delay, speed, acceleration, maxSpeed, angle, rotation, texture);
        }
        protected void SetBulletDataA(int delay, bool speed, float acceleration, float maxSpeed, bool angle, float rotation, string texture)
        {
            Lists.bulletTemp[0].SetBulletData(delay, speed, acceleration, maxSpeed, angle, rotation, texture);
        }
        protected void SetBulletLife(int lifeTime)
        {
            Lists.bulletTemp[0].SetLifeTime(lifeTime);
        }
        protected void ClearBullets(bool turnIntoItems)
        {
            for (int i = Lists.bulletList.Count - 1; i >= 0; i--)
            {
                Bullet bullet = Lists.bulletList[i];
                bullet.Destroy(turnIntoItems);
            }
        }

        protected void Shoot()
        {
            Lists.bulletList.Add(Lists.bulletTemp[0]);
            Lists.bulletTemp.Clear();
        }


        protected void CreatePlayerBullet(float positionX, float positionY, float speed,float acceleration, float angle,float rotationSpeed, Rectangle crop)
        {
            Lists.playerBulletList.Add(new Player.PlayerBullet(positionX,positionY,angle,rotationSpeed,speed,acceleration,6,crop));
        }

        //Math and numbers--------------------------------------------------------------------------------------------------------------------------------------------------------------
        protected float Rand(float minValue, float maxValue)
        {
            return minValue+(float)(rand.NextDouble()*(maxValue-minValue));
        }

        protected float GetAngleTo(float fromX, float fromY, float targetX, float targetY)
        {
            double angle = Math.Atan2(targetY - fromY, targetX - fromX);
            return MathHelper.ToDegrees((float)angle);
        }

        protected float Cos(float angle)
        {
            angle = MathHelper.ToRadians(angle);
            return (float)Math.Cos(angle);
        }

        protected float Sin(float angle)
        {
            angle = MathHelper.ToRadians(angle);
            return (float)Math.Sin(angle);
        }
        //Player Stuff-----------------------------------------------
        protected float GetPlayerX()
        {
            if (Lists.playerList.Count == 1)
                return Lists.playerList[0].GetPosition().X;
            else
                return GameStats.playerPosition.X;
        }

        protected float GetPlayerY()
        {
            if (Lists.playerList.Count == 1)
                return Lists.playerList[0].GetPosition().Y;
            else
                return GameStats.playerPosition.Y;
        }

        protected bool GetPlayerFocus()
        {
            if (Lists.playerList.Count == 1)
                return Lists.playerList[0].GetFocused();
            else
                return false;
        }
        //EnemyStuff...................................
        protected void CreateEnemy(EnemyPrime enemy)
        {
            Lists.enemyList.Add(enemy);
        }
        protected void CreateItem(int item,float posX,float posY, float angle, float speed, float speedMod)
        {
            Lists.itemList.Add(new Items.ItemPrime(item,posX,posY,angle,speed,speedMod));
        }
        //Effect Stuff--------------------------------------------------------------
        protected void CreateFX(Texture2D texture, Rectangle crop, Vector2 origin, Color color, Vector2 position, bool additive, float angle, float rotation, float speed, float acceleration, float scale, float scaleMod, int lifetime)
        {
            Lists.FXList.Add(new FX(texture, crop, origin, color, position, additive, angle, rotation, speed, acceleration, scale, scaleMod, lifetime));
        }
        
    }
}
