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
    class MainMenu
    {
        bool initialized = false;

        public void Initialize()
        {
            if (!initialized)
            {
                FontManager.InitFonts(1);
                ButtonManager.InitButtons(1);

                initialized = true;
            }
        }

        public void Update()
        {
            Initialize();

            ButtonsUpdate();

            if (MainLoop.gameState == MainLoop.GameState.inGame || MainLoop.gameState == MainLoop.GameState.options)
            {
                initialized = false;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Assests.mainMenu, new Vector2(0, 0), Color.White); //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            //sb.Draw(Assests.mainMenu, new Vector2(250, 100), Color.White);

            FontManager.Draw(sb);
            ButtonManager.Draw(sb);
        }

        public void ButtonsUpdate()
        {
            ButtonManager.Update();

            //Play Button
            if (Lists.onScreenButtonList[0].pressed == true)
            {
                MainLoop.gameState = MainLoop.GameState.inGame;
            }
            //Options Button
            if (Lists.onScreenButtonList[1].pressed == true)
            {
                Options.whereTo = 1;

                MainLoop.gameState = MainLoop.GameState.options;
            }
            //Exit Button
            if (Lists.onScreenButtonList[2].pressed == true)
            {
                //Tämän napin toiminnallisuus on siirretty Game1:n Updateen!
            }
        }
    }
}
