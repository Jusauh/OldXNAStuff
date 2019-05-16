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

namespace Dusk.Engine
{
    class Input
    {
        static KeyboardState keyState, keyStateOld;


        public static void UpdateState()
        {
            keyStateOld = keyState;
            keyState = Keyboard.GetState();
        }

        public static bool IsKeyDown(Keys key)
        {
            return keyState.IsKeyDown(key);
        }

        public static bool IsKeyUp(Keys key)
        {
            return !keyState.IsKeyDown(key);
        }

        public static bool IsKeyPressed(Keys key)
        {
            return keyState.IsKeyDown(key) && keyStateOld.IsKeyUp(key);
        }

        public static bool IsKeyReleased(Keys key)
        {
            return keyState.IsKeyUp(key) && keyStateOld.IsKeyDown(key);
        }
    }
}
