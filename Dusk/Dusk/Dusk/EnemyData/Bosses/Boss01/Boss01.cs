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

namespace Dusk.EnemyData.Bosses.Boss01
{
    class Boss01 : Methods
    {
        bool patternAlive,bossAlive = true;
        int currentPattern;
        Vector2 bossPosition = new Vector2(0,0);

        public Boss01()
        {
            CreateEnemy(new Pattern01());
            currentPattern = 1;
        }
        public void Update()
        {
            patternAlive = false;
            for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
            {
                EnemyPrime enemy = Lists.enemyList[i];
                if (enemy.GetBoss())
                {
                    patternAlive = true;
                    bossPosition = new Vector2(enemy.GetRealX(), enemy.GetRealY());
                }
            }
            if (Lists.enemyList.Count == 0 || patternAlive == false)
            {
                currentPattern += 1;
            }


            if (patternAlive == false)
            {
                if (currentPattern == 2)
                {
                    ClearBullets(true);
                    CreateEnemy(new Pattern02(bossPosition));
                }
                else if (currentPattern == 3)
                {
                    ClearBullets(true);
                    CreateEnemy(new Pattern03(bossPosition));
                }
                else if (currentPattern == 4)
                {
                    ClearBullets(true);
                    CreateEnemy(new Pattern04(bossPosition));
                }
                else if (currentPattern == 5)
                {
                    ClearBullets(true);
                    CreateEnemy(new Pattern05(bossPosition));
                }
                else if (currentPattern == 6)
                {
                    ClearBullets(true);
                    CreateEnemy(new Pattern06(bossPosition));
                }
                else if (currentPattern == 7)
                {
                    ClearBullets(true);
                    CreateEnemy(new Pattern07(bossPosition));
                }
                else
                {
                    ClearBullets(true);
                    bossAlive = false;
                }
            }
        }
        public bool GetAlive()
        {
            return bossAlive;
        }
    }
}
