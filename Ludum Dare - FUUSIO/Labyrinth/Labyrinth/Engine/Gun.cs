using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Parents;
using Microsoft.Xna.Framework;
using Labyrinth.Engine;

namespace Labyrinth.Objects
{
    class Gun : StillObjectParent
    {
        private bool onGround;

        public bool OnGround { set { onGround = value; } get { return onGround; } }

        public Rectangle BoundingBox { get { return boundingBox; } }

        public Gun(Vector2 position)
        {
            onGround = true;
            this.position = position;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            Recources.LoadTexture("pyssy2");
        }

        public void Update(Player player)
        {
            if (player.boundingBox.Intersects(boundingBox) && OnGround)
            {
                onGround = false;
                player.HasGun();
            }
        }

        public void Draw()
        {
            if (onGround)
            {
                DrawSys.Draw(Recources.GetTexture("pyssy2"), position);
            }
        }

        public void SetGunPosition(Vector2 position)
        {
            this.position = position;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, 32, 32);
        }

    }
}
