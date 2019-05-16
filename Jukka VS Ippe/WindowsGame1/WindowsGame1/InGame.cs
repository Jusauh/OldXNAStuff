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
    class InGame
    {
        float BGRotation;
        int wait = 0;
        int quoteInit = 0;
        Random rand = new Random();

        public static List<Effect> fxlist = new List<Effect>();
        public static List<Effect> Dfxlist = new List<Effect>();

        public void Update()
        {
            JvsIMain.player1.Update();
            JvsIMain.player2.Update();

            if (JvsIMain.player1.alive == false || JvsIMain.player2.alive == false)
            {
                if (MediaPlayer.Volume > 0.5f)
                    MediaPlayer.Volume -= 0.05f;
                quoteInit = rand.Next(1,5);
                wait++;

                if (JvsIMain.player2.alive == false)
                {
                    JvsIMain.player2.velosity = new Vector2(0, 0);
                    if (wait == 1)
                    {
                        fxlist.Add(new Effect(Assests.circle,
                                JvsIMain.player2.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                0,
                                0f,
                                0f,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                200,
                                0,
                                0.006f));
                    }
                    if (wait == 40)
                    {
                        fxlist.Add(new Effect(Assests.lightBeam,
                                JvsIMain.player2.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                1,
                                0.013f,
                                0,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                160,
                                1f,
                                0));
                    }
                    if (wait == 80)
                    {
                        fxlist.Add(new Effect(Assests.lightBeam,
                                JvsIMain.player2.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                0.6f,
                                -0.013f,
                                0,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                120,
                                1f,
                                0));
                    }
                    if (wait == 120)
                    {
                        fxlist.Add(new Effect(Assests.lightBeam,
                                JvsIMain.player2.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                1.3f,
                                -0.019f,
                                0,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                80,
                                1f,
                                0));
                    }
                    if (wait == 160)
                    {
                        fxlist.Add(new Effect(Assests.lightBeam,
                                JvsIMain.player2.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                0.3f,
                                0.029f,
                                0,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                40,
                                1f,
                                0));
                    }
                    if (wait == 180)
                    {
                        fxlist.Add(new Effect(Assests.circle,
                                    JvsIMain.player2.position,
                                    new Vector2(0, 0),
                                    new Vector2(0, 0),
                                    0,
                                    0f,
                                    0f,
                                    Color.White,
                                    0f,
                                    0f,
                                    0f,
                                    0f,
                                    35,
                                    1,
                                    0.7f));
                    }
                }

                if (JvsIMain.player1.alive == false)
                {
                    JvsIMain.player1.velosity = new Vector2(0, 0);
                    if (wait == 1)
                    {
                        fxlist.Add(new Effect(Assests.circle,
                                JvsIMain.player1.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                0,
                                0f,
                                0f,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                200,
                                0,
                                0.006f));
                    }
                    if (wait == 40)
                    {
                        fxlist.Add(new Effect(Assests.lightBeam,
                                JvsIMain.player1.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                1,
                                0.013f,
                                0,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                160,
                                1f,
                                0));
                    }
                    if (wait == 80)
                    {
                        fxlist.Add(new Effect(Assests.lightBeam,
                                JvsIMain.player1.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                0.6f,
                                -0.013f,
                                0,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                120,
                                1f,
                                0));
                    }
                    if (wait == 120)
                    {
                        fxlist.Add(new Effect(Assests.lightBeam,
                                JvsIMain.player1.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                1.3f,
                                -0.019f,
                                0,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                80,
                                1f,
                                0));
                    }
                    if (wait == 160)
                    {
                        fxlist.Add(new Effect(Assests.lightBeam,
                                JvsIMain.player1.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                0.3f,
                                0.029f,
                                0,
                                Color.White,
                                0f,
                                0f,
                                0f,
                                0f,
                                40,
                                1f,
                                0));
                    }
                    if (wait == 180)
                    {
                        fxlist.Add(new Effect(Assests.circle,
                                    JvsIMain.player1.position,
                                    new Vector2(0, 0),
                                    new Vector2(0, 0),
                                    0,
                                    0f,
                                    0f,
                                    Color.White,
                                    0f,
                                    0f,
                                    0f,
                                    0f,
                                    35,
                                    1,
                                    0.7f));
                    }
                }


                if (wait == 210)
                {
                    if (JvsIMain.player1.alive == false)
                        JvsIMain.player1.position = new Vector2(-1000, -1000);
                    if (JvsIMain.player2.alive == false)
                        JvsIMain.player2.position = new Vector2(-1000, -1000);

                    fxlist.Add(new Effect(Assests.circle,
                                JvsIMain.player1.position,
                                new Vector2(0, 0),
                                new Vector2(0, 0),
                                0,
                                0f,
                                0f,
                                Color.White,
                                -255f / 90,
                                -255f / 90,
                                -255f / 90,
                                -255f/90,
                                90,
                                300,
                                0f));
                }
                


                if (wait == 200)
                {
                    if (JvsIMain.player1.alive == true)
                    {
                        if (quoteInit == 1)
                            Assests.jukkaWQuote1.Play();
                        if (quoteInit == 2)
                            Assests.jukkaWQuote2.Play();
                        if (quoteInit == 3)
                            Assests.jukkaWQuote3.Play();
                        if (quoteInit == 4)
                            Assests.jukkaWQuote4.Play();
                        if (quoteInit == 5)
                            Assests.jukkaWQuote5.Play();
                    }
                    if (JvsIMain.player2.alive == true)
                    {
                        if (quoteInit == 1)
                            Assests.ippeWQuote1.Play();
                        if (quoteInit == 2)
                            Assests.ippeWQuote2.Play();
                        if (quoteInit == 3)
                            Assests.ippeWQuote3.Play();
                        if (quoteInit == 4)
                            Assests.ippeWQuote4.Play();
                        if (quoteInit == 5)
                            Assests.ippeWQuote5.Play();
                    }
                }


                if (wait == 540)
                {
                    foreach (Bullet b in Player.bList)
                    {
                        Player.DbList.Add(b);
                    }

                    foreach (Bullet b in Player.DbList)
                    {
                        Player.bList.Remove(b);
                    }
                    Player.DbList.Clear();


                    MediaPlayer.Volume = 1;
                    wait = 0;
                    JvsIMain.gameState = GameState.EndScreen;
                    MediaPlayer.Play(Assests.endMusic);
                }
            }
            if (Vector2.Distance(JvsIMain.player1.position, JvsIMain.player2.position) < 50)
            {
                JvsIMain.player1.position += new Vector2(JvsIMain.player1.velosity.X * -1, JvsIMain.player1.velosity.Y * -1);
                JvsIMain.player2.position += new Vector2(JvsIMain.player2.velosity.X * -1, JvsIMain.player2.velosity.Y * -1);

                JvsIMain.player1.velosity = new Vector2(JvsIMain.player1.velosity.X * -5, JvsIMain.player1.velosity.Y * -5);
                JvsIMain.player2.velosity = new Vector2(JvsIMain.player2.velosity.X * -5, JvsIMain.player2.velosity.Y * -5);
            }


            foreach (Bullet b in Player.bList)
            {
                b.Update();

                if (Vector2.Distance(b.position, JvsIMain.player1.position) < 50 && b.master == 2 && JvsIMain.player1.shieldActive == true)
                {
                    b.master = 1;
                    b.velosity.X *= -1;
                    b.velosity.Y *= -1;
                    b.acceleration.X *= -1;
                }
                if (Vector2.Distance(b.position, JvsIMain.player2.position) < 50 && b.master == 1 && JvsIMain.player2.shieldActive == true)
                {
                    b.master = 2;
                    b.velosity.X *= -1;
                    b.velosity.Y *= -1;
                    b.acceleration.X *= -1;
                }
                if (Vector2.Distance(b.position, JvsIMain.player1.position) < 40 && b.master == 2)
                {
                    b.alive = false;
                    JvsIMain.player1.health -= 1;
                }
                if (Vector2.Distance(b.position, JvsIMain.player2.position) < 40 && b.master == 1)
                {
                    b.alive = false;
                    JvsIMain.player2.health -= 1;
                }
                if (b.alive == false)
                    Player.DbList.Add(b);
            }
            foreach (Bullet b in Player.DbList)
            {
                Player.bList.Remove(b);
            }
            Player.DbList.Clear();


            foreach (Effect fx in fxlist)
            {
                fx.Update();
                if (fx.alive == false)
                {
                    Dfxlist.Add(fx);
                }
            }
            foreach (Effect fx in Dfxlist)
            {
                fxlist.Remove(fx);
            }
            Dfxlist.Clear();

            BGRotation += 0.01f;

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Assests.BG,
                    new Vector2 ( 400, 230),
                    null,
                    Color.White,
                    BGRotation,
                    new Vector2(Assests.BG.Width / 2, Assests.BG.Height / 2),
                    0.8f,
                    SpriteEffects.None,
                    0);

            JvsIMain.player1.Draw(sb);
            JvsIMain.player2.Draw(sb);
            foreach (Bullet b in Player.bList)
            {
                b.Draw(sb);
            }

            sb.End();
            sb.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            foreach (Effect fx in fxlist)
                fx.Draw(sb);
            sb.End();
            sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            sb.Draw(Assests.hud, new Vector2(0, 400), Color.White);

            sb.Draw(Assests.bar, new Vector2(111, 442), new Rectangle(0,0,200-(200-(int)JvsIMain.player1.energy*2),10), Color.Yellow, 0, new Vector2(0,0), 1, SpriteEffects.None, 0);
            sb.Draw(Assests.bar, new Vector2(890 - (int)JvsIMain.player2.energy * 2, 442), new Rectangle(0, 0, 200 - (200 - (int)JvsIMain.player2.energy * 2), 10), Color.Yellow, 0, new Vector2(200, 0), 1, SpriteEffects.None, 0);

            sb.Draw(Assests.bar, new Vector2(111, 430), new Rectangle(0, 0,(int)JvsIMain.player1.health * 10, 10), Color.LimeGreen, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            sb.Draw(Assests.bar, new Vector2(890 - (int)JvsIMain.player2.health*10, 430), new Rectangle(0, 0,(int)JvsIMain.player2.health*10, 10), Color.LimeGreen, 0, new Vector2(200, 0), 1, SpriteEffects.None, 0);
        }

    }
}
