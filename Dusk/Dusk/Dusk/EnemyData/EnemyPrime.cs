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

    class EnemyPrime : Methods
    {
        protected Vector2 position,velocity,movementPosition;
        protected float bulletDamageRate, bombDamageRate,health,hitBox01,hitBox02;
        protected float moveSpeed, moveMaxSpeed, moveAcceleration, moveFrame, moveKeyPoint1,moveKeyPoint2,moveAngle;
        protected float maxHealth;
        protected bool boss,alive = true;
        protected int invul,spellTime,spellsLeft,lifeTime;
        protected string spellName;

        protected SFXPlayer sfxPlayer = new SFXPlayer();

        public virtual void Update()
        {
            MovementUpdate();
            spellTime--;
            if (Lists.playerList.Count == 1)
            {
                if (Vector2.Distance(this.position, Lists.playerList[0].GetPosition()) < this.hitBox01 && Lists.playerList[0].GetInvul() == false)
                {
                    Lists.playerList[0].TakeHit();
                }
            }

            if (this.health <= 0 || spellTime == 0)
            {
                Destroy();

                if (boss)
                {
                    for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
                    {
                        EnemyPrime enemy = Lists.enemyList[i];
                        enemy.Destroy();
                    }
                }
            }
        }

        public virtual void Draw(SpriteBatch sb)
        {

        }
        public virtual void BossStatsDraw(SpriteBatch sb)
        {
            if (boss == true)
            {
                sb.DrawString(Assets.font01, "" + spellsLeft, new Vector2(36, 33), Color.Yellow, 0, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0);
                sb.DrawString(Assets.font01, "" + spellTime / 60, new Vector2(500, 33), Color.Yellow, 0, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0);
                sb.DrawString(Assets.font01, spellName, new Vector2(478, 48), Color.Red, 0, new Vector2(spellName.Length*10, 0), 0.8f, SpriteEffects.None, 0);
                sb.Draw(Assets.fxSheet,new Rectangle(72,40,(int)(health/maxHealth*426f),8),new Rectangle(0,8,8,8),Color.White);
                sb.Draw(Assets.fxSheet, new Vector2((int)position.X, PlayScreenMaxY), new Rectangle(58, 0, 32, 16), Color.White, 0, new Vector2(16, 0),1, SpriteEffects.None, 0);
            }
        }


        protected void MovementUpdate()
        {
            moveFrame--;
            invul--;

            if (moveFrame >= 0)
            {
                if (moveFrame == moveKeyPoint1)
                {

                }
                if (moveFrame == moveKeyPoint2)
                {

                }
                if(moveFrame == 0)
                {
                    moveSpeed = 0;
                    position = movementPosition;
                }

            }

            moveSpeed += moveAcceleration;

            velocity = new Vector2(Cos(moveAngle) * moveSpeed, Sin(moveAngle) * moveSpeed);
            position += velocity;

        }
        public virtual void Destroy()
        {
            this.alive = false;
        }

        //Coordinate methods--------------------------------------------------------
        public float GetRealX()
        {
            return position.X;
        }
        public float GetRealY()
        {
            return position.Y;
        }

        protected float GetX()
        {
            return this.position.X - PlayScreenMinX;
        }
        protected float GetY()
        {
            return this.position.Y - PlayScreenMinY;
        }

        //damage------------------------------------------------------------------------
        public void GetHitByBullet(float damage)
        {
            if(invul < 0)
                health -= damage*bulletDamageRate;
        }
        public void GetHitByBomb(float damage)
        {
            if(invul < 0)
                health -= damage * bombDamageRate;
        }
        public void Invul(int duration)
        {
            invul = duration;
        }
        //Get data----------------------------------------------------------------------
        public bool GetAlive()
        {
            return alive;
        }
        public bool GetBoss()
        {
            return boss;
        }
        public float GetHeath()
        {
            return health;
        }
        public float GetHitBox01()
        {
            return hitBox01;
        }
        public float GetHitBox02()
        {
            return hitBox02;
        }
        public float GetAngleToPlayer()
        {
            return GetAngleTo(GetRealX(), GetRealY(), GetPlayerX(), GetPlayerY());
        }
        //Movement -------------------------------------------------------------------------
        public void SetPosition(float positionX, float positionY)
        {
            this.position.X = PlayScreenMinX + positionX;
            this.position.Y = PlayScreenMinY + positionY;
        }
        protected void MovePosition01(float positionX, float positionY, float time)
        {
            positionX += PlayScreenMinX;
            positionY += PlayScreenMinY;

            movementPosition = new Vector2(positionX, positionY);

            moveAngle = GetAngleTo(this.position.X, this.position.Y, positionX, positionY);
            moveSpeed = Vector2.Distance(new Vector2(this.position.X, this.position.Y), new Vector2(positionX, positionY)) / time;
            moveFrame = time;
        }
        protected void MovePosition02(float positonX, float positionY, float maxSpeed, float untillMaxSpeed, float time)
        {

        }
        protected void SetAngle(float angle)
        {
            moveAngle = angle;
        }
        protected void SetSpeed(float speed)
        {
            moveSpeed = speed;
        }
        //Boss related stuff-------------------------------------------------------------------
        public int GetSpellDuration()
        {
            return spellTime;
        }
        public string GetSpellName()
        {
            return spellName;
        }

    }
}
