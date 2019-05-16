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
using Dusk.EnemyData;

namespace Dusk.Player
{
    class PlayerBulletPrime : Methods
    {
        protected Vector2 position,velocity;
        protected Rectangle crop;
        protected float angle, turnSpeed, speed, acceleration,damage;
        protected bool alive = true;
        protected Color color;


        public virtual void Update()
        {
            for (int i = 0; i <= Lists.enemyList.Count - 1; i++)
            {
                EnemyPrime enemy = Lists.enemyList[i];
                if(Vector2.Distance(this.position,new Vector2(enemy.GetRealX(),enemy.GetRealY())) < enemy.GetHitBox02())
                {
                    HitEnemy(i);
                }
            }
            angle += turnSpeed;
            speed += acceleration;
            velocity = new Vector2(Cos(angle) * speed, Sin(angle) * speed);
            position += velocity;

            if (position.X < PlayScreenMinX - 50 || position.X > PlayScreenMaxX + 50 || position.Y < PlayScreenMinY - 50 || position.Y > PlayScreenMaxY + 50)
                Destroy();

            color = new Color(255, 255, 255, 190);
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(Assets.player, position, crop,color,MathHelper.ToRadians( angle+90), new Vector2(crop.Width/2, crop.Height/2), 1.6f, SpriteEffects.None, 0);
        }

        public virtual void HitEnemy(int id)
        {
            Lists.enemyList[id].GetHitByBullet(damage);
            if (Rand(0, 4) < 1 && !GetPlayerFocus())
            {
                CreateItem(4, position.X, position.Y, Rand(0, 360), 5, -1);
            }
            Destroy();
        }

        protected void Destroy()
        {
            CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(120,120,120,120), position, false, 0, 0, 0, 0, 0.5f, 0.1f, 5);
            this.alive = false;
        }

        public bool GetAlive()
        {
            return alive;
        }

    }
}
