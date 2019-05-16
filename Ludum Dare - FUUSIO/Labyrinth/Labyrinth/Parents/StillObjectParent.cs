using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Labyrinth.Engine;

namespace Labyrinth.Parents
{
    class StillObjectParent
    {
        // Variables
        protected Vector2 position;
        protected Rectangle boundingBox;

        // Constructor
        public StillObjectParent()
        {
        }

        // Update
        public void Update()
        {
        }

        // Draw Method
        public void Draw(string objectTextureName)
        {
            DrawSys.Draw(Recources.GetTexture(objectTextureName), position);
        }
    }
}
