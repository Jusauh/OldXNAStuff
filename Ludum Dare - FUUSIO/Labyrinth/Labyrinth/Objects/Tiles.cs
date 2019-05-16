using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Engine;
using Microsoft.Xna.Framework;

namespace Labyrinth.Objects
{
    class Tiles
    {
        private Rectangle boundingBox;

        public Rectangle BoundingBox
        {
            get { return boundingBox; }
        }

        public Tiles(Rectangle boundingBox)
        {
            this.boundingBox = boundingBox;
        }

        public Vector2 GetCenterPosition()
        {
            return new Vector2(boundingBox.X + boundingBox.Width/2, boundingBox.Y + boundingBox.Height/2);
        }
        
    }
}
