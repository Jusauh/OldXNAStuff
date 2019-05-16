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

namespace TowerDefence.Game
{
    class Options
    {
        public static int whereTo = 1;

        int replace1 = 0;
        int replace2 = 0;
        int replace3 = 0;

        bool initialized = false;

        public void Initialize()
        {
            if (!initialized)
            {
                FontManager.InitFonts(4);
                ButtonManager.InitButtons(4);

                initialized = true;
            }
        }

        public void Update()
        {
            Initialize();
            ButtonsUpdate();

            if (MainLoop.gameState == MainLoop.GameState.inGame || MainLoop.gameState == MainLoop.GameState.mainMenu)
            {
                initialized = false;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Assests.optionsScreen, new Vector2(0, 0), Color.White);

            ButtonManager.Draw(sb);
            FontManager.Draw(sb);
        }

        public void ButtonsUpdate()
        {
            ButtonManager.Update();

            //Back
            if (Lists.onScreenButtonList[0].pressed == true)
            {
                if (whereTo == 1)
                {
                    MainLoop.gameState = MainLoop.GameState.mainMenu;
                }
                else if (whereTo == 2)
                {
                    MainLoop.gameState = MainLoop.GameState.inGame;
                }
            }
            //Master Volume
            //Mute
            if (Lists.onScreenButtonList[1].pressed == true)
            {
                if (replace1 == 0)
                {
                    MasterVolume.MuteMasterVolume(true);

                    Lists.onScreenButtonList[1].useNewTexture = true;
                    replace1 = 1;
                }
                else if (replace1 == 1)
                {
                    MasterVolume.MuteMasterVolume(false);

                    Lists.onScreenButtonList[1].useNewTexture = false;
                    replace1 = 0;
                }
            }
            //Increase
            if (Lists.onScreenButtonList[2].pressed == true)
            {
                MasterVolume.masterVolume += 0.01f;

                if (FontManager.masterVolumeNumbers != 100)
                {
                    FontManager.masterVolumeNumbers++;
                }

                Lists.fontList[2].replaceOutput(FontManager.masterVolumeNumbers.ToString());
            }
            //Decrease
            if (Lists.onScreenButtonList[3].pressed == true)
            {
                MasterVolume.masterVolume -= 0.01f;

                if (FontManager.masterVolumeNumbers != 0)
                {
                    FontManager.masterVolumeNumbers--;
                }

                Lists.fontList[2].replaceOutput(FontManager.masterVolumeNumbers.ToString());
            }
            //Music Volume
            //Mute
            if (Lists.onScreenButtonList[4].pressed == true)
            {
                if (replace2 == 0)
                {
                    MusicEngine.MuteMusic(true);

                    Lists.onScreenButtonList[4].useNewTexture = true;
                    replace2 = 1;
                }
                else if (replace2 == 1)
                {
                    MusicEngine.MuteMusic(false);

                    Lists.onScreenButtonList[4].useNewTexture = false;
                    replace2 = 0;
                }
            }
            //Increase
            if (Lists.onScreenButtonList[5].pressed == true)
            {
                if (MusicEngine.volumeLoudnes != 1)
                {
                    MusicEngine.volumeLoudnes += 0.01f;
                }
                if (FontManager.musicVolumeNumbers != 100)
                {
                    FontManager.musicVolumeNumbers++;
                }

                Lists.fontList[5].replaceOutput(FontManager.musicVolumeNumbers.ToString());
            }
            //Decrease
            if (Lists.onScreenButtonList[6].pressed == true)
            {
                if (MusicEngine.volumeLoudnes >= 0.01f)
                {
                    MusicEngine.volumeLoudnes -= 0.01f;
                }
                if (FontManager.musicVolumeNumbers != 0)
                {
                    FontManager.musicVolumeNumbers--;
                }

                Lists.fontList[5].replaceOutput(FontManager.musicVolumeNumbers.ToString());
            }
            //Sound Effect Volume
            //Mute
            if (Lists.onScreenButtonList[7].pressed == true)
            {
                //SFXEngine.PlaySFX(Assests.soundEffect01);

                if (replace3 == 0)
                {
                    SFXEngine.MuteSFX(true);

                    Lists.onScreenButtonList[7].useNewTexture = true;
                    replace3 = 1;
                }
                else if (replace3 == 1)
                {
                    SFXEngine.MuteSFX(false);

                    Lists.onScreenButtonList[7].useNewTexture = false;
                    replace3 = 0;
                }
            }
            //Increase
            if (Lists.onScreenButtonList[8].pressed == true)
            {
                SFXEngine.PlaySFX(Assests.soundEffect01);

                SFXEngine.sfxVolume += 0.01f;

                if (FontManager.sfxVolumeNumbers != 100)
                {
                    FontManager.sfxVolumeNumbers++;
                }

                Lists.fontList[8].replaceOutput(FontManager.sfxVolumeNumbers.ToString());
            }
            //Decrease
            if (Lists.onScreenButtonList[9].pressed == true)
            {
                SFXEngine.PlaySFX(Assests.soundEffect01);

                SFXEngine.sfxVolume -= 0.01f;

                if (FontManager.sfxVolumeNumbers != 0)
                {
                    FontManager.sfxVolumeNumbers--;
                }

                Lists.fontList[8].replaceOutput(FontManager.sfxVolumeNumbers.ToString());
            }
        }
    }
}
