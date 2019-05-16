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
using Labyrinth.Engine;
using Labyrinth.Objects;

namespace Labyrinth.Engine
{
    class Input
    {
        // Variables
        static KeyboardState keyState, oldKeyState;
        static MouseState mouseState, mouseStateOld;
        // Constructor
        public static void UpdateState()
        {
            oldKeyState = keyState;
            mouseStateOld = mouseState;
            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }

        // Checks if the key is down
        public static bool IsKeyDown(Keys key)
        {
            return keyState.IsKeyDown(key);
        }

        // Checks if the key is up
        public static bool IsKeyUp(Keys key)
        {
            return keyState.IsKeyUp(key);
        }

        // Checks if the key is pressed
        public static bool IsKeyPressed(Keys key)
        {
            return keyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key);
        }

        // Checks if the key is released
        public static bool IsKeyReleased(Keys key)
        {
            return keyState.IsKeyUp(key) && oldKeyState.IsKeyDown(key);
        }
        //Hiiren inputit
        /// <summary>
        /// Tarkistaa, onko hiiren vasenta nappia painettu
        /// </summary>
        public static bool MouseLeftPressed()
        {
            if (mouseState.LeftButton == ButtonState.Pressed && mouseStateOld.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tarkistaa, onko hiiren vasen nappi pohjassa
        /// </summary>
        public static bool MouseLeftDown()
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tarkistaa, onko hiiren vasen nappi vapautettu
        /// </summary>
        public static bool MouseLeftReleased()
        {
            if (mouseState.LeftButton == ButtonState.Released && mouseStateOld.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tarkistaa, onko hiiren oikeaa nappia painettu
        /// </summary>
        public static bool MouseRightPressed()
        {
            if (mouseState.RightButton == ButtonState.Pressed && mouseStateOld.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tarkistaa, onko hiiren oikea nappi pohjassa
        /// </summary>
        public static bool MouseRigthDown()
        {
            if (mouseState.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tarkistaa, onko hiiren oikea nappi vapautettu
        /// </summary>
        public static bool MouseRightReleased()
        {
            if (mouseState.RightButton == ButtonState.Released && mouseStateOld.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Palauttaa hiiren sijainnin ruudulla
        /// </summary>
        public static Vector2 MousePosition()
        {
            return new Vector2(mouseState.X, mouseState.Y);
        }

        /// <summary>
        /// Tämän avulla voidaan luoda ruudulle nappeja, palauttaa true arvon jos kursoria pidetään rectanglen sisällä
        /// </summary>
        /// <param name="buttonArea">Rectangle, jonka pinta-ala on napin ala ruudulla</param>
        public static bool CursorOverArea(Rectangle buttonArea)
        {
            if (MousePosition().X >= buttonArea.X
                && MousePosition().X <= buttonArea.X + buttonArea.Width
                && MousePosition().Y >= buttonArea.Y
                && MousePosition().Y <= buttonArea.Y + buttonArea.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
