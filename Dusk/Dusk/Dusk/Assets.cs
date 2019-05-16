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

namespace Dusk
{
    class Assets
    {
        public static Texture2D bSheet01;
        public static Texture2D hud;

        public static void LoadAssets(ContentManager content)
        {
            bSheet01 = content.Load<Texture2D>("B_Sheet01");
            hud = content.Load<Texture2D>("Hud");
        }
    }
}
