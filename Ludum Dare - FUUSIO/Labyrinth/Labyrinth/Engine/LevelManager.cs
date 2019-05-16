using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Labyrinth.Engine;

namespace Labyrinth.Objects
{
    class LevelManager
    {
        // Objects & Variables
        Maps maps;
        Gun gun;
        Player player;

        public Player Player { set { this.player = value; } }

        string mapName;

        private int[,] map;
        private int width, height;
        private const int _size = 32;

        private List<Tiles> tiles;
        private List<LightObject> lightObjects;

        // Properties
        public List<Tiles> Tiles
        {
            get { return tiles; }
        }


        // Constructor
        public LevelManager()
        {
            gun = new Gun(Vector2.Zero);

            mapName = "";
            maps = new Maps();

            width = 0;
            height = 0;

            tiles = new List<Tiles>();
            lightObjects = new List<LightObject>();

            Recources.LoadTexture("LevelOneMap");
            Recources.LoadTexture("LevelTwoMap");
            Recources.LoadTexture("LevelThreeMap");
            Recources.LoadTexture("enemy");
            Recources.LoadTexture("Boss");
            Recources.LoadTexture("henchman1b");
            Recources.LoadTexture("pomo1c");
        }

        // Loads the wanted map, sets it's height and width and makes a list of the tiles
        public void LoadMap(string mapName)
        {
            this.mapName = mapName;
            
            switch (mapName)
            {
                case "LevelOneMap":
                    gun.SetGunPosition(new Vector2(912, 0));
                    map = maps.LevelOne();
                    player.SetPosition(new Vector2(96, Game1.screenSize.Height - 33));
                    EnemyManager.InitEnemies(1);
                    break;
                case "LevelTwoMap":
                    gun.SetGunPosition(new Vector2(864, 481));
                    map = maps.LevelTwo();
                    player.SetPosition(new Vector2(496, Game1.screenSize.Y + 1));
                    EnemyManager.InitEnemies(2);
                    break;
                case "LevelThreeMap":
                    gun.SetGunPosition(new Vector2(352, 224));
                    map = maps.LevelThree();
                    player.SetPosition(new Vector2(Game1.screenSize.Width - 33, 368));
                    EnemyManager.InitEnemies(3);
                    break;
                default:
                    gun.SetGunPosition(new Vector2(912, 0));
                    map = maps.LevelOne();
                    break;
            }

            width = map.GetLength(0) * _size;
            height = map.GetLength(1) * _size;

            gun.OnGround = true;

            tiles.Clear();
            lightObjects.Clear();

            // add new tiles
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    int cell = map[y, x];
                    if (cell > 0)
                    {
                        tiles.Add(new Tiles(new Rectangle(x * _size, y * _size, _size, _size)));
                    }
                }
            }

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    int cell = map[y, x];
                    if (cell == 0)
                    {
                        lightObjects.Add(new LightObject(new Vector2(x * 32, y * 32), tiles));
                        lightObjects.Add(new LightObject(new Vector2(x * 32 + 16, y * 32), tiles));
                        lightObjects.Add(new LightObject(new Vector2(x * 32, y * 32 + 16), tiles));
                        lightObjects.Add(new LightObject(new Vector2(x * 32 + 16, y * 32 + 16
                            ), tiles));
                    }
                }
            }
        }

        // Draw Method
        public void Draw()
        {
            DrawSys.Draw(Recources.GetTexture(this.mapName), Vector2.Zero);

            foreach (Tiles tile in tiles)
            {
                DrawSys.Draw(Recources.GetTexture("Tile"), new Vector2(tile.BoundingBox.X, tile.BoundingBox.Y),Color.Black);
            }

            EnemyManager.Draw();
            gun.Draw();

            foreach (LightObject light in lightObjects)
            {
                light.Draw();
            }
        }

        public void Update(Vector2 playerPosition)
        {
            foreach (LightObject light in lightObjects)
            {
                light.UpdateLightIntencity(playerPosition);
            }

            gun.Update(player);
        }
    }
}
