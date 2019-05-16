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

namespace IppeBeli
{
    class Main
    {
        float timer;

        List<Test> testList;
        List<Test> deadTestList;

        List<Particle> particleList;
        List<Particle> deadParticleList;

        bool initialized;

        Vector2 startPosition;
        Vector2 stampPosition;

        bool pressed1;
        bool pressed2;
        bool pressed3;
        bool pressed4;

        float stampThreshold;

        List<char> currentBeatmap;
        float currentBPM;

        float handPosition;
        float health;
        bool miss;

        Random rand = new Random();

        float readingTimer;
        float readingSpeed;

        float testSpeed;

        bool stageOver;

        Song currentSong;

        float sweepHandRotation;

        public void Initialize()
        {
            Beatmaps.InitializeBeatmaps();

            handPosition = 0;

            startPosition = new Vector2(450, 300);
            stampPosition = new Vector2(450, 300);

            testSpeed = 550f;

            particleList = new List<Particle>();
            deadParticleList = new List<Particle>();

            testList = new List<Test>();
            deadTestList = new List<Test>();

            health = 150;
            stampThreshold = 30.0f;

            currentBeatmap = Beatmaps.beatmap2;
            currentBPM = Beatmaps.beatmap2_BPM;
            currentSong = Beatmaps.beatmap2_Song;

            CreateBeatMap();

            readingSpeed = 1.0f;
            readingTimer = 1.0f;
        }

        void CreateBeatMap()
        {
            float beatDistance = 0;
            float currentPosition = 0;

            for (int i = 0; i < currentBeatmap.Count; i++)
            {
                bool addDistance = false;
                switch (currentBeatmap[i])
                {
                    case '4':
                        beatDistance = testSpeed / (currentBPM / 60);
                        break;
                    case '8':
                        beatDistance = testSpeed / (currentBPM / 60) / 2;
                        break;
                    case 'S':
                        beatDistance = testSpeed / (currentBPM / 60) / 4;
                        break;
                    case 'x':
                        testList.Add(new Test(TestType.Math, new Vector2(startPosition.X - currentPosition, startPosition.Y), testSpeed));
                        addDistance = true;
                        break;
                    case 'y':
                        testList.Add(new Test(TestType.Biology, new Vector2(startPosition.X - currentPosition, startPosition.Y), testSpeed));
                        addDistance = true;
                        break;
                    case 'o':
                        addDistance = true;
                        break;
                }
                
                if(addDistance)
                    currentPosition += beatDistance;
            }
        }

        void Stamp()
        {
            bool hitTest = false;

            foreach (Test t in testList)
            {
                if (t.position.X >= stampPosition.X - stampThreshold && t.position.X <= stampPosition.X + stampThreshold && !t.stamped && t.type == TestType.Math)
                {
                    t.Stop();
                    t.stamped = true;
                    hitTest = true;
                    Assets.hit1.Play(0.3f, 0.0f, 0.0f);
                    health += 7;
                }
            }

            if (!hitTest)
            {
                health -= 5.0f;
                Assets.hit2.Play();
            }
        }

        void Sweep()
        {
            bool hitTest = false;

            foreach (Test t in testList)
            {
                if (t.position.X >= stampPosition.X - stampThreshold && t.position.X <= stampPosition.X + stampThreshold && !t.sweeped && t.type == TestType.Biology)
                {
                    t.Sweep();
                    hitTest = true;
                    Assets.swoop1.Play();
                    health += 5f;
                }
            }

            if (!hitTest)
            {
                Assets.swoop2.Play();
                health -= 3.0f;
            }
        }

        public void Update(float gameTime)
        {
            if (!initialized)
            {
                Initialize();
                initialized = true;
            }

            miss = false;

            KeyboardState ks = Keyboard.GetState();

            if (MediaPlayer.State == MediaState.Playing)
            {
                if (handPosition > 0)
                    handPosition -= 4;


                readingTimer += readingSpeed * gameTime;

                timer += gameTime;

                if (ks.IsKeyDown(Keys.X) && !pressed1)
                {
                    Stamp();
                    handPosition = 20;
                    pressed1 = true;
                }
                if (ks.IsKeyUp(Keys.X))
                {
                    pressed1 = false;
                }

                if (ks.IsKeyDown(Keys.C) && !pressed2)
                {
                    Stamp();
                    handPosition = 20;
                    pressed2 = true;
                }
                if (ks.IsKeyUp(Keys.C))
                {
                    pressed2 = false;
                }

                if (ks.IsKeyDown(Keys.Z) && !pressed3)
                {
                    Sweep();
                    sweepHandRotation = 90;
                    pressed3 = true;
                }
                if (ks.IsKeyUp(Keys.Z))
                {
                    pressed3 = false;
                }

                if (ks.IsKeyDown(Keys.V) && !pressed4)
                {
                    Sweep();
                    sweepHandRotation = 90;
                    pressed4 = true;
                }
                if (ks.IsKeyUp(Keys.V))
                {
                    pressed4 = false;
                }

                sweepHandRotation -= 10;

                if (sweepHandRotation < 0f)
                    sweepHandRotation = 0f;

                if (health > 150)
                    health = 150;

                health -= gameTime * 4;

                foreach (Particle p in particleList)
                {
                    p.Update();

                    if (!p.alive)
                        deadParticleList.Add(p);
                }

                foreach (Particle p in deadParticleList)
                {
                    particleList.Remove(p);
                }

                foreach (Test t in testList)
                {
                    float random = (float)rand.NextDouble();

                    t.Update(gameTime);

                    if (t.position.X > 530)
                    {
                        if (!t.beingShredded)
                        {
                            Assets.shred.Play(0.6f, 0f, 0f);
                            health -= 7.0f;
                        }

                        t.beingShredded = true;

                        particleList.Add(new Particle(new Vector2(630 + random * 57, 335 - random * 78),
                                                      new Vector2((float)+rand.NextDouble() * 2, (float)rand.NextDouble() * 1),
                                                      rand.Next(1, 5),
                                                      (float)rand.NextDouble() * 360));
                    }

                    if (!t.alive)
                        deadTestList.Add(t);
                }

                foreach (Test t in deadTestList)
                {
                    testList.Remove(t);
                }
                deadTestList.Clear();

            }

            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(currentSong);
                MediaPlayer.Pause();
            }
            if (MediaPlayer.State == MediaState.Paused)
                MediaPlayer.Resume();

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Assets.bg,
                Vector2.Zero,
                Color.White);

            foreach (Test t in testList)
            {
                t.Draw(sb);
            }

            sb.Draw(Assets.ippe,
                    new Vector2(405,117),
                    Color.White);
            sb.Draw(Assets.sweepHand,
                    new Vector2(415, 235),
                    null,
                    Color.White,
                    MathHelper.ToRadians(sweepHandRotation),
                    new Vector2(10, 10),
                    1.0f,
                    SpriteEffects.None,
                    1);
            sb.Draw(Assets.ippeHand,
                    new Vector2(434,210+handPosition),
                    Color.White);
            sb.Draw(Assets.shredder,
                    new Vector2(530, 220),
                    Color.White);

            sb.Draw(Assets.hpBar,
                    new Vector2(2, 563),
                    new Rectangle(0, 0, (int)health * 4, Assets.hpBar.Height),
                    Color.LimeGreen,
                    0,
                    new Vector2(0, 0),
                    1,
                    SpriteEffects.None,
                    0);
            sb.Draw(Assets.hpBarOverlay,
                    new Vector2(0, 540),
                    Color.White);

            foreach (Particle p in particleList)
            {
                p.Draw(sb);
            }
        }
    }
}
