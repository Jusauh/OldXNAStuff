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
using Dusk.Engine;

namespace Dusk.Player
{
    class Familiar : Methods
    {
        Vector2 position;
        float distance,angle,angleFromPlayer;
        float shootFrame, shootInterval = 9;

        public Familiar(int familiar)
        {
            if (familiar == 1)
            {
                angleFromPlayer = -20;
                distance = 60;
            }
            else if (familiar == 2)
            {
                angleFromPlayer = 200;
                distance = 60;
            }
        }


        public void Update()
        {
            shootFrame--;
            if (Lists.playerList[0].GetFocused() == true)
            {
                distance -= 5;
            }
            else
            {
                distance += 5;
            }

            if (distance < 20)
                distance = 20;
            else if (distance > 60)
                distance = 60;

            position = new Vector2(GetPlayerX() + Cos(angleFromPlayer) * distance, GetPlayerY() + Sin(angleFromPlayer) * distance);

            Shoot();

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Assets.player, position, new Rectangle(0, 54, 20, 20), Color.White, 0, new Vector2(10, 10), 1f, SpriteEffects.None, 0);
        }

        protected void Shoot()
        {
            if (Lists.playerList[0].GetShooting() == true && shootFrame < 0)
            {
                CreatePlayerBullet(position.X, position.Y, 24, 0, -105, +1.6f, new Rectangle(30, 58, 10, 10));
                CreatePlayerBullet(position.X, position.Y, 24, 0, -75, -1.6f, new Rectangle(30, 58, 10, 10));
                CreatePlayerBullet(position.X, position.Y, 24, -0.3f, -90+Rand(-2,2), 0f, new Rectangle(24, 50, 5, 23));
                shootFrame = shootInterval;
            }
        }
    }
}
