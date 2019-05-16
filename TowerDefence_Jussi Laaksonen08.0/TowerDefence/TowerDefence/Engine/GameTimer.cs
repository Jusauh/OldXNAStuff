using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence.Engine
{
    class GameTimer
    {
        private SpriteFont font;

        private static string text;

        private static float time;
        private static float timeWhenStarted;

        private static Vector2 position;

        private static bool started;
        private static bool paused;
        private static bool finished;

        private static Color color;

        public GameTimer(float startTime, Vector2 _position, Color _color)
        {
            this.font = Assests.Font14;
            time = startTime;
            timeWhenStarted = startTime;
            position = _position;
            color = _color;

            text = "";

            started = false;
            paused = false;
            finished = false;
        }

        public void Start()
        {
            started = true;
        }

        public void Reset()
        {
            time = timeWhenStarted;
        }

        public void Pause()
        {
            paused = true;
        }

        public void UnPause()
        {
            paused = false;
        }

        public bool IsFinished()
        {
            return finished;
        }

        public void SetFinishedFalse()
        {
            finished = false;
        }

        public static void Update(GameTime gTime)
        {
            float deltaTime = (float)gTime.ElapsedGameTime.TotalSeconds;

            if (started)
            {
                if (!paused)
                {
                    if (time > 0)
                    {
                        time -= deltaTime;
                    }
                    else finished = true;
                }
            }

            text = ((int)time).ToString();
        }

        public static void Draw(SpriteBatch sb)
        {
            sb.DrawString(Assests.Font14, text, position, color);
        }
    }
}
