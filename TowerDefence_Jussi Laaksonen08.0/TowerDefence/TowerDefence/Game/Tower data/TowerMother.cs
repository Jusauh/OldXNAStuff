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
using TowerDefence.Engine;
using TowerDefence.Game.Enemy_data;

namespace TowerDefence.Game.Tower_data
{
    /// <summary>
    /// Tässä luokassa luodaan kaikille torneille yhteiset ominaisuudet
    /// </summary>
    class TowerMother
    {
        Random rand = new Random();

        public int value;
        public Vector2 position;
        public short level;
        public Texture2D sprite;
        public Animation animation;
        protected float range;
        protected float angle;
        public float damage, damagePoint, AoE;
        public float attackSpeed, attackCheck, attackBase, attackPoint;
        private int targetType = 1;
        protected bool createProjectile;
        protected bool isAlive = true;
        public bool isTargeted;
        protected SoundEffect s1, s2, s3, s4, s5;
        protected SoundEffect u1, u2, u3;

        public int attackAnimationSpeed, attackAnimationFrames;
        public int idleAnimationSpeed, idleAnimationFrames;

        public Rectangle spriteDrawArea;
        protected Enemy target;

        protected void PlaySummonSFX()
        {
            int temp = rand.Next(0, 22);

            if (temp >= 21)
                s5.Play();
            else if (temp >= 15)
                s4.Play();
            else if (temp >= 10)
                s3.Play();
            else if (temp >= 5)
                s2.Play();
            else
                s1.Play();
        }

        protected void PlayUpgradeSFX()
        {
            int temp = rand.Next(0, 15);

            if (temp >= 10)
                u3.Play();
            else if (temp >= 5)
                u2.Play();
            else
                u1.Play();
        }

        /// <summary>
        /// Päivittää kaikien tornien yhteistä logiikkaa
        /// </summary>
        public virtual void Update()
        {
            attackCheck--;
            createProjectile = false;
            if (Input.MouseLeftPressed() && Input.MousePosition().X < 600)
            {
                isTargeted = CheckTargeted();
            }
            CheckAttackTarget();
            Attack();

            if (isTargeted)
            {
                TargetUpdate();
            }

            if (attackSpeed < attackAnimationFrames * attackAnimationSpeed) // Tällä nopeutetaan hyökkäysanimaatiota kun atttackspeed on tarpeeksi
            {
                attackAnimationSpeed = (int)Math.Floor(attackSpeed / attackAnimationFrames);
            }

            animation.Update();
        }
        /// <summary>
        /// Kaikille torneille yhteinenen piirto
        /// </summary>
        public virtual void Draw(SpriteBatch sb)
        {
            //animation.Draw(sb, position, angle);

            if (Input.CursorOverArea(new Rectangle((int)position.X - spriteDrawArea.Width / 2, (int)position.Y - spriteDrawArea.Height / 2, spriteDrawArea.Width, spriteDrawArea.Height)) && Input.IsKeyDown(Keys.LeftShift) || isTargeted)
            {
                sb.Draw(Assests.rangeIndicator,
                    position,
                    null,
                    Color.White,
                    0,
                    new Vector2(Assests.rangeIndicator.Width / 2, Assests.rangeIndicator.Height / 2),
                    1f * (range / 50),
                    SpriteEffects.None, 0);
            }

        }

        protected void CheckAttackTarget()
        {
            int temp = -1;
            int targetI = -1;
            for (int i = Lists.enemyList.Count - 1; i >= 0; i--)//Tarkistetaan kaikki viholliset erikseen ja valitaan niistä kohde eri laskujen avulla
            {
                Enemy enemy = Lists.enemyList[i];

                if (Vector2.Distance(enemy.position, position) <= range)
                {
                    if (targetType == 1)//Targetoi pisimmälle edennyttä
                    {
                        if (enemy.DistanceTravelled() > temp)
                        {
                            temp = enemy.DistanceTravelled();
                            targetI = i;
                        }
                    }
                    else if (targetType == 2)//Targetoi vähiten edennyttä
                    {
                        if (temp == -1)
                            temp = enemy.DistanceTravelled();
                        if (enemy.DistanceTravelled() <= temp)
                        {
                            temp = enemy.DistanceTravelled();
                            targetI = i;
                        }
                    }
                    else if (targetType == 3)//Targetoi sillä hetkellä vahvinta mötöä
                    {
                        if (enemy.HP > temp)
                        {
                            temp = enemy.HP;
                            targetI = i;
                        }
                    }
                    else if (targetType == 4)//Targetoi sillä hetkellä heikointa mötöä
                    {
                        if (temp == -1)
                            temp = enemy.HP;
                        if (enemy.HP <= temp)
                        {
                            temp = enemy.HP;
                            targetI = i;
                        }
                    }
                }
                if (targetI != -1)
                {
                    target = Lists.enemyList[targetI];
                }
                else
                {
                    target = null;
                }
            }


        }

        /// <summary>
        /// Tätä kutsumalla voidaan tehdä vahinkoa valittuun viholliseen
        /// </summary>
        protected void DealDamageTo(Enemy target, int damage)
        {
            target.HP -= damage;
        }

        protected void Attack()
        {
            if (attackCheck <= 0 && target != null)
            {
                attackCheck = attackSpeed;

                //Archer/Wizard Attack Animations
                if (level == 11 || level == 12 || level == 31 || level == 32) //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                {
                    animation.BeginAnimation(new Rectangle(0, 30, 30, 29), angle, attackAnimationSpeed, attackAnimationFrames);
                }
                else if (level == 13 || level == 14 || level == 33 || level == 34) //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                {
                    animation.BeginAnimation(new Rectangle(0, 90, 30, 29), angle, attackAnimationSpeed, attackAnimationFrames);
                }
                else if (level == 15 || level == 35) //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                {
                    animation.BeginAnimation(new Rectangle(0, 150, 30, 29), angle, attackAnimationSpeed, attackAnimationFrames);
                }
                //Knight Attack Animations
                if (level == 21 || level == 22) //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                {
                    animation.BeginAnimation(new Rectangle(0, 30, 60, 29), angle, attackAnimationSpeed, attackAnimationFrames);
                }
                else if (level == 23 || level == 24) //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                {
                    animation.BeginAnimation(new Rectangle(0, 90, 60, 29), angle, attackAnimationSpeed, attackAnimationFrames);
                }
                else if (level == 25) //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                {
                    animation.BeginAnimation(new Rectangle(0, 150, 60, 29), angle, attackAnimationSpeed, attackAnimationFrames);
                }
            }

            else if (attackCheck > 0 && target != null)
            {
                angle = AngleTo(target.position);
                if (attackSpeed > attackBase)
                {
                    damagePoint = attackPoint * attackBase;
                }
                else
                {
                    damagePoint = attackPoint * attackSpeed;
                }

                if (attackSpeed - attackCheck == Math.Floor(damagePoint))
                {
                    createProjectile = true;
                }
            }

        }
        public bool CheckTargeted()
        {
            if (Input.CursorOverArea(new Rectangle((int)position.X - spriteDrawArea.Width / 2, (int)position.Y - spriteDrawArea.Height / 2, spriteDrawArea.Width - 1, spriteDrawArea.Height - 1)))
            {
                return true;
            }
            else
                return false;
        }

        private void TargetUpdate()
        {
            if (Input.IsKeyPressed(Keys.Q))
            {
                targetType = 1;
            }
            if (Input.IsKeyPressed(Keys.W))
            {
                targetType = 2;
            }
            if (Input.IsKeyPressed(Keys.E))
            {
                targetType = 3;
            }
            if (Input.IsKeyPressed(Keys.R))
            {
                targetType = 4;
            }
        }
        protected void CreateProjectile(Vector2 pos, int dmg, int aoe, int spd, Enemy tar, Animation anim, int particleType)
        {
            Lists.projectileList.Add(new Projectile(pos, dmg, aoe, spd, tar, anim, particleType));
        }
        /// <summary>
        /// Tällä voidaan laskea kulma johonkin kohteeseen ruudulla
        /// </summary>
        public float AngleTo(Vector2 target)
        {
            double angle = Math.Atan2(target.Y - this.position.Y, target.X - this.position.X);
            return MathHelper.ToDegrees((float)angle);
        }

        public virtual void Upgrade()
        {
        }

        public virtual void CheckLevel()
        {
        }
    }
}
