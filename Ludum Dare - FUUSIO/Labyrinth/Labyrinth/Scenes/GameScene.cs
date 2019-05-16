using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Objects;
using Labyrinth.Parents;
using Microsoft.Xna.Framework.Input;
using Labyrinth.Engine;
using Microsoft.Xna.Framework;

namespace Labyrinth.Scenes
{
    class GameScene : SceneParent
    {
        // Variables & Objects
        Player player;
        LevelManager levelManager;

        // Constructor
        public GameScene(LevelManager levelManager)
        {
            player = new Player();
            this.levelManager = levelManager;

            levelManager.Player = player;
        }

        // Update Method
        public void Update(float deltaTime)
        {
            player.Update(deltaTime, levelManager.Tiles);

            if(Input.IsKeyPressed(Keys.D1))
                levelManager.LoadMap("LevelOneMap");
            if (Input.IsKeyPressed(Keys.D2))
                levelManager.LoadMap("LevelTwoMap");
            if (Input.IsKeyPressed(Keys.D3))
                levelManager.LoadMap("LevelThreeMap");

            EnemyManager.Update(deltaTime, levelManager.Tiles);

        }

        // Draw Method
        public void Draw()
        {
            levelManager.Update(player.GetPosition());
            levelManager.Draw();
            player.Draw();
        }

        // Mehtod that allows to change the scene
        public int ChangeScene()
        {
            if (Input.IsKeyPressed(Keys.Enter))
                return 0;
            else
                return 1;
        }
    }
}
