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
namespace TowerDefence.Game
{
    class InGame
    {
        protected enum PlayState {Playing, Paused, Victory, Defeat};
        PlayState playState = new PlayState();

        protected enum GameState {Free, Building, TargetingTower, TargetingEnemy};
        GameState gameState = new GameState();

        public static int towerType;
        protected int targetState = 1;
        bool initialised = false, init = false;

        int testFrame;
        int testFrame2;

        int replace1 = 0;
        int replace2 = 0;
        int replace3 = 0;

        Vector2[] test;
        Level level = new Level();

        public InGame()
        {
            playState = PlayState.Playing;
            gameState = GameState.Free;
        }

        public void Initialise()
        {
            if (!initialised)
            {
                ButtonManager.InitButtons(2);
                FontManager.InitFonts(2);

                test = BuildableTerrain.GetTerrain(1);
                initialised = true;

                if (MainLoop.gameState == MainLoop.GameState.inGame || MainLoop.gameState == MainLoop.GameState.options)
                {
                    initialised = false;
                }
            }
        }
        public void Init()
        {
            if (!init)
            {
                level.InitLevel(1);
                init = true;
            }
        }
        /// <summary>
        /// Tällä pyöritetään pelin logiikkaa
        /// </summary>
        /// 
        public void Update()
        {
            Initialise();



            switch (playState)
            {
                case PlayState.Playing:
                    GameUpdate();
                    break;
                case PlayState.Paused:
                    GamePausedUpdate();
                    ButtonsUpdatePaused();
                    break;
                case PlayState.Victory:
                    FontManager.InitFonts(7);
                    if (Input.IsKeyPressed(Keys.Enter))
                    {
                        MainLoop.gameState = MainLoop.GameState.mainMenu;
                    }
                    break;
                case PlayState.Defeat:
                    FontManager.InitFonts(8);
                    if (Input.IsKeyPressed(Keys.Enter))
                    {
                        MainLoop.gameState = MainLoop.GameState.mainMenu;
                    }
                    break;
            }
        }

        /// <summary>
        /// Piiretään mitä pelin sisällä tapahtuu
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            Init();
            level.Draw(sb);

            //Tässä piirretään HUD
            sb.Draw(Assests.hud, new Vector2(600, 0), Color.White);

            switch (playState)
            {
                case PlayState.Playing:
                    PlayingDraw(sb);
                    ButtonManager.Draw(sb);
                    FontManager.Draw(sb);
                    break;
                case PlayState.Paused:
                    PlayingDraw(sb);
                    ButtonManager.Draw(sb);
                    FontManager.Draw(sb);
                    break;
                case PlayState.Victory:
                    PlayingDraw(sb);
                    ButtonManager.Draw(sb);
                    FontManager.Draw(sb);
                    break;
                case PlayState.Defeat:
                    PlayingDraw(sb);
                    ButtonManager.Draw(sb);
                    FontManager.Draw(sb);
                    break;
            }

            
        }

        /// <summary>
        /// Tässä pyörii kaikki mitä piiretään kun peliä ei ole pausetettu
        /// </summary>
        public void PlayingDraw(SpriteBatch sb)
        {
            //Maassa olevat partikkelit muun tavaran alle
            ParticleEngine.Draw(sb, 2);
            //Archer
            for (int i = Lists.towerArcherList.Count - 1; i >= 0; i--)
            {
                TowerArcher towerArch = Lists.towerArcherList[i];
                towerArch.Draw(sb);
            }
            //Knight
            for (int i = Lists.towerKnightList.Count - 1; i >= 0; i--)
            {
                TowerKnight towerKnig = Lists.towerKnightList[i];
                towerKnig.Draw(sb);
            }
            //Wizard
            for (int i = Lists.towerWizardList.Count - 1; i >= 0; i--)
            {
                TowerWizad towerWiz = Lists.towerWizardList[i];
                towerWiz.Draw(sb);
            }
            //Enemy
            for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
            {
                Enemy enemy = Lists.enemyList[i];
                enemy.Draw(sb);
            }
            //Projectile
            for (int i = Lists.projectileList.Count - 1; i >= 0; i--)
            {
                Projectile projectile = Lists.projectileList[i];
                projectile.Draw(sb);
            }
        }

        /// <summary>
        /// Tämä on pelin pää update, tässä pyörii eri tilojen vaihdot
        /// </summary>
        protected void GameUpdate()
        {
            testFrame++;
            testFrame2++;
            switch (gameState)
            {
                case GameState.Free: //Vapaa kursori
                    FreeState();
                    break;
                case GameState.Building: //Rakennetaan tornia
                    BuildTowerState();
                    break;
                case GameState.TargetingTower://Päivitetään tornia
                    break;
                case GameState.TargetingEnemy://Targetoidaan vihollista
                    break;
            }

            //Archer
            for (int i = Lists.towerArcherList.Count - 1; i >= 0; i--)
            {
                TowerArcher towerArch = Lists.towerArcherList[i];
                towerArch.Update();
            }
            //Knight
            for (int i = Lists.towerKnightList.Count - 1; i >= 0; i--)
            {
                TowerKnight towerKnig = Lists.towerKnightList[i];
                towerKnig.Update();
            }
            //Wizard
            for (int i = Lists.towerWizardList.Count - 1; i >= 0; i--)
            {
                TowerWizad towerWiz = Lists.towerWizardList[i];
                towerWiz.Update();
            }

            //Enemy
            for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
            {
                Enemy enemy = Lists.enemyList[i];
                enemy.Update();
            }
            //Projectile
            for (int i = Lists.projectileList.Count - 1; i >= 0; i--)
            {
                Projectile projectile = Lists.projectileList[i];
                projectile.Update();
            }

            //Asettaa voiton
            if (level.victory == true)
            {
                Victory();
            }

            //Asettaa häviön
            if (level.defeat == true)
            {
                Defeat();
            }

            level.Update();
            ButtonsUpdatePlaying();
        }

        /// <summary>
        /// Tässä pyörii kaikki logiika mitä tapahtuu kun kursori on vapaana
        /// </summary>
        protected void FreeState()
        {
            //Pause game
            if (Input.IsKeyPressed(Keys.P))
            {
                playState = PlayState.Paused;
            }
            //Archer
            if (Input.IsKeyPressed(Keys.A))
            {
                StartBuilding(1);
            }
            //Knight
            if (Input.IsKeyPressed(Keys.S))
            {
                StartBuilding(2);
            }
            //Wizard
            if (Input.IsKeyPressed(Keys.D))
            {
                StartBuilding(3);
            }
            //Aloita aalto
            if(Input.IsKeyPressed(Keys.Enter))
            {
                level.ChangeWave();
            }
            //Vaihda kenttää
            if (Input.IsKeyPressed(Keys.L))
            {
                level.InitLevel(2);
            }
            //Vaihda kenttää
            if (Input.IsKeyPressed(Keys.K))
            {
                level.InitLevel(1);
            }
            //Voitto chiitti
            if (Input.IsKeyPressed(Keys.T))
            {
                Victory();
            }
            //Häviö chiitti
            if (Input.IsKeyPressed(Keys.Y))
            {
                Defeat();
            }
            if (Input.IsKeyPressed(Keys.B))
            {
                Level.HP -= 1;
            }

            ButtonsUpdatePlaying();
        }

        /// <summary>
        /// Tätä kutsumalla siirymme BuildTowerStateen ja aloitamme tornin rakentamisen
        /// </summary>
        protected void StartBuilding(int _towerType)
        {
            towerType = _towerType;
            gameState = GameState.Building;
        }

        /// <summary>
        /// Tässä pyöritämme kaikkea rakentamiseen liittyvää logiikkaa
        /// </summary>
        protected void BuildTowerState()
        {
            bool canBuild = true;

            foreach (TowerArcher towerArch in Lists.towerArcherList)
            {
                if (towerArch.position == Input.gridPosition(Input.MousePosition()))
                {
                    canBuild = false;
                }
            }
            foreach (TowerKnight towerKnig in Lists.towerKnightList)
            {
                if (towerKnig.position == Input.gridPosition(Input.MousePosition()))
                {
                    canBuild = false;
                }
            }
            foreach (TowerWizad towerWiz in Lists.towerWizardList)
            {
                if (towerWiz.position == Input.gridPosition(Input.MousePosition()))
                {
                    canBuild = false;
                }
            }
            foreach (Vector2 t in test)
            {
                if (t == Input.gridPosition(Input.MousePosition()))
                {
                    canBuild = false;
                }
            }
            if (Input.MouseLeftPressed() && Input.CursorOverArea(new Rectangle(0,0,600,600)))
            {
                //Archer
                if (towerType == 1 && canBuild == true  && Level.gold >= 100)
                {
                    Level.gold -= 100;
                    Lists.towerArcherList.Add(new TowerArcher(Input.gridPosition(Input.MousePosition())));
                }
                //Knight
                else if (towerType == 2 && canBuild == true && Level.gold >= 160)
                {
                    Level.gold -= 160;
                    Lists.towerKnightList.Add(new TowerKnight(Input.gridPosition(Input.MousePosition())));
                }
                //Wizard
                else if (towerType == 3 && canBuild == true && Level.gold >= 300)
                {
                    Level.gold -= 300;
                    Lists.towerWizardList.Add(new TowerWizad(Input.gridPosition(Input.MousePosition())));
                }
                gameState = GameState.Free;
            }
            if (Input.IsKeyPressed(Keys.Escape))
                gameState = GameState.Free;
        }

        /// <summary>
        /// Tässä pyörii kaikkea pausen liittyvää logiikaa
        /// </summary>
        protected void GamePausedUpdate()
        {
            if (Input.IsKeyPressed(Keys.P) || Input.IsKeyPressed(Keys.Escape))
            {
                playState = PlayState.Playing;
            }

            ButtonManager.InitButtons(6);//OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            FontManager.InitFonts(6);

            ButtonsUpdatePaused();
        }

        protected void ButtonsUpdatePlaying()
        {
            ButtonManager.Update();

            //Playing Buttons:

            //Next  Wave Button
            if (Lists.onScreenButtonList[0].pressed == true)
            {
                level.ChangeWave();
            }
            //Upgrade Button, Archer
            for (int i = Lists.towerArcherList.Count - 1; i >= 0; i--)
            {
                if (Lists.onScreenButtonList[1].pressed == true && Lists.towerArcherList[i].isTargeted == true && Level.gold >= Lists.towerArcherList[i].value)
                {
                    Level.gold -= Lists.towerArcherList[i].value;
                    Lists.towerArcherList[i].Upgrade();
                }
            }
            //Upgrade Button, Knight
            for (int i = Lists.towerKnightList.Count - 1; i >= 0; i--)
            {
                if (Lists.onScreenButtonList[1].pressed == true && Lists.towerKnightList[i].isTargeted == true && Level.gold >= Lists.towerKnightList[i].value)
                {
                    Level.gold -= Lists.towerKnightList[i].value;
                    Lists.towerKnightList[i].Upgrade();
                }
            }
            //Upgrade Button, Wizard
            for (int i = Lists.towerWizardList.Count - 1; i >= 0; i--)
            {
                if (Lists.onScreenButtonList[1].pressed == true && Lists.towerWizardList[i].isTargeted == true && Level.gold >= Lists.towerWizardList[i].value)
                {
                    Level.gold -= Lists.towerWizardList[i].value;
                    Lists.towerWizardList[i].Upgrade();
                }
            }
            //Menu Button
            if ((Lists.onScreenButtonList[2].pressed == true) || (Input.IsKeyPressed(Keys.Escape)))
            {
                playState = PlayState.Paused;
            }

            //Building Buttons:

            //Archer
            if ((Lists.onScreenButtonList[3].pressed == true))
            {
                StartBuilding(1);
            }
            //Knight
            if ((Lists.onScreenButtonList[4].pressed == true))
            {
                StartBuilding(2);
            }
            //Wizard
            if ((Lists.onScreenButtonList[5].pressed == true))
            {
                StartBuilding(3);
            }

            FontManager.Update();
        }

        protected void ButtonsUpdatePaused() //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        {
            ButtonManager.Update();
            FontManager.Update();

            //Resume
            if (Lists.onScreenButtonList[0].pressed == true)
            {
                playState = PlayState.Playing;
            }
            //Exit to Main Menu
            if (Lists.onScreenButtonList[1].pressed == true)
            {
                MainLoop.gameState = MainLoop.GameState.mainMenu;
            }
            if (Lists.onScreenButtonList[2].pressed == true)
            {
                Options.whereTo = 2;

                MainLoop.gameState = MainLoop.GameState.options;
            }


            //ÄLÄ VÄLITÄ TUOSTA
            //       |
            //       |
            //       |
            //       |
            //       |
            //       V


            ////KOSKA NAPIT EI TOIMI ON NÄPPÄIMET (ainaki master volyymille)

            ////Increase
            //if (Input.IsKeyDown(Keys.I))
            //{
            //    MasterVolume.masterVolume += 0.01f;

            //    if (FontManager.masterVolumeNumbers != 100)
            //    {
            //        FontManager.masterVolumeNumbers++;
            //    }

            //    Lists.fontList[2].replaceOutput(FontManager.masterVolumeNumbers.ToString());
            //}
            ////Decrease
            //if (Input.IsKeyDown(Keys.U))
            //{
            //    MasterVolume.masterVolume -= 0.01f;

            //    if (FontManager.masterVolumeNumbers != 0)
            //    {
            //        FontManager.masterVolumeNumbers--;
            //    }

            //    Lists.fontList[2].replaceOutput(FontManager.masterVolumeNumbers.ToString());
            //}
            ////Mute
            //if (Input.IsKeyDown(Keys.O))
            //{
            //    if (replace1 == 0)
            //    {
            //        MasterVolume.MuteMasterVolume(true);

            //        Lists.onScreenButtonList[2].useNewTexture = true;
            //        replace1 = 1;
            //    }
            //    else if (replace1 == 1)
            //    {
            //        MasterVolume.MuteMasterVolume(false);

            //        Lists.onScreenButtonList[2].useNewTexture = false;
            //        replace1 = 0;
            //    }
            //}
            ////Tällä pääsee main menuun
            //if (Input.IsKeyPressed(Keys.M))
            //{
            //    MainLoop.gameState = MainLoop.GameState.mainMenu;
            //}








            ////Resume
            //if (Lists.onScreenButtonList[0].pressed == true)
            //{
            //    playState = PlayState.Playing;
            //}
            ////Exit to Main Menu
            //if (Lists.onScreenButtonList[1].pressed == true)
            //{
            //    MainLoop.gameState = MainLoop.GameState.mainMenu;
            //}
            ////Master Volume
            ////Mute
            //if (Lists.onScreenButtonList[2].pressed == true)
            //{
            //    if (replace1 == 0)
            //    {
            //        MasterVolume.MuteMasterVolume(true);

            //        Lists.onScreenButtonList[2].useNewTexture = true;
            //        replace1 = 1;
            //    }
            //    else if (replace1 == 1)
            //    {
            //        MasterVolume.MuteMasterVolume(false);

            //        Lists.onScreenButtonList[2].useNewTexture = false;
            //        replace1 = 0;
            //    }
            //}
            ////Increase
            //if (Lists.onScreenButtonList[3].pressed == true)
            //{
            //    MasterVolume.masterVolume += 0.01f;

            //    if (FontManager.masterVolumeNumbers != 100)
            //    {
            //        FontManager.masterVolumeNumbers++;
            //    }

            //    Lists.fontList[2].replaceOutput(FontManager.masterVolumeNumbers.ToString());
            //}
            ////Decrease
            //if (Lists.onScreenButtonList[4].pressed == true)
            //{
            //    MasterVolume.masterVolume -= 0.01f;

            //    if (FontManager.masterVolumeNumbers != 0)
            //    {
            //        FontManager.masterVolumeNumbers--;
            //    }

            //    Lists.fontList[2].replaceOutput(FontManager.masterVolumeNumbers.ToString());
            //}
            ////Music Volume
            ////Mute
            //if (Lists.onScreenButtonList[5].pressed == true)
            //{
            //    if (replace2 == 0)
            //    {
            //        MusicEngine.MuteMusic(true);

            //        Lists.onScreenButtonList[5].useNewTexture = true;
            //        replace2 = 1;
            //    }
            //    else if (replace2 == 1)
            //    {
            //        MusicEngine.MuteMusic(false);

            //        Lists.onScreenButtonList[5].useNewTexture = false;
            //        replace2 = 0;
            //    }
            //}
            ////Increase
            //if (Lists.onScreenButtonList[6].pressed == true)
            //{
            //    if (MusicEngine.volumeLoudnes != 1)
                  //{
                  //    MusicEngine.volumeLoudnes += 0.01f;
                  //}
            //    if (FontManager.musicVolumeNumbers != 100)
            //    {
            //        FontManager.musicVolumeNumbers++;
            //    }

            //    Lists.fontList[5].replaceOutput(FontManager.musicVolumeNumbers.ToString());
            //}
            ////Decrease
            //if (Lists.onScreenButtonList[7].pressed == true)
            //{
            //    if (MusicEngine.volumeLoudnes >= 0.01f)
                  //{
                  //    MusicEngine.volumeLoudnes -= 0.01f;
                  //}

            //    if (FontManager.musicVolumeNumbers != 0)
            //    {
            //        FontManager.musicVolumeNumbers--;
            //    }

            //    Lists.fontList[5].replaceOutput(FontManager.musicVolumeNumbers.ToString());
            //}
            ////Sound Effect Volume
            ////Mute
            //if (Lists.onScreenButtonList[8].pressed == true)
            //{
            //    SFXEngine.PlaySFX(Assests.soundEffect01);

            //    if (replace3 == 0)
            //    {
            //        SFXEngine.MuteSFX(true);

            //        Lists.onScreenButtonList[8].useNewTexture = true;
            //        replace3 = 1;
            //    }
            //    else if (replace3 == 1)
            //    {
            //        SFXEngine.MuteSFX(false);

            //        Lists.onScreenButtonList[8].useNewTexture = false;
            //        replace3 = 0;
            //    }
            //}
            ////Increase
            //if (Lists.onScreenButtonList[9].pressed == true)
            //{
            //    SFXEngine.PlaySFX(Assests.soundEffect01);

            //    SFXEngine.sfxVolume += 0.01f;

            //    if (FontManager.sfxVolumeNumbers != 100)
            //    {
            //        FontManager.sfxVolumeNumbers++;
            //    }

            //    Lists.fontList[8].replaceOutput(FontManager.sfxVolumeNumbers.ToString());
            //}
            ////Decrease
            //if (Lists.onScreenButtonList[10].pressed == true)
            //{
            //    SFXEngine.PlaySFX(Assests.soundEffect01);

            //    SFXEngine.sfxVolume -= 0.01f;

            //    if (FontManager.sfxVolumeNumbers != 0)
            //    {
            //        FontManager.sfxVolumeNumbers--;
            //    }

            //    Lists.fontList[8].replaceOutput(FontManager.sfxVolumeNumbers.ToString());
            //}
        }

        //public void setPlayStateToVictory()
        //{
        //    playState = PlayState.Victory;
        //}

        //public void setPlayStateToDefeat()
        //{
        //    playState = PlayState.Defeat;
        //}

        public void Victory()
        {
            playState = PlayState.Victory;
        }

        public void Defeat()
        {
            MusicEngine.PlayMusic(Assests.music04);
            playState = PlayState.Defeat;
        }
    }
}
