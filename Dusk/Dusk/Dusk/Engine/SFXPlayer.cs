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

namespace Dusk.Engine
{
    class SFXPlayer : Methods
    {
        SoundEffectInstance sfx01;
        SoundEffectInstance sfx02;
        SoundEffectInstance sfx03;
        SoundEffectInstance sfx04;
        SoundEffectInstance sfx05;


        public void AddSFX(int sfxID, SoundEffect soundFX)
        {
            if (sfxID == 1)
            {
                sfx01 = soundFX.CreateInstance();
            }
            else if (sfxID == 2)
            {
                sfx02 = soundFX.CreateInstance();
            }
            else if (sfxID == 3)
            {
                sfx03 = soundFX.CreateInstance();
            }
            else if (sfxID == 4)
            {
                sfx04 = soundFX.CreateInstance();
            }
            else if (sfxID == 5)
            {
                sfx05 = soundFX.CreateInstance();
            }
        }

        public void PlaySFX(int sfxID,float volume)
        {
            if (sfxID == 1)
            {
                sfx01.Stop();
                sfx01.Volume = volume*SFXvolume;
                sfx01.Play();
            }
            else if (sfxID == 2)
            {
                sfx02.Stop();
                sfx02.Volume = volume * SFXvolume;
                sfx02.Play();
            }
            else if (sfxID == 3)
            {
                sfx03.Stop();
                sfx03.Volume = volume * SFXvolume;
                sfx03.Play();
            }
            else if (sfxID == 4)
            {
                sfx04.Stop();
                sfx04.Volume = volume * SFXvolume;
                sfx04.Play();
            }
            else if (sfxID == 5)
            {
                sfx05.Stop();
                sfx05.Volume = volume * SFXvolume;
                sfx05.Play();
            }
        }
    }
}
