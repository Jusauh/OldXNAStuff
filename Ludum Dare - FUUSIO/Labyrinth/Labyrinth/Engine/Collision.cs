using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Labyrinth.Objects;

namespace Labyrinth.Engine
{
    class Collision
    {
        public static bool MapCollision(Rectangle objectBoundingBox, List<Tiles> mapTiles)
        {
            foreach (Tiles tile in mapTiles)
            {
                if (objectBoundingBox.Intersects(tile.BoundingBox))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
