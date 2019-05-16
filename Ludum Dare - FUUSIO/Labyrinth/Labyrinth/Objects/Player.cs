using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Parents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Labyrinth.Engine;
using Microsoft.Xna.Framework.Input;

namespace Labyrinth.Objects
{
    class Player : MovingObjectParent
    {
        // Variables
        Animation animationTorso;
        Animation animationLegs;
        Cursor cursor;
        int dyingAnimationFrames=0;
        int playerAlive=0;
        Vector2 moving;

        bool shot;
        
        //Testi liikkumisanimaatioon
        Vector2 positionOld;

        // Constructor
        public Player() : base()
        {
            shot = false;
            moving = Vector2.Zero;
            direction = Vector2.Zero;
            position = new Vector2(33, 33);
            speed = new Vector2(200, 200);

            lastPosition = position;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            Recources.LoadTexture("pelaaja_jalat");

            animationTorso = new Animation(Recources.GetTexture("pelaaja_jalat"), new Rectangle(0, 0, 32, 32), 0.2f, 8);
            animationLegs = new Animation(Recources.GetTexture("pelaaja_jalat"), new Rectangle(0, 128, 32, 32), 0.2f, 8);
            animationTorso.BeginAnimation(new Rectangle(0, 0, 32, 32), 0, 0.1f, 8);
            animationLegs.BeginAnimation(new Rectangle(0, 128, 32, 32 ), 0, 0.05f, 8);

            cursor = new Cursor();
            //testiä animaatioon
            positionOld = position;
        }

        //Update
        public override void Update(float deltaTime, List<Tiles> tiles)
        {
            base.Update(deltaTime, tiles);

            direction = MovingDirection(angle);

            
            
            if (Input.IsKeyDown(Keys.D))
            {
                alive = false;
                playerAlive = 1;
            }
            if (Input.IsKeyDown(Keys.S))
            {
                alive = false;
                playerAlive = 2;
            }

            if (playerAlive ==1 && aliveOld)
            {
                Die();
                aliveOld = false;
            }
            if (playerAlive == 2 && aliveOld)
            {
                DieBoss();
                aliveOld = false;
            }

            //if (position != positionOld)
            if (alive)
            {
                if (direction.X != 0 || direction.Y != 0)
                {
                    animationLegs.Update(deltaTime);
                    animationTorso.Update(deltaTime);
                }
                else
                {
                    animationLegs.Reset();
                }
                angle = cursor.Update(position);
                positionOld = position;

                if (Input.MouseLeftPressed() && shot)
                {
                    foreach (Enemy enemy in Enemy.enemyList)
                    {
                    if (CanShoot(angle, position, enemy.boundingBox , tiles))
                        enemy.alive = false;
                        shot = false;
                    }
                }
            }
            else
            {
                if (dyingAnimationFrames < 3)
                {
                    dyingAnimationFrames = animationTorso.Update(deltaTime);
                }
            }


        }

        // Draw
        public void Draw()
        {
            if (alive)
            {
                animationLegs.Draw(position, angle);
                animationTorso.Draw(position, angle);
                //DrawSys.Draw(Recources.GetTexture("henchman1b"), position);
            }
            else
            {
                animationTorso.Draw(position, angle);
            }
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public Rectangle GetBoundingBox()
        {
            return boundingBox;
        }

        //Tässä pelaaja kuolee
        private void Die()
        {
            animationLegs = new Animation(Recources.GetTexture("pelaaja_jalat"), new Rectangle(0, 0, 0, 0), 1, 1);
            animationTorso = new Animation(Recources.GetTexture("pelaaja_jalat"), new Rectangle(0, 96, 32, 32), 0.5f, 3);
            animationTorso.BeginAnimation(new Rectangle(0, 96, 32, 32), angle, 0.2f, 3);
        }
        //Tässä bossi tappaa pelaajan
        private void DieBoss()
        {
            animationLegs = new Animation(Recources.GetTexture("pelaaja_jalat"), new Rectangle(0, 0, 0, 0), 1, 1);
            animationTorso = new Animation(Recources.GetTexture("pelaaja_jalat"), new Rectangle(96, 96, 32, 32), 0.5f, 3);
            animationTorso.BeginAnimation(new Rectangle(96, 96, 32, 32), angle, 0.13f, 3);
        }

        //Tässä muutamme playerin kontrolleja
        private Vector2 MovingDirection(float movingAngle)
        {
            if (Input.IsKeyDown(Keys.Down))
            {
                moving.X = -1;
            }
            if (Input.IsKeyDown(Keys.Up))
                moving.X = 1;
            if (Input.IsKeyDown(Keys.Right))
                moving.Y = 1;
            if (Input.IsKeyDown(Keys.Left))
                moving.Y = -1;
            if (Input.IsKeyUp(Keys.Up) && Input.IsKeyUp(Keys.Down))
                moving.X = 0;
            if (Input.IsKeyUp(Keys.Left) && Input.IsKeyUp(Keys.Right))
            {
                moving.Y = 0;
            }

            if (Input.MouseRigthDown())
                speed =  new Vector2(100, 100);
            else
                speed =  new Vector2(200, 200);

            return new Vector2(moving.X * (float)Math.Cos(angle) - moving.Y * (float)Math.Sin(angle), moving.X * (float)Math.Sin(angle) + moving.Y * (float)Math.Cos(angle));
        }

        public void HasGun()
        {
            shot = true;
        }
    }
}
