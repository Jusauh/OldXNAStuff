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

namespace Dusk.EnemyData
{
    class BulletDataStorage
    {
        float speed, acceleration, maxSpeed, accelerationX, accelerationY, maxSpeedX, maxSpeedY, angle, rotation;
        float drawAngle;
        int delay;
        string texture;
        Rectangle crop, delayCrop;
        bool keepSpeed, keepAngle;

        public BulletDataStorage(int delay, float speed, float acceleration, float maxSpeed, float angle, float rotation, string texture)
        {
            this.delay = delay;
            this.speed = speed;
            this.acceleration = acceleration;
            this.maxSpeed = maxSpeed;
            this.angle = MathHelper.ToRadians(angle);
            this.rotation = MathHelper.ToRadians(rotation);
            this.texture = texture;
        }
        public BulletDataStorage(int delay, bool speed, float acceleration, float maxSpeed, float angle, float rotation, string texture)
        {
            this.delay = delay;
            keepSpeed = speed;
            this.acceleration = acceleration;
            this.maxSpeed = maxSpeed;
            this.angle = MathHelper.ToRadians(angle);
            this.rotation = MathHelper.ToRadians(rotation);
            this.texture = texture;
        }
        public BulletDataStorage(int delay, float speed, float acceleration, float maxSpeed, bool angle, float rotation, string texture)
        {
            this.delay = delay;
            this.speed = speed;
            this.acceleration = acceleration;
            this.maxSpeed = maxSpeed;
            keepAngle = angle;
            this.rotation = MathHelper.ToRadians(rotation);
            this.texture = texture;
        }
        public BulletDataStorage(int delay, bool speed, float acceleration, float maxSpeed, bool angle, float rotation, string texture)
        {
            this.delay = delay;
            keepSpeed = speed;
            this.acceleration = acceleration;
            this.maxSpeed = maxSpeed;
            keepAngle = angle;
            this.rotation = MathHelper.ToRadians(rotation);
            this.texture = texture;
        }
        
        public int GetDelay()
        {
            return this.delay;
        }
        public float GetSpeed()
        {
            return this.speed;
        }
        public float GetAcceleration()
        {
            return this.acceleration;
        }
        public float GetMaxSpeed()
        {
            return this.maxSpeed;
        }
        public float GetAngle()
        {
            return this.angle;
        }
        public float GetRotation()
        {
            return this.rotation;
        }
        public string GetTexture()
        {
            return this.texture;
        }
        public bool GetKeepAngle()
        {
            return this.keepAngle;
        }
        public bool GetKeepSpeed()
        {
            return this.keepSpeed;
        }
            
    }
}
