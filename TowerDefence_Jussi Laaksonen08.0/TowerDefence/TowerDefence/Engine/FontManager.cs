using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TowerDefence.Game.Level_data;

namespace TowerDefence.Engine
{
    class FontManager
    {
        //Täältä löytyy kaikki fontit

        public static int masterVolumeNumbers = 100;
        public static int musicVolumeNumbers = 100;
        public static int sfxVolumeNumbers = 100;

        //public static int gold = level.gold;

        private static void MainMenuFonts()
        {
            //Title Name
            //Lists.fontList.Add(new Font(Assests.Font32, "Torni Defenssi", new Vector2(400, 100), Color.Red, 0));
        }

        private static void InGameFonts() //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        {
            //Wave
            Lists.fontList.Add(new Font(Assests.Font24, Level.wavesLeft.ToString(), new Vector2(680, 25), Color.Black, 0));
            //Helth
            Lists.fontList.Add(new Font(Assests.Font24, Level.HP.ToString(), new Vector2(750, 25), Color.DarkRed, 0));
            //Gold
            Lists.fontList.Add(new Font(Assests.Font24, Level.gold.ToString(), new Vector2(730, 69), Color.Gold, 0));
            //Tower values
            Lists.fontList.Add(new Font(Assests.Font14, "100     160    300", new Vector2(700, 239), Color.Gold, 0));
            //Decorative
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 262), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 262), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 372), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 472), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 572), Color.Black, 0));
        }

        private static void HudFonts()
        {
            //Move along.
        }

        private static void OptionsMenuFonts() //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        {
            //Options
            Lists.fontList.Add(new Font(Assests.Font32, "***************************", new Vector2(400, 100), Color.Goldenrod, 0));
            //Master Volume   x%
            Lists.fontList.Add(new Font(Assests.Font24, "Master Volume", new Vector2(400, 145), Color.DarkOrange, 0));
            Lists.fontList.Add(new Font(Assests.Font14, masterVolumeNumbers.ToString(), new Vector2(350, 187.5f), Color.Black, 0));
            Lists.fontList.Add(new Font(Assests.Font14, "%", new Vector2(375, 187.5f), Color.Black, 0));
            //Music Volume   x%
            Lists.fontList.Add(new Font(Assests.Font24, "Music Volume", new Vector2(400, 270), Color.DarkOrange, 0));
            Lists.fontList.Add(new Font(Assests.Font14, musicVolumeNumbers.ToString(), new Vector2(350, 312.5f), Color.Black, 0));
            Lists.fontList.Add(new Font(Assests.Font14, "%", new Vector2(375, 312.5f), Color.Black, 0));
            //Sound Effects Volume   x%
            Lists.fontList.Add(new Font(Assests.Font24, "Sound Effect Volume", new Vector2(400, 395), Color.DarkOrange, 0));
            Lists.fontList.Add(new Font(Assests.Font14, sfxVolumeNumbers.ToString(), new Vector2(350, 437.5f), Color.Black, 0));
            Lists.fontList.Add(new Font(Assests.Font14, "%", new Vector2(375, 437.5f), Color.Black, 0));
        }

        private static void GameMenuFonts() //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        {
            //Game Menu
            Lists.fontList.Add(new Font(Assests.Font40, "Menu", new Vector2(300, 50), Color.Red, 0));
            //Master Volume   x%
            Lists.fontList.Add(new Font(Assests.Font24, "Master Volume", new Vector2(300, 300), Color.White, 0));
            Lists.fontList.Add(new Font(Assests.Font14, masterVolumeNumbers.ToString(), new Vector2(250, 342.5f), Color.Black, 0));
            Lists.fontList.Add(new Font(Assests.Font14, "%", new Vector2(275, 342.5f), Color.Black, 0));
            //Music Volume   x%
            Lists.fontList.Add(new Font(Assests.Font24, "Music Volume", new Vector2(300, 400), Color.White, 0));
            Lists.fontList.Add(new Font(Assests.Font14, musicVolumeNumbers.ToString(), new Vector2(250, 442.5f), Color.Black, 0));
            Lists.fontList.Add(new Font(Assests.Font14, "%", new Vector2(275, 442.5f), Color.Black, 0));
            //Sound Effects Volume   x%
            Lists.fontList.Add(new Font(Assests.Font24, "Sound Effect Volume", new Vector2(300, 500), Color.White, 0));
            Lists.fontList.Add(new Font(Assests.Font14, sfxVolumeNumbers.ToString(), new Vector2(250, 542.5f), Color.Black, 0));
            Lists.fontList.Add(new Font(Assests.Font14, "%", new Vector2(275, 542.5f), Color.Black, 0));
            //Wave
            Lists.fontList.Add(new Font(Assests.Font24, Level.wavesLeft.ToString(), new Vector2(680, 25), Color.Black, 0));
            //Helth
            Lists.fontList.Add(new Font(Assests.Font24, Level.HP.ToString(), new Vector2(750, 25), Color.DarkRed, 0));
            //Gold
            Lists.fontList.Add(new Font(Assests.Font24, Level.gold.ToString(), new Vector2(730, 69), Color.Gold, 0));
            //Tower values
            Lists.fontList.Add(new Font(Assests.Font14, "100     160    300", new Vector2(700, 239), Color.Gold, 0));
            //Decorative
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 262), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 372), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 472), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 572), Color.Black, 0));
        }

        private static void GameMenuFonts2() //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        {
            //Game Menu
            Lists.fontList.Add(new Font(Assests.Font40, "Menu", new Vector2(300, 100), Color.Red, 0));
            //Wave
            Lists.fontList.Add(new Font(Assests.Font24, Level.wavesLeft.ToString(), new Vector2(680, 25), Color.Black, 0));
            //Helth
            Lists.fontList.Add(new Font(Assests.Font24, Level.HP.ToString(), new Vector2(750, 25), Color.DarkRed, 0));
            //Gold
            Lists.fontList.Add(new Font(Assests.Font24, Level.gold.ToString(), new Vector2(730, 69), Color.Gold, 0));
            //Tower values
            Lists.fontList.Add(new Font(Assests.Font14, "100     160    300", new Vector2(700, 239), Color.Gold, 0));
            //Decorative
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 262), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 372), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 472), Color.Black, 0));
            //Lists.fontList.Add(new Font(Assests.Font32, "~~~~~~~~", new Vector2(700, 572), Color.Black, 0));
        }

        private static void VictoryFonts()
        {
            //Wave
            Lists.fontList.Add(new Font(Assests.Font24, Level.wavesLeft.ToString(), new Vector2(680, 25), Color.Black, 0));
            //Helth
            Lists.fontList.Add(new Font(Assests.Font24, Level.HP.ToString(), new Vector2(750, 25), Color.DarkRed, 0));
            //Gold
            Lists.fontList.Add(new Font(Assests.Font24, Level.gold.ToString(), new Vector2(730, 69), Color.Black, 0));
            //Victory text
            Lists.fontList.Add(new Font(Assests.Font24, "You are Victorious!", new Vector2(300, 287.5f), Color.Red, 0));
            Lists.fontList.Add(new Font(Assests.Font14, "Please press Enter to continue.", new Vector2(300, 312.5f), Color.Red, 0));
        }

        private static void DefeatFonts()
        {
            //Wave
            Lists.fontList.Add(new Font(Assests.Font24, Level.wavesLeft.ToString(), new Vector2(680, 25), Color.Black, 0));
            //Helth
            Lists.fontList.Add(new Font(Assests.Font24, Level.HP.ToString(), new Vector2(750, 25), Color.DarkRed, 0));
            //Gold
            Lists.fontList.Add(new Font(Assests.Font24, Level.gold.ToString(), new Vector2(730, 69), Color.Black, 0));
            //Victory text
            Lists.fontList.Add(new Font(Assests.Font24, "You have been Defeated!", new Vector2(300, 287.5f), Color.Red, 0));
            Lists.fontList.Add(new Font(Assests.Font14, "Please press Enter to continue.", new Vector2(300, 312.5f), Color.Red, 0));
        }

        public static void InitFonts(int x)
        {
            ClearFonts();

            if (x == 1)
            {
                MainMenuFonts();
            }
            if (x == 2)
            {
                InGameFonts();
            }
            if (x == 3)
            {
                HudFonts();
            }
            if (x == 4)
            {
                OptionsMenuFonts();
            }
            if (x == 5)
            {
                GameMenuFonts();
            }
            if (x == 6)
            {
                GameMenuFonts2();
            }
            if (x == 7)
            {
                VictoryFonts();
            }
            if (x == 8)
            {
                DefeatFonts();
            }
        }

        private static void ClearFonts()
        {
            Lists.fontList.Clear();
        }

        public static void Update()
        {
            for (int i = Lists.fontList.Count - 1; i >= 0; i--)
            {
                Font f = Lists.fontList[i];
                f.Update();
            }

            if (masterVolumeNumbers <= 0)
            {
                masterVolumeNumbers = 0;
            }
            if (masterVolumeNumbers >= 100)
            {
                masterVolumeNumbers = 100;
            }
            if (musicVolumeNumbers <= 0)
            {
                musicVolumeNumbers = 0;
            }
            if (musicVolumeNumbers >= 100)
            {
                musicVolumeNumbers = 100;
            }
            if (sfxVolumeNumbers <= 0)
            {
                sfxVolumeNumbers = 0;
            }
            if (sfxVolumeNumbers >= 100)
            {
                sfxVolumeNumbers = 100;
            }
        }

        public static void Draw(SpriteBatch sb)
        {
            for (int i = Lists.fontList.Count - 1; i >= 0; i--)
            {
                Font f = Lists.fontList[i];
                f.Draw(sb);
            }
        }
    }
}

