using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Parents;
using Microsoft.Xna.Framework.Input;
using Labyrinth.Engine;
using Microsoft.Xna.Framework;

namespace Labyrinth.Scenes
{
    class MainMenuScene : SceneParent
    {
        public MainMenuScene()
        {
            Recources.LoadTexture("StartScreen7");
        }

        // Mehtod that allows to change the scene
        public int ChangeScene()
        {
            if (Input.IsKeyPressed(Keys.Enter))
                return 1;
            else
                return 0;
        }

        public void Draw()
        {
            DrawSys.Draw(Recources.GetTexture("StartScreen7"), Vector2.Zero);
        }
    }
}
