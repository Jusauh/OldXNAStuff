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
using TowerDefence.Engine;
using TowerDefence.Game.Tower_data;
using TowerDefence.Game.Enemy_data;
using TowerDefence.Game.Level_data;

namespace TowerDefence.Game.Level_data
{
    class Wave
    {
        int intervall, frame;
        public int amount, amountcheck;
        public int value;
        public bool isWaveOver = false;
        Enemy enemy;


        public Wave(Enemy enemy, int intervall, int amount, int value)
        {
            this.enemy = enemy;
            this.intervall = intervall;
            this.amount = amount;
            this.value = value;
        }

        public void Update()
        {
            frame--;
            if (frame <= 0 && amount != amountcheck)
            {
                frame = intervall;
                amountcheck += 1;
                Lists.enemyList.Add(new Enemy(enemy.speed,enemy.HP,enemy.position,enemy.path,enemy.type));
            }
            if (frame < amountcheck * -10)
            {
                isWaveOver = true;
            }
        }
        private bool SpawnedAllEnemies()
        {
            if (amount == amountcheck)
                return true;
            else
                return false;
        }
        public bool WaveOver()
        {
            if (SpawnedAllEnemies() && Lists.enemyList.Count == 0)
                return true;
            else
                return false;
        }
    }
}
