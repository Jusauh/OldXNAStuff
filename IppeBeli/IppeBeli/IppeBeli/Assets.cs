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

namespace IppeBeli
{
    class Assets
    {
        public static Texture2D bg;
        public static Texture2D test;
        public static Texture2D biologyTest;
        public static Texture2D crosshairs;
        public static Texture2D ippe;
        public static Texture2D ippeHand;
        public static Texture2D sweepHand;
        public static Texture2D shredder;
        public static Texture2D shread;
        public static Texture2D hpBar;
        public static Texture2D hpBarOverlay;

        public static Song testsong;
        public static Song turuponpon;
        public static Song liikaaES;

        public static SoundEffect hit1;
        public static SoundEffect hit2;
        public static SoundEffect swoop1;
        public static SoundEffect swoop2;
        public static SoundEffect shred;

        public static void LoadAssets(ContentManager Content)
        {
            bg = Content.Load<Texture2D>("bg");
            test = Content.Load<Texture2D>("test");
            biologyTest = Content.Load<Texture2D>("biologyTest");
            crosshairs = Content.Load<Texture2D>("crosshairs");
            ippe = Content.Load<Texture2D>("Ippe itse");
            ippeHand = Content.Load<Texture2D>("Ippe Käsi");
            sweepHand = Content.Load<Texture2D>("sweepHand");
            shredder = Content.Load<Texture2D>("shredder");
            shread = Content.Load<Texture2D>("Shread");
            hpBar = Content.Load<Texture2D>("Hp bar");
            hpBarOverlay = Content.Load<Texture2D>("Hp bar overlay");

            testsong = Content.Load<Song>("testsong");
            turuponpon = Content.Load<Song>("Turuponpon");
            liikaaES = Content.Load<Song>("Liikaa ES");

            hit1 = Content.Load<SoundEffect>("hit1");
            hit2 = Content.Load<SoundEffect>("hit2");
            swoop1 = Content.Load<SoundEffect>("swoop1");
            swoop2 = Content.Load<SoundEffect>("swoop2");
            shred = Content.Load<SoundEffect>("shred");
        }
    }
}
