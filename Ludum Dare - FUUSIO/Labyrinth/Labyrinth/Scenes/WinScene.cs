using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Parents;
using Labyrinth.Engine;
using Microsoft.Xna.Framework.Input;

namespace Labyrinth.Scenes
{
    class WinScene : SceneParent
    {
        public WinScene(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
        }

        public void Update()
        {
            if (Input.IsKeyPressed(Keys.Enter))
            {
                sceneManager.CurrentScene = SceneManager.Scenes.Menu;
            }
        }
    }
}
