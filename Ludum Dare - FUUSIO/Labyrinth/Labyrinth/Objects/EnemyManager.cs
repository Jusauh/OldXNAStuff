using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Labyrinth.Engine;

namespace Labyrinth.Objects
{
    class EnemyManager
    {
        private static void LoadEnemyTextures()
        {
            //Recources.LoadTexture("henchman1b");
        }

        private static void Level1Enemies()
        {
            //Henchman
            Enemy.enemyList.Add(new Enemy("enemy", new Vector2(341, 113), 40, 1));
            //BOSS
            Enemy.enemyList.Add(new Enemy("Boss", new Vector2(873, 463), 40, 2, true));
        }

        private static void Level2Enemies()
        {
            //Henchmen
            Enemy.enemyList.Add(new Enemy("enemy", new Vector2(80, 83), 40, 3));
            Enemy.enemyList.Add(new Enemy("enemy", new Vector2(970, 83), 40, 4));
            //BOSS
            Enemy.enemyList.Add(new Enemy("Boss", new Vector2(780, 180), 40, 5, true));
        }

        private static void Level3Enemies()
        {
            //Henchman
            Enemy.enemyList.Add(new Enemy("enemy", new Vector2(977, 50), 70, 6));
            Enemy.enemyList.Add(new Enemy("enemy", new Vector2(433, 144), 40, 7));
            Enemy.enemyList.Add(new Enemy("enemy", new Vector2(48, 48), 40, 8));
            //BOSS
            Enemy.enemyList.Add(new Enemy("Boss", new Vector2(48, 592), 40, 9, true));
        }

        public static void InitEnemies(int x)
        {
            ClearEnemyList();

            if (x == 1)
            {
                Level1Enemies();
            }
            if (x == 2)
            {
                Level2Enemies();
            }
            if (x == 3)
            {
                Level3Enemies();
            }
        }

        private static void ClearEnemyList()
        {
            Enemy.enemyList.Clear();
        }

        public static void Update(float deltaTime, List<Tiles> tiles)
        {
            for (int i = Enemy.enemyList.Count - 1; i >= 0; i--)
            {
                Enemy e = Enemy.enemyList[i];
                e.Update(deltaTime, tiles);
            }
        }

        public static void Draw()
        {
            for (int i = Enemy.enemyList.Count - 1; i >= 0; i--)
            {
                Enemy e = Enemy.enemyList[i];
                e.Draw();
            }
        }
    }
}