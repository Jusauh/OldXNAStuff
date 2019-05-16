using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Parents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Labyrinth.Engine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;

namespace Labyrinth.Objects
{
    class Enemy : MovingObjectParent
    {
        public static List<Enemy> enemyList = new List<Enemy>();
        List<Vector2> paths = new List<Vector2>();

        //bool boss;

        float distance;
        int currentPath = 0;
        float fSpeed;
        int path;

        bool isBoss;

        //Vector2 spawnPoint;

        //float angle;

        private Vector2 destination = new Vector2(586, 113);
        public Vector2 spawnPoint;

        private string texture;

        Animation enemy;
        Animation boss;

        public Enemy(string texture, Vector2 position, float speed, int path, bool isBoss = false)
            : base()
        {
            this.texture = texture;
            this.position = position;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            this.isBoss = isBoss;
            this.spawnPoint = position;
            this.fSpeed = speed;
            this.path = path;

            lastPosition = position;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, (int)Recources.GetTextureWidth(texture), (int)Recources.GetTextureHeight(texture));

            enemy = new Animation(Recources.GetTexture("henchman1b"), new Rectangle(0, 0, 32, 32), 0.2f, 8);
            boss = new Animation(Recources.GetTexture("pomo1c"), new Rectangle(0, 0, 32, 32), 0.2f, 8);
        }

        public void Update(float deltaTime, List<Tiles> tiles)
        {
            if (path == 1)
            {
                Paths.initPath(1);
            }
            else if (path == 2)
            {
                Paths.initPath(2);
            }
            else if (path == 3)
            {
                Paths.initPath(3);
            }
            else if (path == 4)
            {
                Paths.initPath(4);
            }
            else if (path == 5)
            {
                Paths.initPath(5);
            }
            else if (path == 6)
            {
                Paths.initPath(6);
            }
            else if (path == 7)
            {
                Paths.initPath(7);
            }
            else if (path == 8)
            {
                Paths.initPath(8);
            }
            else if (path == 9)
            {
                Paths.initPath(9);
            }

            distance += fSpeed * Vector2.Normalize(Paths.pathList[currentPath]).Length() * deltaTime;

            if (distance >= Paths.pathList[currentPath].Length())
            {
                if (currentPath == Paths.pathList.Count - 1)
                {
                    currentPath = 0;
                }
                else
                    currentPath += 1;

                distance = 0;
            }

            position += Vector2.Normalize(Paths.pathList[currentPath]) * fSpeed * deltaTime;

            if (alive)
            {
                distance += fSpeed * Vector2.Normalize(Paths.pathList[currentPath]).Length() * deltaTime;

                if (distance >= Paths.pathList[currentPath].Length())
                {
                    if (currentPath == Paths.pathList.Count - 1)
                    {
                        currentPath = 0;
                    }
                    else
                        currentPath += 1;

                    distance = 0;
                }

                position += Vector2.Normalize(Paths.pathList[currentPath]) * fSpeed * deltaTime;
                boundingBox.X = (int)position.X;
                boundingBox.Y = (int)position.Y;

                if (CanShoot(angle, position, boundingBox, tiles));
            }

            angle = AngleTo(Paths.pathList[currentPath] + position);
        }

        public void Draw()
        {
            if (isBoss)
            {
                boss.Draw(position, angle);
                //DrawSys.Draw(Recources.GetTexture("henchman1b"), position);
            }
            else
            {
                enemy.Draw(position, angle);
            }

            //DrawSys.Draw(Recources.GetTexture("gaze"), new Vector2((int)position.X - (Recources.GetTexture("enemy").Width / 10), (int)position.Y - (Recources.GetTexture("enemy").Height / 10)));
        }
    }
}
