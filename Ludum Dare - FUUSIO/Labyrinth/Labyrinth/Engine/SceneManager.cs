using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Scenes;
using Microsoft.Xna.Framework.Input;
using Labyrinth.Objects;
using Microsoft.Xna.Framework;

namespace Labyrinth.Engine
{
    class SceneManager
    {
        // Objects & Variables
        MainMenuScene mainMenuScene;
        GameScene gameScene;
        LevelManager levelManager;

        private enum Scenes { Menu = 0, Game };

        Scenes currentScene;

        // Constructor
        public SceneManager()
        {
            levelManager = new LevelManager();
            mainMenuScene = new MainMenuScene();
            gameScene = new GameScene(levelManager);

            // Loads the map. Should be somewhere else
            levelManager.LoadMap("LevelOneMap");

            currentScene = Scenes.Menu;
        }

        // Update Method
        public void Update(float deltaTime)
        {
            // Decides which scene to update
            if (currentScene == Scenes.Game)
            {
                gameScene.Update(deltaTime);
                currentScene = (Scenes)gameScene.ChangeScene();
            }
            else
            {
                mainMenuScene.Update();
                currentScene = (Scenes)mainMenuScene.ChangeScene();
            }
        }

        // Draw Method
        public void Draw()
        {
            // Decides which scene to draw
            if (currentScene == Scenes.Game)
            {
                gameScene.Draw();
            }
            else
            {
                mainMenuScene.Draw();
            }
        }
    }
}
