using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence.Engine
{
    class ButtonManager
    {
        private static void MainMenuButtons()
        {
            //Play
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.playButton, Assests.playButton, new Vector2(400, 314), false, new Rectangle(0, 0, 178, 60), new Rectangle(0, 0, 200, 70), new Rectangle(0, 0, 360, 90), Color.Yellow, Color.Green));
            //Options
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.optionsButton, Assests.optionsButton, new Vector2(400, 426), false, new Rectangle(0, 0, 178, 60), new Rectangle(0, 0, 200, 70), new Rectangle(0, 0, 360, 90), Color.Yellow, Color.Green));
            //Exit
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.exitButton, Assests.exitButton, new Vector2(400, 539), false, new Rectangle(0, 0, 178, 60), new Rectangle(0, 0, 200, 70), new Rectangle(0, 0, 360, 90), Color.Yellow, Color.Green));
        }

        private static void InGameButtons() //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        {
            //GO
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.nextWaveButton, Assests.optionsButton, new Vector2(700, 322), false, new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 165, 50), new Rectangle(0, 0, 185, 70), Color.Yellow, Color.Green));
            //Upgrade
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.upgradeButton, Assests.optionsButton, new Vector2(700, 422), false, new Rectangle(0, 0, 178, 60), new Rectangle(0, 0, 165, 50), new Rectangle(0, 0, 185, 70), Color.Yellow, Color.Green));
            //Menu
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.menuButton, Assests.exitButton, new Vector2(700, 522), false, new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 165, 50), new Rectangle(0, 0, 185, 70), Color.Yellow, Color.Green));
            //Archer
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.archerTower, Assests.archerTower, new Vector2(649, 165), false, new Rectangle(0, 180, 50, 120), new Rectangle(0, 0, 50, 120), new Rectangle(0, 0, 50, 120), Color.White, Color.Aquamarine));
            //Knight
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.knightTower, Assests.knightTower, new Vector2(700, 165), false, new Rectangle(0, 180, 50, 120), new Rectangle(0, 0, 50, 120), new Rectangle(0, 0, 50, 120), Color.White, Color.Aquamarine));
            //Wizard
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.wizardTower, Assests.wizardTower, new Vector2(751, 165), false, new Rectangle(0, 180, 50, 120), new Rectangle(0, 0, 50, 120), new Rectangle(0, 0, 50, 120), Color.White, Color.Aquamarine));
            //Tower Buttons Background
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.minus, Assests.minus, new Vector2(700, 165), false, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 154, 122), new Rectangle(0, 0, 154, 122), Color.White, Color.White));
        }

        private static void HudButtons()
        {
            //Menu
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.menuButton, Assests.optionsButton, new Vector2(700, 585), false, new Rectangle(0, 0, 180, 20), new Rectangle(0, 0, 180, 20), new Rectangle(0, 0, 200, 30), Color.Yellow, Color.Green));
            //Upgrade
            //Wizard Tower
            //Warrior Tower
            //Archer Tower
        }

        private static void OptionsMenuButtons() //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        {
            //Back
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.backButton, Assests.backButton, new Vector2(400, 530), false, new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 240, 90), Color.Yellow, Color.Green));
            //Master Volume
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.soundOn, Assests.soundOff, new Vector2(535, 185), false, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), Color.Goldenrod, Color.Gold));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.plus, Assests.plus, new Vector2(490, 185), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 40, 40), Color.Green, Color.Green));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.minus, Assests.minus, new Vector2(230, 185), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 8), new Rectangle(0, 0, 40, 13), Color.Red, Color.Red));
            //Music Volume
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.soundOn, Assests.soundOff, new Vector2(535, 310), false, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), Color.Goldenrod, Color.Gold));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.plus, Assests.playButton, new Vector2(490, 310), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 40, 40), Color.Green, Color.Green));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.minus, Assests.playButton, new Vector2(230, 310), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 8), new Rectangle(0, 0, 40, 13), Color.Red, Color.Red));
            //SFX Volume
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.soundOn, Assests.soundOff, new Vector2(535, 435), false, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), Color.Goldenrod, Color.Gold));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.plus, Assests.plus, new Vector2(490, 435), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 40, 40), Color.Green, Color.Green));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.minus, Assests.minus, new Vector2(230, 435), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 8), new Rectangle(0, 0, 40, 13), Color.Red, Color.Red));
            //Sliders
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.slider, Assests.slider, new Vector2(360, 185), false, new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), Color.Goldenrod, Color.Gold));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.slider, Assests.slider, new Vector2(360, 310), false, new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), Color.Goldenrod, Color.Gold));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.slider, Assests.slider, new Vector2(360, 435), false, new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), Color.Goldenrod, Color.Gold));
        }

        private static void GameMenuButtons() //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        {
            //Resume
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.resumeButton, Assests.backButton, new Vector2(300, 125), false, new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 240, 90), Color.Yellow, Color.Green));
            //Exit to Main Menu
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.exitButton, Assests.backButton, new Vector2(300, 225), false, new Rectangle(0, 0, 178, 60), new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 240, 90), Color.Yellow, Color.Green));
            //Master Volume
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.soundOn, Assests.soundOff, new Vector2(435, 340), false, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), Color.White, Color.White));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.plus, Assests.plus, new Vector2(390, 340), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 40, 40), Color.White, Color.White));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.minus, Assests.minus, new Vector2(130, 340), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 8), new Rectangle(0, 0, 40, 13), Color.White, Color.White));
            //Music Volume
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.soundOn, Assests.soundOff, new Vector2(435, 440), false, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), Color.White, Color.White));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.plus, Assests.playButton, new Vector2(390, 440), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 40, 40), Color.White, Color.White));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.minus, Assests.playButton, new Vector2(130, 440), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 8), new Rectangle(0, 0, 40, 13), Color.White, Color.White));
            //SFX Volume
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.soundOn, Assests.soundOff, new Vector2(435, 540), false, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), Color.White, Color.White));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.plus, Assests.plus, new Vector2(390, 540), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 40, 40), Color.White, Color.White));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.minus, Assests.minus, new Vector2(130, 540), true, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 30, 8), new Rectangle(0, 0, 40, 13), Color.White, Color.White));
            //Sliders
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.slider, Assests.slider, new Vector2(260, 340), false, new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), Color.Fuchsia, Color.FloralWhite));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.slider, Assests.slider, new Vector2(260, 440), false, new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), Color.Fuchsia, Color.FloralWhite));
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.slider, Assests.slider, new Vector2(260, 540), false, new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), new Rectangle(0, 0, 200, 20), Color.Fuchsia, Color.FloralWhite));

            //GO
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.nextWaveButton, Assests.optionsButton, new Vector2(700, 322), false, new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 165, 50), new Rectangle(0, 0, 165, 50), Color.Yellow, Color.Yellow));
            //Upgrade
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.upgradeButton, Assests.optionsButton, new Vector2(700, 422), false, new Rectangle(0, 0, 178, 60), new Rectangle(0, 0, 165, 50), new Rectangle(0, 0, 165, 50), Color.Yellow, Color.Yellow));
            //Menu
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.menuButton, Assests.exitButton, new Vector2(700, 522), false, new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 165, 50), new Rectangle(0, 0, 165, 50), Color.Yellow, Color.Yellow));

            //Archer
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.archerTower, Assests.archerTower, new Vector2(649, 165), false, new Rectangle(0, 180, 50, 120), new Rectangle(0, 0, 50, 120), new Rectangle(0, 0, 50, 120), Color.White, Color.White));
            //Knight
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.knightTower, Assests.knightTower, new Vector2(700, 165), false, new Rectangle(0, 180, 50, 120), new Rectangle(0, 0, 50, 120), new Rectangle(0, 0, 50, 120), Color.White, Color.White));
            //Wizard
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.wizardTower, Assests.wizardTower, new Vector2(751, 165), false, new Rectangle(0, 180, 50, 120), new Rectangle(0, 0, 50, 120), new Rectangle(0, 0, 50, 120), Color.White, Color.White));
            //Tower Buttons Background
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.minus, Assests.minus, new Vector2(700, 165), false, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 154, 122), new Rectangle(0, 0, 154, 122), Color.White, Color.White));
        }

        private static void GameMenuButtons2() //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        {
            //Resume
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.resumeButton, Assests.backButton, new Vector2(300, 200), false, new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 240, 90), Color.Yellow, Color.Green));
            //Exit to Main Menu
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.exitButton, Assests.backButton, new Vector2(300, 300), false, new Rectangle(0, 0, 178, 60), new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 240, 90), Color.Yellow, Color.Green));
            //Options
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.optionsButton, Assests.backButton, new Vector2(300, 400), false, new Rectangle(0, 0, 178, 60), new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 240, 90), Color.Yellow, Color.Green));

            //GO
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.nextWaveButton, Assests.optionsButton, new Vector2(700, 322), false, new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 165, 50), new Rectangle(0, 0, 165, 50), Color.Yellow, Color.Yellow));
            //Upgrade
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.upgradeButton, Assests.optionsButton, new Vector2(700, 422), false, new Rectangle(0, 0, 178, 60), new Rectangle(0, 0, 165, 50), new Rectangle(0, 0, 165, 50), Color.Yellow, Color.Yellow));
            //Menu
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.menuButton, Assests.exitButton, new Vector2(700, 522), false, new Rectangle(0, 0, 160, 60), new Rectangle(0, 0, 165, 50), new Rectangle(0, 0, 165, 50), Color.Yellow, Color.Yellow));

            //Archer
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.archerTower, Assests.archerTower, new Vector2(649, 165), false, new Rectangle(0, 180, 50, 120), new Rectangle(0, 0, 50, 120), new Rectangle(0, 0, 50, 120), Color.White, Color.White));
            //Knight
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.knightTower, Assests.knightTower, new Vector2(700, 165), false, new Rectangle(0, 180, 50, 120), new Rectangle(0, 0, 50, 120), new Rectangle(0, 0, 50, 120), Color.White, Color.White));
            //Wizard
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.wizardTower, Assests.wizardTower, new Vector2(751, 165), false, new Rectangle(0, 180, 50, 120), new Rectangle(0, 0, 50, 120), new Rectangle(0, 0, 50, 120), Color.White, Color.White));
            //Tower Buttons Background
            Lists.onScreenButtonList.Add(new OnScreenButton(Assests.minus, Assests.minus, new Vector2(700, 165), false, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 154, 122), new Rectangle(0, 0, 154, 122), Color.White, Color.White));
        }

        public static void InitButtons(int x)
        {
            ClearButtons();

            if (x == 1)
            {
                MainMenuButtons();
            }
            if (x == 2)
            {
                InGameButtons();
            }
            if (x == 3)
            {
                HudButtons();
            }
            if (x == 4)
            {
                OptionsMenuButtons();
            }
            if (x == 5)
            {
                GameMenuButtons();
            }
            if (x == 6)
            {
                GameMenuButtons2();
            }
        }

        private static void ClearButtons()
        {
            Lists.onScreenButtonList.Clear();
        }

        public static void Update()
        {
            for (int i = Lists.onScreenButtonList.Count - 1; i >= 0; i--)
            {
                OnScreenButton b = Lists.onScreenButtonList[i];
                b.Update();
            }
        }

        public static void Draw(SpriteBatch sb)
        {
            for (int i = Lists.onScreenButtonList.Count - 1; i >= 0; i--)
            {
                OnScreenButton b = Lists.onScreenButtonList[i];
                b.Draw(sb);
            }
        }
    }
}
