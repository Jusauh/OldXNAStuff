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

namespace TowerDefence.Game.Enemy_data
{
    /// <summary>
    /// Tässä luokassa luodaan kaikille vihollisille yhteiset ominaisuudet
    /// </summary>
    class EnemyMother
    {
        public Vector2[] path;
        public Vector2 position,velocity;
        public Animation animation;
        protected SoundEffect spawnSFX, deathSFX, troughSFX;
        public int speed;
        public int HP;
        public float MaxHP,hpBarWidth;
        public int type;
        public float angle;
        public int frame, mFrame,mFrameCheck,pathCheck;
        public bool isAlive = true, gotTrough;
        protected Random rand;

        /// <summary>
        /// Tällä päivetetään kaikille vihollisille yleistä logiikaa
        /// </summary>
        public virtual void Update()
        {
            frame++;
            mFrame++;

            animation.Update();
            if (mFrame >= mFrameCheck && pathCheck != path.Count())//Liikumiseen tarvittavat laskutoimitukset
            {
                Vector2 temp = Vector2.Normalize(path[pathCheck]);                                  // Ensiksi normalisoidaan pathin vektori jotta saadaan se 1:en pituiseksi
                this.velocity = new Vector2(temp.X * MovementSpeed(), temp.Y * MovementSpeed());    // Tätä saatua suuntaa lopulta kerrotaan liikumisnopeudella (30/speed)
                mFrameCheck = (int)path[pathCheck].Length() * speed;                                // Liikumisen tarkistus asetetaan liikuttavan etäisyyden mukaan,                                                         //
                pathCheck += 1;                                                                     // speed on aika mikä unitilla kestää liikkua 1 ruudun(30pxl) verran
                mFrame = 0;
            }
            
            if (HP <= 0)
            {
                isAlive = false;
                PlaySFX(deathSFX);
                ParticleEngine.ParticleAnimation(Assests.particle, new Rectangle(0, 3, 2, 2),
                                                position, 1, 1f, 0, 360, 24, 13, 200, 1);
            }
            if( path[pathCheck-1] == new Vector2(0,0))
            {
                isAlive = false;
                gotTrough = true;
                PlaySFX(troughSFX);
            }
            angle = AngleTo(position + velocity);
            position += velocity;
            hpBarWidth = (HP / MaxHP * 30);

        }
        /// <summary>
        /// Piirto
        /// </summary>
        public virtual void Draw(SpriteBatch sb)
        {
            animation.Draw(sb, position, angle);
            sb.Draw(Assests.pxl, new Rectangle((int)position.X - 15, (int)position.Y - 20, 30, 3), Color.Red);
            sb.Draw(Assests.pxl, new Rectangle((int)position.X - 15, (int)position.Y - 20, (int)hpBarWidth,3), Color.DarkGreen);
        }

        public float MovementSpeed()
        {
            return (30f / speed);
        }

        /// <summary>
        /// Laskee edetyn matkan
        /// </summary>
        /// <returns></returns>
        public int DistanceTravelled()
        {
            return (frame * 30/speed);
        }

        protected void PlaySFX(SoundEffect sfx)
        {
            if (sfx != null)
                sfx.Play();
        }
        /// <summary>
        /// Tällä voidaan laskea kulma johonkin kohteeseen ruudulla
        /// </summary>
        public float AngleTo(Vector2 target)
        {
            double angle = Math.Atan2(target.Y - this.position.Y, target.X - this.position.X);
            return MathHelper.ToDegrees((float)angle);
        }

    }
}
