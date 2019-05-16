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
    class Projectile
    {
        protected Enemy target;
        protected Animation animation;
        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 emptyTarget;
        protected int damage;
        protected int aoe;
        protected float angle;
        protected float distance;
        protected int speed;
        public bool isAlive = true;
        protected bool targetEnemy = true;
        private int particleCounter = 0;
        private int particleType;

        public Projectile(Vector2 position, int damage, int aoe, int speed, Enemy target, Animation animation, int particleType)
        {
            this.position = position;
            this.target = target;
            this.animation = animation;
            this.damage = damage;
            this.speed = speed;
            this.aoe = aoe;
            this.particleType = particleType;
        }

        public void Update()
        {
            if (targetEnemy == true)    //Jos kohde on hengissä, ammus liikkuu sitä kohdin
            {
                angle = AngleTo(target.position);
                distance = Vector2.Distance(position, target.position);
                if (distance < speed)
                {
                    position = target.position;
                    isAlive = false;
                    if (aoe == 0)
                    {
                        target.HP -= damage;
                    }
                    else
                    {
                        for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
                        {
                            Enemy enemy = Lists.enemyList[i];

                            if (Vector2.Distance(enemy.position, position) <= aoe)
                            {
                                enemy.HP -= damage;
                            }
                        }
                    }
                }
                if (target.HP <= 0)
                {
                    targetEnemy = false;
                    emptyTarget = target.position;
                }
            }
            else            //Jos kohde on koullut, ammus liikkuu sen viimeisimpään kohtaan jossa oltiin vielä elossa ja tekee AoE damagen
            {   
                angle = AngleTo(emptyTarget);
                distance = Vector2.Distance(position, emptyTarget);
                if (distance < speed)
                {
                    position = emptyTarget;
                    isAlive = false;
                    if (aoe > 0)
                    {
                        for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
                        {
                            Enemy enemy = Lists.enemyList[i];

                            if (Vector2.Distance(enemy.position, position) <= aoe)
                            {
                                enemy.HP -= damage;
                            }
                        }
                    }
                }
            }

            velocity = new Vector2((float)Math.Cos(angle) * speed, (float)Math.Sin(angle) * speed);
            position += velocity;
            
            //particletypen mukaan kutsutaan oikeaa efektiä
            switch (particleType)
            {
                case 1:
                    ParticlesWizard1();
                    break;
                case 2:
                    ParticlesWizard2();
                    break;
                case 3:
                    ParticleKnight();
                    break;
                case 4:
                    ParticleArcher();
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            angle = MathHelper.ToDegrees(angle);
            animation.Draw(sb, position, angle);
        }

        public float AngleTo(Vector2 target)
        {
            double angle = Math.Atan2(target.Y - this.position.Y, target.X - this.position.X);
            return (float)angle;
        }

        //Tällä voi muuttaa partikkelin syntymiskohtaa sivulle, jolloin kaikki ei synny samasta kohtaa
        private Vector2 ParticlePosition(Vector2 position, float angle)
        {
            Random rand = new Random();
            particleCounter = rand.Next(0, 3);
            if (particleCounter == 0)
            {
                particleCounter = 1;
                return position;
            }
            else if (particleCounter == 1)
            {
                particleCounter = 2;
                angle += (3.1415f / 2);
                return new Vector2((position.X + 6 * (float)Math.Sin(angle)), (position.Y + 6 * (float)Math.Cos(angle)));
            }
            else
            {
                particleCounter = 0;
                angle -= (3.1415f / 2);
                return new Vector2((position.X + 6 * (float)Math.Sin(angle)), (position.Y + 6 * (float)Math.Cos(angle)));
            }

        }
        //Hahmokohtaiset partikkelit
        private void ParticlesWizard1()
        {
            ParticleEngine.ParticleAnimation(Assests.particle, new Rectangle(0, 0, 3, 3),
                                           ParticlePosition(position, angle), 5, 0.1f, angle + 30 - 180, angle - 30 + 180, 2, 20, 0, 1);

            if (isAlive == false)
            {
                ParticleEngine.ParticleAnimation(Assests.particle, new Rectangle(0, 0, 3, 3),
                                                position, 5, 0.8f, 0, 360, 20, 15, 0, 1);

                ParticleEngine.ParticleAnimation(Assests.wizardTower, new Rectangle(210, 0, 30, 30), position, 3, 0f, 0, 0, 1, 6, 0, 1);
            }
        }

        private void ParticlesWizard2()
        {
            if (isAlive == false)
            {
                ParticleEngine.ParticleAnimation(Assests.particle, new Rectangle(15, 3, 3, 3),
                                                position, 5, 1.0f, 0, 360, 20, 19, 0, 1);

                ParticleEngine.ParticleAnimation(Assests.wizardTower, new Rectangle(210, 0, 30, 30), position, 3, 0f, 0, 0, 1, 6, 0, 1);
            }
        }

        private void ParticleKnight()
        {
            ParticleEngine.ParticleAnimation(Assests.knightTower, new Rectangle(240, 0, 30, 30),
                                position, 2, 2.0f, 0, 360, 1, 4, 0, 1);
        }

        private void ParticleArcher()
        {
            if (isAlive == false)
            {
                ParticleEngine.ParticleAnimation(Assests.particle, new Rectangle(0, 3, 2, 2),
                                                position, 1, 1.0f, 0, 360, 30, 12, 0, 1);
            }
        }
    }
}
