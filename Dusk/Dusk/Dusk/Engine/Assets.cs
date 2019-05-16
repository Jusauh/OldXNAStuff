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

namespace Dusk.Engine
{
    class Assets
    {
        public static Texture2D bSheet01;
        public static Texture2D fxSheet;
        public static Texture2D itemSheet;
        public static Texture2D hud;
        public static Texture2D player;
        public static Texture2D enemy01;
        public static Texture2D boss01;

        public static Texture2D bomb01;

        public static Texture2D familiar01;
        public static Texture2D stage01FG;
        public static Texture2D stage01BG;

        public static SoundEffect sfx01;
        public static SoundEffect sfx02;
        public static SoundEffect sfx03;
        public static SoundEffect sfx04;
        public static SoundEffect sfx05;
        public static SoundEffect sfx06;

        public static SpriteFont font01;

        public static void LoadAssets(ContentManager content)
        {
            bSheet01 = content.Load<Texture2D>("B_Sheet01");
            fxSheet = content.Load<Texture2D>("FXsheet");
            itemSheet = content.Load<Texture2D>("itemSheet");
            hud = content.Load<Texture2D>("Hud");
            player = content.Load<Texture2D>("Player");
            enemy01 = content.Load<Texture2D>("Enemy01");
            boss01 = content.Load<Texture2D>("Boss01");
            bomb01 = content.Load<Texture2D>("Bomb01");

            familiar01 = content.Load<Texture2D>("Familiar");

            stage01FG = content.Load<Texture2D>("stage1fore");
            stage01BG = content.Load<Texture2D>("stage1bg");

            //sfx01 = content.Load<SoundEffect>("SFX/sfx01");
            //sfx02 = content.Load<SoundEffect>("SFX/sfx02");
            //sfx03 = content.Load<SoundEffect>("SFX/sfx03");
            //sfx04 = content.Load<SoundEffect>("SFX/sfx04");
            //sfx05 = content.Load<SoundEffect>("SFX/sfx05");
            //sfx06 = content.Load<SoundEffect>("SFX/sfx06");

            font01 = content.Load<SpriteFont>("font01");
        }
    }
}
