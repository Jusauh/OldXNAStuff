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
    class PlayerBullet : PlayerBulletPrime
    {
        public PlayerBullet(float positionX, float positionY,float angle,float turnSpeed,float speed,float acceleration,float damage, Rectangle crop)
            : base()
        {
            this.position = new Vector2(positionX, positionY);
            this.angle = angle;
            this.turnSpeed = turnSpeed;
            this.speed = speed;
            this.acceleration = acceleration;
            this.crop = crop;
            this.damage = damage;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }

    }
}
