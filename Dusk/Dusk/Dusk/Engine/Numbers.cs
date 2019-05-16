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
    class Numbers
    {
        protected int PlayScreenMinX = 32;
        protected int PlayScreenMaxX = 536;
        protected int PlayScreenMinY = 32;
        protected int PlayScreenMaxY = 568;

        protected int BulletBoundryMinX = 50;
        protected int BulletBoundryMaxX = 50;
        protected int BulletBoundryMinY = 50;
        protected int BulletBoundryMaxY = 50;

        protected int GetCenterX = 252;
        protected int GetCenterY = 268;

        protected int SFXvolume = 1;
        protected int MusicVolume = 1;
    }
}
