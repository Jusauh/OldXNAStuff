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

namespace Dusk.Player
{
    class Player : Methods
    {
        bool alive = true, focused, invul,shooting;
        Vector2 position, velocity;
        float speed;
        int frame,invulFrame, deathFrame = -1,shootFrame,shootInterval = 6;
        Familiar fam01 = new Familiar(1);
        Familiar fam02 = new Familiar(2);

        public Player(Vector2 position)
        {
            this.position = position;
            invulFrame = 90;
            invul = true;
        }

        public void Update()
        {
            velocity = Vector2.Zero;
            frame++;
            shootFrame--;
            invulFrame--;
            deathFrame--;
            UpdateControls();
            fam01.Update();
            fam02.Update();


            if (invulFrame > 0)
            {
                invul = true;
            }
            else
            {
                invul = false;
            }
            if (deathFrame == 0)
            {
                alive = false;
            }
            position += new Vector2(velocity.X * speed, velocity.Y * speed);

            if (position.X < PlayScreenMinX + 11)
            {
                position.X = PlayScreenMinX + 11;
            }
            if (position.X > PlayScreenMaxX - 11)
            {
                position.X = PlayScreenMaxX - 11;
            }
            if (position.Y < PlayScreenMinY + 18)
            {
                position.Y = PlayScreenMinY + 18;
            }
            if (position.Y > PlayScreenMaxY - 18)
            {
                position.Y = PlayScreenMaxY - 18;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if(invul)
                sb.Draw(Assets.player, position, new Rectangle(0,0,22,54), Color.Gray, 0, new Vector2(11,27), 1f, SpriteEffects.None, 0);
            else
                sb.Draw(Assets.player, position, new Rectangle(0, 0, 22, 54), Color.White, 0, new Vector2(11, 27), 1f, SpriteEffects.None, 0);
            fam01.Draw(sb);
            fam02.Draw(sb);
        }

        private void UpdateControls()
        {
            if (Input.IsKeyDown(Keys.Left))
                velocity.X -= 1;
            if (Input.IsKeyDown(Keys.Right))
                velocity.X += 1;
            if (Input.IsKeyDown(Keys.Up))
                velocity.Y -= 1;
            if (Input.IsKeyDown(Keys.Down))
                velocity.Y += 1;

            if (Input.IsKeyDown(Keys.LeftShift))
            {
                focused = true;
            }
            else
            {
                focused = false;
            }

            if (focused == true)
            {
                speed = 2f;
            }
            else
            {
                speed = 5f;
            }

            if (Input.IsKeyDown(Keys.Z))
            {
                Shoot();
            }
            else
            {
                shooting = false;
            }
            if (Input.IsKeyDown(Keys.X))
            {
                Bomb();
            }
        }

        public void TakeHit()
        {
            if (!invul && deathFrame < 0)
            {
                deathFrame = 5;
            }
        }
        public void Shoot()
        {
            shooting = true;
            if (shootFrame < 0)
            {
                CreatePlayerBullet(GetPlayerX(), GetPlayerY(), 20, 0, -90, 0, new Rectangle(24, 30, 12, 16));
                CreatePlayerBullet(GetPlayerX(), GetPlayerY(), 20, 0, -95, 0, new Rectangle(24, 30, 12, 16));
                CreatePlayerBullet(GetPlayerX(), GetPlayerY(), 20, 0, -85, 0, new Rectangle(24, 30, 12, 16));
                shootFrame = shootInterval;
            }
        }
        public void Bomb()
        {
            if (Lists.bomb.Count == 0)
            {
                Lists.bomb.Add(new Bomb());
                invulFrame = 220;
                deathFrame = -1;
            }
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }
        public bool GetFocused()
        {
            return focused;
        }
        public bool GetInvul()
        {
            return invul;
        }
        public bool GetShooting()
        {
            return shooting;
        }
        public bool IsDead()
        {
            if (deathFrame == 0)
            {

                CreateFX(Assets.fxSheet, new Rectangle(10, 0, 32, 32), new Vector2(16, 16), new Color(255, 255, 255, 120), position, true, 0, 0, 0, 0, 0.5f, 0.2f, 10);
                for (int i = 0; i < 24; i++)
                {
                    CreateFX(Assets.fxSheet, new Rectangle(42, 0, 16, 16), new Vector2(8, 8), new Color(255, 255, 255, 120), position, true, Rand(0, 360), 0, Rand(2, 4), -2f/40f, 2f, -1f/30f, 40);
                }
                return true;
            }
            else
                return false;
        }

    }
}
