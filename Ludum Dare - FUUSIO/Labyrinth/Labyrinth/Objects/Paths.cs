using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Labyrinth.Objects
{
    class Paths
    {
        public static List<Vector2> pathList = new List<Vector2>();

        //LEVEL 1
        public static void Level1EnemyPath()
        {
            pathList.Add(new Vector2(250, 0));
            pathList.Add(new Vector2(0, 350));
            pathList.Add(new Vector2(-250, 0));
            pathList.Add(new Vector2(0, -350));
        }

        public static void Level1BossPath()
        {
            pathList.Add(new Vector2(-250, 0));
            pathList.Add(new Vector2(0, -350));
            pathList.Add(new Vector2(250, 0));
            pathList.Add(new Vector2(0, 350));
        }

        //LEVEL 2
        public static void Level2EnemyPath1()
        {
            pathList.Add(new Vector2(0, 480));
            pathList.Add(new Vector2(155, 0));
            pathList.Add(new Vector2(0, -350));
            pathList.Add(new Vector2(0, 350));
            pathList.Add(new Vector2(-155, 0));
            pathList.Add(new Vector2(0, -480));
        }

        public static void Level2EnemyPath2()
        {
            pathList.Add(new Vector2(0, 290));
            pathList.Add(new Vector2(-180, 0));
            pathList.Add(new Vector2(0, -180));
            pathList.Add(new Vector2(0, 180));
            pathList.Add(new Vector2(180, 0));
            pathList.Add(new Vector2(0, -290));
        }

        public static void Level2BossPath()
        {
            pathList.Add(new Vector2(-230, 0));
            pathList.Add(new Vector2(0, 185));
            pathList.Add(new Vector2(-150, 0));
            pathList.Add(new Vector2(0, 155));
            pathList.Add(new Vector2(380, 0));
            pathList.Add(new Vector2(0, -340));
        }

        //LEVEL 3
        public static void Level3EnemyPath1()
        {
            pathList.Add(new Vector2(0, 96));
            pathList.Add(new Vector2(-96, 0));
            pathList.Add(new Vector2(0, 415));
            pathList.Add(new Vector2(-287, 0));
            pathList.Add(new Vector2(0, -383));
            pathList.Add(new Vector2(160, 0));
            pathList.Add(new Vector2(0, -128));
            pathList.Add(new Vector2(223, 0));
        }

        public static void Level3EnemyPath2()
        {
            pathList.Add(new Vector2(161, 0));
            pathList.Add(new Vector2(0, 191));
            pathList.Add(new Vector2(-161, 0));
            pathList.Add(new Vector2(0, -191));
        }

        public static void Level3EnemyPath3()
        {
            pathList.Add(new Vector2(0, 273));
            pathList.Add(new Vector2(256, 0));
            pathList.Add(new Vector2(0, -273));
            pathList.Add(new Vector2(-256, 0));
        }

        public static void Level3BossPath()
        {
            pathList.Add(new Vector2(0, -128));
            pathList.Add(new Vector2(448, 0));
            pathList.Add(new Vector2(0, 128));
            pathList.Add(new Vector2(-448, 0));
        }

        public static void initPath(int pathNumber)
        {
            ClearPaths();

            //LEVEL 1
            if (pathNumber == 1)
            {
                Level1EnemyPath();
            }
            else if (pathNumber == 2)
            {
                Level1BossPath();
            }
            //LEVEL 2
            else if (pathNumber == 3)
            {
                Level2EnemyPath1();
            }
            else if (pathNumber == 4)
            {
                Level2EnemyPath2();
            }
            else if (pathNumber == 5)
            {
                Level2BossPath();
            }
            //LEVEL 3
            else if (pathNumber == 6)
            {
                Level3EnemyPath1();
            }
            else if (pathNumber == 7)
            {
                Level3EnemyPath2();
            }
            else if (pathNumber == 8)
            {
                Level3EnemyPath3();
            }
            else if (pathNumber == 9)
            {
                Level3BossPath();
            }
        }

        private static void ClearPaths()
        {
            pathList.Clear();
        }
    }
}