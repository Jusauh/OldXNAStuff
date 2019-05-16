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

namespace WindowsGame1
{
    enum PlayerType
    {
        Ippe,
        Jukka
    }

    class Player
    {
        public static List<Bullet> bList = new List<Bullet>();
        public static List<Bullet> DbList = new List<Bullet>();

        public PlayerType playerType;

        public Color color;
        public Texture2D sprite;
        SpriteEffects spriteEffects;

        public float energy = 100;
        int cooldown;

        public KeyboardState ks;
        public KeyboardState lks;

        public GamePadState gbs;

        public bool shieldActive = false;
        public int shieldDuration;
        public bool alive = true;
        public int master;
        public int health = 20;

        public Vector2 velosity;
        public Vector2 maxSpeed;
        public Vector2 bulletVelosity;
        public Vector2 position;

        public Player(int player, Texture2D sprite, Color color)
        {
            if (player == 1)
            {
                playerType = PlayerType.Jukka;
                this.sprite = sprite;
                position = new Vector2(100, 250);
                this.color = color;
            }
            if (player == 2)
            {
                playerType = PlayerType.Ippe;
                this.sprite = sprite;
                position = new Vector2(700, 250);
                this.color = color;
            }

        }

        void Jukka()
        {
            if (alive == true)
            {
                if (gbs.ThumbSticks.Left.X < 0)
                    if (-this.velosity.Y <= this.maxSpeed.Y)
                        this.velosity += new Vector2(0, -2);

                if (ks.IsKeyDown(Keys.W))
                    if (-this.velosity.Y <= this.maxSpeed.Y)
                        this.velosity += new Vector2(0, -2);
                if (ks.IsKeyDown(Keys.S))
                    if (this.velosity.Y <= this.maxSpeed.Y)
                        this.velosity += new Vector2(0, 2);
                if (ks.IsKeyDown(Keys.A))
                    if (-this.velosity.X <= this.maxSpeed.X)
                        this.velosity += new Vector2(-2, 0);
                if (ks.IsKeyDown(Keys.D))
                    if (this.velosity.X <= this.maxSpeed.X)
                        this.velosity += new Vector2(2, 0);
                if (ks.IsKeyDown(Keys.F) && lks.IsKeyUp(Keys.F))
                {
                    master = 1;
                    Attack(1);
                }
                if (ks.IsKeyDown(Keys.G) && lks.IsKeyUp(Keys.G))
                {
                    master = 1;
                    Attack(4);
                }
                if (ks.IsKeyDown(Keys.R) && lks.IsKeyUp(Keys.R))
                {
                    master = 1;
                    Attack(2);
                }
                if (ks.IsKeyDown(Keys.T) && lks.IsKeyUp(Keys.T))
                {
                    master = 1;
                    Attack(3);
                }
                if (ks.IsKeyDown(Keys.Y) && lks.IsKeyUp(Keys.Y))
                {
                    master = 1;
                    Attack(5);
                }
                if (ks.IsKeyDown(Keys.H) && lks.IsKeyUp(Keys.H))
                {
                    Shield(5);
                }
            }
        }

        void Ippe()
        {
            if (alive == true)
            {
                if (ks.IsKeyDown(Keys.Up))
                    if (-this.velosity.Y <= this.maxSpeed.Y)
                        this.velosity += new Vector2(0, -2);
                if (ks.IsKeyDown(Keys.Down))
                    if (this.velosity.Y <= this.maxSpeed.Y)
                        this.velosity += new Vector2(0, 2);
                if (ks.IsKeyDown(Keys.Left))
                    if (-this.velosity.X <= this.maxSpeed.X)
                        this.velosity += new Vector2(-2, 0);
                if (ks.IsKeyDown(Keys.Right))
                    if (this.velosity.X <= this.maxSpeed.X)
                        this.velosity += new Vector2(2, 0);
                if (ks.IsKeyDown(Keys.NumPad1) && lks.IsKeyUp(Keys.NumPad1))
                {
                    master = 2;
                    Attack(1);
                }
                if (ks.IsKeyDown(Keys.NumPad2) && lks.IsKeyUp(Keys.NumPad2))
                {
                    master = 2;
                    Attack(4);
                }
                if (ks.IsKeyDown(Keys.NumPad4) && lks.IsKeyUp(Keys.NumPad4))
                {
                    master = 2;
                    Attack(2);
                }
                if (ks.IsKeyDown(Keys.NumPad5) && lks.IsKeyUp(Keys.NumPad5))
                {
                    master = 2;
                    Attack(3);
                }
                if (ks.IsKeyDown(Keys.NumPad6) && lks.IsKeyUp(Keys.NumPad6))
                {
                    master = 2;
                    Attack(5);
                }
                if (ks.IsKeyDown(Keys.NumPad3) && lks.IsKeyUp(Keys.NumPad3))
                {
                    Shield(5);
                }
            }
        }
        
        void Shield(int shieldDuration)
        {
            if (energy > 10)
            {
                energy -= 10;
                this.shieldDuration = shieldDuration;
                InGame.fxlist.Add(new Effect(Assests.shield,
                                                this.position,
                                                new Vector2(0, 0),
                                                new Vector2(0, 0),
                                                0,
                                                0f,
                                                0f,
                                                new Color(20,220,20,255),
                                                0f,
                                                0f,
                                                0f,
                                                -20f,
                                                6,
                                                1,
                                                0.1f));
            }
        }

        void Attack(int attack)
        {
            if (attack == 1 && this.cooldown < 0)
            {

                if (spriteEffects == SpriteEffects.None)
                    bulletVelosity = new Vector2(-5, 0);
                else
                    bulletVelosity = new Vector2(5, 0);
                bList.Add(new Bullet(master, this.position, bulletVelosity,new Vector2(bulletVelosity.X/40,0), Assests.shot));

                cooldown = 20;
            }
            if (attack == 2 && this.cooldown < 0)
            {

                if (spriteEffects == SpriteEffects.None)
                    bulletVelosity = new Vector2(-8, 0);
                else
                    bulletVelosity = new Vector2(8, 0);
                bList.Add(new Bullet(master, this.position, bulletVelosity, new Vector2(bulletVelosity.X / 40, 0), Assests.shot));

                cooldown = 40;
            }
            if (attack == 3 && this.cooldown <0)
            {
                if (spriteEffects == SpriteEffects.None)
                    bulletVelosity = new Vector2(-7, -10);
                else
                    bulletVelosity = new Vector2(7, -10);
                bList.Add(new Bullet(master, this.position, bulletVelosity, new Vector2(0, 0.5f), Assests.shot));

                cooldown = 30;
            }
            if (attack == 4 && this.cooldown < 0)
            {
                if (spriteEffects == SpriteEffects.None)
                    bulletVelosity = new Vector2(-7, 10);
                else
                    bulletVelosity = new Vector2(7, 10);
                bList.Add(new Bullet(master, this.position, bulletVelosity, new Vector2(0, -0.5f), Assests.shot));

                cooldown = 30;
            }
            if (attack == 5 && this.cooldown < 0)
            {
                if (spriteEffects == SpriteEffects.None)
                    bulletVelosity = new Vector2(-10, 10);
                else
                    bulletVelosity = new Vector2(10, 10);
                bList.Add(new Bullet(master, this.position, bulletVelosity, new Vector2(0, -0.5f), Assests.shot));
                if (spriteEffects == SpriteEffects.None)
                    bulletVelosity = new Vector2(-10, -10);
                else
                    bulletVelosity = new Vector2(10, -10);
                bList.Add(new Bullet(master, this.position, bulletVelosity, new Vector2(0, 0.5f), Assests.shot));

                cooldown = 90;
            }
        }

        void VelosityControl()
        {
            if (velosity.X < 0)
                velosity.X++;
            if (velosity.X > 0)
                velosity.X--;

            if (velosity.Y < 0)
                velosity.Y++;
            if (velosity.Y > 0)
                velosity.Y--;
        }
        void BorderControl()
        {
            if (this.position.X < 30)
            {
                position.X = 30;
                velosity.X = 0;
                //velosity.X *= -1;
            }
            if (this.position.X > 770)
            {
                position.X = 770;
                velosity.X = 0;
                //velosity.X *= -1;
            }
            if (this.position.Y < 30)
            {
                position.Y = 30;
                velosity.Y = 0;
                //velosity.Y *= -1;
            }
            if (this.position.Y > 360)
            {
                position.Y = 360;
                velosity.Y = 0;
                //velosity.Y *= -1;
            }

        }

        public void Update()
        {
            this.maxSpeed = new Vector2(4,4);
            ks = Keyboard.GetState();
            if(energy < 100)
                energy += 10f / 120f;
            cooldown--;
            shieldDuration--;

            switch (playerType)
            {
                case PlayerType.Jukka:
                    Jukka();
                    break;
                case PlayerType.Ippe:
                    Ippe();
                    break;
            }

            if (this.health <= 0)
                this.alive = false;

            if (shieldDuration > 0)
                shieldActive = true;
            else if(shieldDuration <0)
                shieldActive = false;

            VelosityControl();
            position += velosity;
            if (alive == true)
                BorderControl();
            lks = Keyboard.GetState();

        }

        public void Draw(SpriteBatch sb)
        {
            if (velosity.X < 0)
                spriteEffects = SpriteEffects.None;
            if (velosity.X > 0)
                spriteEffects = SpriteEffects.FlipHorizontally;

            sb.Draw(sprite,position,null, color, 0, new Vector2(sprite.Width / 2, sprite.Height/2),1,spriteEffects, 0);
        }

    }
}
