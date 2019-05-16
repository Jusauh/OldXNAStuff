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

//Tällä säädetään pelin musiikin toistoa

namespace TowerDefence.Engine
{
    class MusicEngine
    {
        public static float volume = 1;
        static float mute = 1;
        public static float volumeLoudnes = 1;
        static float volumeChange;
        static float volumeChangeDuration = 0;

        static float fadeTime = -1;
        static Song nextSong;
        static float nextVolume;

        /// <summary>
        /// Tämä päivittää musiikkitoimintoja
        /// </summary>
        public static void UpdateMusicPlayer()
        {
            if (volumeChangeDuration > 0)
            {
                volume += volumeChange;
            }
            if (volumeChangeDuration != 0)
            {
                volumeChangeDuration--;
            }

            if (fadeTime == 0)
            {
                PlayMusic(nextSong);
                ChangeVolume(nextVolume);
            }
            if (fadeTime >= 0)
            {
                fadeTime--;
            }

            //Tässä asetaan äänenvoimakkuus aina halutulle tasolle
            MediaPlayer.Volume = volume * volumeLoudnes * MasterVolume.masterVolume * MasterVolume.mute * mute; //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        }

        /// <summary>
        /// Tällä voidaan laittaa jokin kappale soimaan ilma mitään eri jekkuja.
        /// </summary>
        /// <param name="music">Kappale, joka halutaan laittaa soimaan</param>
        public static void PlayMusic(Song music)
        {
            MediaPlayer.Play(music);
        }
        /// <summary>
        /// //Tällä voidaan säätää äänenvoimakkuutta
        /// </summary>
        /// <param name="_volumeChange">Äänenvoimakkuus, johon halutaan siirtyä, 0 ja 1 välillä</param>
        /// <param name="_volumeChangeDuration">Miten kauan siirtyminen kestää</param>
        public static void ChangeVolume(float _volumeChange, float _volumeChangeDuration = 1) 
        {
            volumeChange = ((volume - _volumeChange) / _volumeChangeDuration)*-1;
            volumeChangeDuration = _volumeChangeDuration;
        }
        /// <summary>
        /// //Tällä voidaan mutettaa musiikki, sulkujen sisään joko true (mutettaa musiikit) tai false (poistaa muten)
        /// </summary>
        public static void MuteMusic(bool _mute)
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
        /// <summary>
        /// Tällä voidaan vaihtaa kappale soimaam fadetimen kanssa
        /// </summary>
        /// <param name="music">Kappale, joka laitetaan soimaan</param>
        /// <param name="fade">Faden kesto frameina</param>
        /// <param name="newVolume">Äänenvoimakkuus mihin uusi kappale alkaa soimaan, 0 ja 1 välillä</param>
        public static void ChangeSong(Song music, float fade = 0, float newVolume = 1)
        {
            nextSong = music;
            fadeTime = fade;

            ChangeVolume(0, fade);
            nextVolume = newVolume;
        }

    }
}
