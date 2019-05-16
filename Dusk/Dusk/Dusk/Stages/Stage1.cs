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
using Dusk.Engine;
using Dusk.EnemyData;
using Dusk.EnemyData.Enemies.Stage01;
using Dusk.EnemyData.Bosses.Boss01;

namespace Dusk.Stages
{
    class Stage1 : Methods
    {
        protected int spawnFrame = 2800;
        protected float posY = 32;
        protected Boss01 boss01;

        public void Update()
        {
            spawnFrame++;


            if (spawnFrame == 60)
            {
                CreateEnemy(new Enemy02(-PlayScreenMinX, 200, PlayScreenMaxX, 200));
            }
            if (spawnFrame == 100)
            {
                CreateEnemy(new Enemy02(-PlayScreenMinX, 200, PlayScreenMaxX, 200));
            }
            if (spawnFrame == 140)
            {
                CreateEnemy(new Enemy02(-PlayScreenMinX, 200, PlayScreenMaxX, 200));
            }
            if (spawnFrame == 180)
            {
                CreateEnemy(new Enemy02(-PlayScreenMinX, 200, PlayScreenMaxX, 200));
            }

            if (spawnFrame == 260)
            {
                CreateEnemy(new Enemy02(PlayScreenMaxX, 100, -PlayScreenMinX, 100));
            }
            if (spawnFrame == 300)
            {
                CreateEnemy(new Enemy02(PlayScreenMaxX, 100, -PlayScreenMinX, 100));
            }
            if (spawnFrame == 340)
            {
                CreateEnemy(new Enemy02(PlayScreenMaxX, 100, -PlayScreenMinX, 100));
            }
            if (spawnFrame == 380)
            {
                CreateEnemy(new Enemy02(PlayScreenMaxX, 100, -PlayScreenMinX, 100));
            }

            if (spawnFrame == 460)
            {
                CreateEnemy(new Enemy02(-PlayScreenMinX, 200, PlayScreenMaxX, 200));
            }
            if (spawnFrame == 500)
            {
                CreateEnemy(new Enemy02(-PlayScreenMinX, 200, PlayScreenMaxX, 200));
            }
            if (spawnFrame == 540)
            {
                CreateEnemy(new Enemy02(-PlayScreenMinX, 200, PlayScreenMaxX, 200));
            }
            if (spawnFrame == 580)
            {
                CreateEnemy(new Enemy02(-PlayScreenMinX, 200, PlayScreenMaxX, 200));
            }

            if (spawnFrame == 660)
            {
                CreateEnemy(new Enemy02(PlayScreenMaxX, 100, -PlayScreenMinX, 100));
            }
            if (spawnFrame == 700)
            {
                CreateEnemy(new Enemy02(PlayScreenMaxX, 100, -PlayScreenMinX, 100));
            }
            if (spawnFrame == 740)
            {
                CreateEnemy(new Enemy02(PlayScreenMaxX, 100, -PlayScreenMinX, 100));
            }
            if (spawnFrame == 780)
            {
                CreateEnemy(new Enemy02(PlayScreenMaxX, 100, -PlayScreenMinX, 100));
            }
            if (spawnFrame == 960)
            {
                CreateEnemy(new Enemy03(GetCenterX, 100));
            }
            if (spawnFrame == 1260)
            {
                CreateEnemy(new Enemy03(GetCenterX - 150, 100));
                CreateEnemy(new Enemy03(GetCenterX + 150, 100));
            }
            if (spawnFrame == 1800)
            {
                CreateEnemy(new Enemy05(-PlayScreenMinX, 60, PlayScreenMinX, 60));
                CreateEnemy(new Enemy05(PlayScreenMaxX, 60, PlayScreenMaxX - PlayScreenMinX * 2, 60));
            }
            if (spawnFrame == 1815)
            {
                CreateEnemy(new Enemy05(-PlayScreenMinX, 60, PlayScreenMinX + 50, 50));
                CreateEnemy(new Enemy05(PlayScreenMaxX, 60, PlayScreenMaxX - PlayScreenMinX * 2 - 50, 50));
            }
            if (spawnFrame == 1830)
            {
                CreateEnemy(new Enemy05(-PlayScreenMinX, 60, PlayScreenMinX + 100, 40));
                CreateEnemy(new Enemy05(PlayScreenMaxX, 60, PlayScreenMaxX - PlayScreenMinX * 2 - 100, 40));
            }
            if (spawnFrame == 1845)
            {
                CreateEnemy(new Enemy05(-PlayScreenMinX, 60, PlayScreenMinX + 150, 30));
                CreateEnemy(new Enemy05(PlayScreenMaxX, 60, PlayScreenMaxX - PlayScreenMinX * 2 - 150, 30));
            }
            if (spawnFrame == 1860)
            {
                CreateEnemy(new Enemy05(-PlayScreenMinX, 60, PlayScreenMinX + 200, 20));
                CreateEnemy(new Enemy05(PlayScreenMaxX, 60, PlayScreenMaxX - PlayScreenMinX * 2 - 200, 20));
            }

            if (spawnFrame == 2180)
            {
                CreateEnemy(new Enemy04(GetCenterX, 120));
            }


            if (spawnFrame == 2900)
            {
                boss01 = new Boss01();
                ClearBullets(false);
            }
            if (spawnFrame >= 2900 )
            {
                if(boss01.GetAlive())
                boss01.Update();
            }



            if (Input.IsKeyPressed(Keys.R))
            {
                spawnFrame = 0;
            }
            
        }

        public void Draw(SpriteBatch sb)
        {
            posY += 0.6f;

            if(posY >= PlayScreenMaxY)
            {
                posY = PlayScreenMinY;
            }
            sb.Draw(Assets.stage01BG, new Vector2(PlayScreenMinX, posY), Color.White);
            sb.Draw(Assets.stage01BG, new Vector2(PlayScreenMinX, posY-Assets.stage01BG.Height), Color.White);
        }



    }
}
