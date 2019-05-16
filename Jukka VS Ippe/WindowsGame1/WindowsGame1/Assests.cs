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


namespace WindowsGame1
{
    class Assests
    {
        public static Texture2D jukkaSprite;
        public static Texture2D ippeSprite;
        public static Texture2D menuBG;
        public static Texture2D hud;
        public static Texture2D BG;
        public static Texture2D fx01;
        public static Texture2D shield;
        public static Texture2D shot;
        public static Texture2D timeWheel;
        public static Texture2D bar;
        public static Texture2D hell;
        public static Texture2D ippeWon;
        public static Texture2D jukkaWon;
        public static Texture2D earth;
        public static Texture2D lightBeam;
        public static Texture2D circle;

        public static SpriteFont font;

        public static SoundEffect jukkaWQuote1;
        public static SoundEffect jukkaWQuote2;
        public static SoundEffect jukkaWQuote3;
        public static SoundEffect jukkaWQuote4;
        public static SoundEffect jukkaWQuote5;
        public static SoundEffect ippeWQuote1;
        public static SoundEffect ippeWQuote2;
        public static SoundEffect ippeWQuote3;
        public static SoundEffect ippeWQuote4;
        public static SoundEffect ippeWQuote5;

        public static Song BGM02;
        public static Song endMusic;
        public static Song BGM01;
        public static Song BGM03;

        public static void LoadAssests(ContentManager content)
        {
            jukkaSprite = content.Load<Texture2D>("Jukkapää");
            ippeSprite = content.Load<Texture2D>("Ippepää");
            menuBG = content.Load<Texture2D>("The menu");
            hud = content.Load<Texture2D>("Hud");
            BG = content.Load<Texture2D>("time_machine_wall");
            fx01 = content.Load<Texture2D>("fx01");
            shield = content.Load<Texture2D>("shield");
            shot = content.Load<Texture2D>("bullet");
            timeWheel = content.Load<Texture2D>("wheel_of_time");
            bar = content.Load<Texture2D>("bar");
            hell = content.Load<Texture2D>("hell");
            ippeWon = content.Load<Texture2D>("ippe_Won");
            jukkaWon = content.Load<Texture2D>("jukka_Won");
            earth = content.Load<Texture2D>("Earth");
            lightBeam = content.Load<Texture2D>("LightBeam");
            circle = content.Load<Texture2D>("ballo");

            font = content.Load<SpriteFont>("SpriteFont1");

            jukkaWQuote1 = content.Load<SoundEffect>("Jukka1final");
            jukkaWQuote2 = content.Load<SoundEffect>("Jukka2final");
            jukkaWQuote3 = content.Load<SoundEffect>("Jukka3final");
            jukkaWQuote4 = content.Load<SoundEffect>("Jukka4final");
            jukkaWQuote5 = content.Load<SoundEffect>("Jukka5final");
            ippeWQuote1 = content.Load<SoundEffect>("Ippe1final");
            ippeWQuote2 = content.Load<SoundEffect>("Ippe2final");
            ippeWQuote3 = content.Load<SoundEffect>("Ippe3final");
            ippeWQuote4 = content.Load<SoundEffect>("Ippe4final");
            ippeWQuote5 = content.Load<SoundEffect>("Ippe5final");

            endMusic = content.Load<Song>("Victory Music");
            BGM01 = content.Load<Song>("Hyvin Kesken Oleva Battle Music");
            BGM02 = content.Load<Song>("Grave of our ippes");
            BGM03 = content.Load<Song>("Battle Music");
        }
    }
}
