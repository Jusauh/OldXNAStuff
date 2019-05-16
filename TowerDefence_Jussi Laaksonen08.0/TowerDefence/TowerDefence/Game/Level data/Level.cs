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
    class Level
    {
        //InGame inGame = new InGame();
        Texture2D mapBG;
        List<Wave> waveList = new List<Wave>();
        Wave wave;
        private int currentWave =-1;
        private int waveMax;
        public static int wavesLeft;
        public static int HP, gold = 260;

        public bool victory = false;
        public bool defeat = false;

        public void InitLevel(int level)
        {
            if (level == 1)
            {
                mapBG = Assests.map01;
                waveMax = 20;
                gold += 0;
                HP = 20;

                
                waveList.Add(new Wave(new Enemy(60, 22, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 90, 15, 12));
                waveList.Add(new Wave(new Enemy(100, 76, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 120, 10, 22));
                waveList.Add(new Wave(new Enemy(40, 42, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 90, 10, 18));
                waveList.Add(new Wave(new Enemy(60, 92, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 120, 20, 20));
                waveList.Add(new Wave(new Enemy(140, 400, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 120, 6, 56));

                waveList.Add(new Wave(new Enemy(30, 78, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 60, 15, 25));
                waveList.Add(new Wave(new Enemy(45, 76, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 30, 30, 22));
                waveList.Add(new Wave(new Enemy(90, 242, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 90, 10, 34));
                waveList.Add(new Wave(new Enemy(40, 92, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 60, 40, 15));
                waveList.Add(new Wave(new Enemy(140, 900, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 120, 6, 120));

                waveList.Add(new Wave(new Enemy(70, 162, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 90, 15, 31));
                waveList.Add(new Wave(new Enemy(20, 76, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 120, 10, 42));
                waveList.Add(new Wave(new Enemy(40, 42, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 90, 10, 18));
                waveList.Add(new Wave(new Enemy(60, 92, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 60, 20, 20));
                waveList.Add(new Wave(new Enemy(140, 1400, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 120, 6, 56));

                waveList.Add(new Wave(new Enemy(60, 22, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 90, 15, 12));
                waveList.Add(new Wave(new Enemy(100, 76, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 120, 10, 22));
                waveList.Add(new Wave(new Enemy(40, 42, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 90, 10, 18));
                waveList.Add(new Wave(new Enemy(60, 92, new Vector2(315, -15), LevelPath.Stage1Path(), 1), 60, 20, 20));
                waveList.Add(new Wave(new Enemy(30, 10000, new Vector2(315, -15), LevelPath.Stage1Path(), 2), 120, 1, 1000));
            }
            if (level == 2)
            {
                mapBG = Assests.map02;
                gold += 260;
            }
        }

        public void Update()
        {
            if (currentWave >= 0)
            {
                wave = waveList[currentWave];
                wave.Update();

                if (HP <= 0)
                {
                    defeat = true;
                }

                wavesLeft = waveMax - currentWave;

                for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
                {
                    Enemy temp = Lists.enemyList[i];
                    if (temp.isAlive == false)
                    {
                        gold += wave.value;
                        if (Lists.enemyList.Count == 1 && wave.amountcheck == wave.amount)
                            MusicEngine.ChangeSong(Assests.music01, 180, 1);
                    }
                    if (temp.gotTrough == true)
                    {
                        HP -= 1;
                        gold -= wave.value;
                    }
                }

                //Tarkistaa linnan helat

            }
        }

        public void ChangeWave()
        {
            if (currentWave >= 0)
            {
                if (wave.WaveOver() && currentWave < waveList.Count - 1 && wavesLeft > 0)
                {
                    MusicEngine.ChangeSong(Assests.music02, 120, 1);
                    currentWave += 1;
                    if (currentWave == 14)
                        MusicEngine.ChangeSong(Assests.music03,120,1);
                }
                else if (wave.WaveOver() && currentWave < waveList.Count - 1 && wavesLeft == 0)
                {
                    victory = true;
                }
            }
            else
            {
                currentWave += 1;
                MusicEngine.ChangeSong(Assests.music02, 120, 1);
            }
        }
        

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(mapBG, new Vector2(0, 0), Color.White);
        }
    }
}
