using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefence.Engine
{
    class MasterVolume
    {
        public static float masterVolume = 1.0f;
        public static float mute = 1;

        public static void Update()
        {
            if (masterVolume <= 0)
            {
                masterVolume = 0;
            }
            if (masterVolume >= 1)
            {
                masterVolume = 1;
            }
        }

        /// <summary>
        /// //Tällä voidaan mutettaa kaikki äänet, sulkujen sisään joko true (mutettaa kaiken) tai false (poistaa muten)
        /// </summary>
        public static void MuteMasterVolume(bool _mute)
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
    }
}
