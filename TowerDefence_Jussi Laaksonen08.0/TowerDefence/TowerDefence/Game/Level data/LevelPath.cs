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

namespace TowerDefence.Game.Level_data
{
    class LevelPath
    {
        public static Vector2[] Stage1Path()
        {
            return new Vector2[]
            {
                new Vector2(0,4),
                new Vector2(7,0),
                new Vector2(0,2),
                new Vector2(-7,0),
                new Vector2(0,6),
                new Vector2(7,0),
                new Vector2(0,5),
                new Vector2(-12,0),
                new Vector2(0,-12),
                new Vector2(-5,0),
                new Vector2(0,0)
            };
        }

    }
}
