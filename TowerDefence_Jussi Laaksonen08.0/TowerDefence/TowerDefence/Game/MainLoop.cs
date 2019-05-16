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

namespace TowerDefence.Game
{
    class MainLoop
    {
        public enum GameState { mainMenu, inGame, options };
        public static GameState gameState = new GameState();

        public Rectangle cursorFrame;

        protected InGame inGame = new InGame();
        protected MainMenu mainMenu = new MainMenu();
        protected Options options = new Options();

        public MainLoop()
        {
            gameState = GameState.mainMenu;
        }


        /// <summary>
        /// Tällä pyöritetään kaikkea pelin logiikkaa että ei tarvitse Game1 täyttää koodilla
        /// </summary>
        public void Update()
        {
            ParticleEngine.Update();
            switch (gameState)
            {
                case GameState.mainMenu:
                    mainMenu.Update();
                    break;

                case GameState.inGame:
                    inGame.Update();
                    break;

                case GameState.options:
                    options.Update();
                    break;

            }
            if (Input.MouseLeftDown())
            {
                cursorFrame = new Rectangle(15, 0, 15, 15);
            }
            else
            {
                cursorFrame = new Rectangle(0, 0, 15, 15);
            }

            Lists.ClearDeadObjects();
        }

        /// <summary>
        /// Kaikki pelin piirto ajetaan tässä
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            
            switch (gameState)
            {
                case GameState.mainMenu:
                    mainMenu.Draw(sb);
                    break;

                case GameState.inGame:
                    inGame.Draw(sb);
                    break;

                case GameState.options:
                    options.Draw(sb);
                    break;
            }
            ParticleEngine.Draw(sb, 1);
            sb.Draw(Assests.cursor,Input.MousePosition(),cursorFrame, Color.White);
            
        }


    }
}
