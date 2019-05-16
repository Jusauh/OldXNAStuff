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

namespace TowerDefence.Engine
{
    class SFXEngine
    {
        public static float sfxVolume = 1;
        static float sfxVolumeChange = 1;
        static float mute = 1;

        public static void PlaySFX(SoundEffect soundEffect)
        {
            soundEffect.Play();
        }

        /// <summary>
        /// Sulkujen sisään arvoja väliltä 1 - 2
        /// </summary>
        public static void ChangeSFXVolume(float _sfxVolumeChange)
        {
            sfxVolumeChange = (sfxVolume - _sfxVolumeChange) * -1;
        }

        /// <summary>
        /// //Tällä voidaan mutettaa effectit, sulkujen sisään joko true (mutettaa effectit) tai false (poistaa muten)
        /// </summary>
        public static void MuteSFX(bool _mute)
        {
            if (_mute == true)
            {
                mute = 0;
            }
            else if (_mute == false)
            {
                mute = 1;
            }
        }

        public static void UpdateSFX()
        {
            if (sfxVolume <= 0)
            {
                sfxVolume = 0;
            }
            if (sfxVolume >= 1)
            {
                sfxVolume = 1;
            }

            SoundEffect.MasterVolume = sfxVolume * sfxVolumeChange * MasterVolume.masterVolume * MasterVolume.mute * mute; //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        }
    }
}

