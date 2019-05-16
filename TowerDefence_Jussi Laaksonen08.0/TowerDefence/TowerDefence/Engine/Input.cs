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

//Tässä luokassa säädetään kaikkia pelin inputteja, näitä kutsumalla saamme kätevästi hoidettua näppiksen ja hiiren inputit

namespace TowerDefence.Engine
{
    class Input
    {
        static KeyboardState keyState, keyStateOld;
        static MouseState mouseState, mouseStateOld;

        /// <summary>
        /// Tätä kutsumalla päivitetään inputit
        /// </summary>
        public static void UpdateState()
        {
            keyStateOld = keyState;
            mouseStateOld = mouseState;
            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }

        //Näppiksen inputit
        /// <summary>
        /// Tarkistetaan, onko näppäimistön nappi pohassa
        /// </summary>
        /// <param name="key">Nappi, jota tarkistetaan</param>
        public static bool IsKeyDown(Keys key)
        {
            return keyState.IsKeyDown(key);
        }

        /// <summary>
        /// Tarkistetaan, onko näppäimistön nappi ylhäällä
        /// </summary>
        /// <param name="key">Nappi, jota tarkistetaan</param>
        public static bool IsKeyUp(Keys key)
        {
            return !keyState.IsKeyDown(key);
        }

        /// <summary>
        /// Tarkistetaan, onko nappia painettu
        /// </summary>
        /// <param name="key"></param>
        public static bool IsKeyPressed(Keys key)
        {
            return keyState.IsKeyDown(key) && keyStateOld.IsKeyUp(key);
        }

        /// <summary>
        /// Tarkistetaan, onko nappi vapautettu
        /// </summary>
        /// <param name="key"></param>
        public static bool IsKeyReleased(Keys key)
        {
            return keyState.IsKeyUp(key) && keyStateOld.IsKeyDown(key);
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
        /// <summary>
        /// Laskee sijainnin koordinaatistoon
        /// </summary>
        /// <param name="position">Sijainti, joka halutaa pyöristää alimpaan 30 jaolliseen lukuun lisättynä 15</param>
        /// <returns></returns>
        public static Vector2 gridPosition(Vector2 position)
        {
            double cordX = 0;
            double cordY = 0;

            cordX = Math.Floor(Input.MousePosition().X / 30) * 30;
            cordY = Math.Floor(Input.MousePosition().Y / 30) * 30;
            return new Vector2((float)cordX + 15, (float)cordY + 15);
        }
    }
}
