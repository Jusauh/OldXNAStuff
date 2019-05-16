using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace TowerDefence.Engine
{
    class ParticleEngine
    {
        //vakio kulman muuttamiseksi asteista radiaaneiksi
        //0.0017453293 = PI/180;
        const float PI_DIV_180 = 0.017453293f;

        public ParticleEngine()
        {
        }

        //Tämä tekee halutun määrän partikkeleja satunnaisesti annetun kulman sisään.
        public static void ParticleAnimation(Texture2D texture, Rectangle spriteArea, Vector2 position, int frames, float particleSpeed, float startAngle, float endAngle, int numberOfParticles, int lifeTime, int stayOnScreen, int drawLayer)
        {
            Random rand = new Random();
            startAngle = PI_DIV_180 * startAngle;
            endAngle = PI_DIV_180 * endAngle;
            float effectAngle = endAngle - startAngle;
            //Tässä luodaan tarvittavat partikkelit ja lisätään listaan
            for (int i = 0; i < numberOfParticles; i++)
            {
                endAngle = ((float)rand.NextDouble() * effectAngle) + startAngle;
                //Lisätään listaan partikkeli ja käytetään matkalla pituuden randomisointia
                Lists.particleList.Add(new Particle(texture, spriteArea, position,
                                                    RandomizeSpeed(particleSpeed, endAngle, (float)rand.NextDouble()),
                                                    1, frames, lifeTime, drawLayer, stayOnScreen, (float)rand.NextDouble()));

            }

        }


        public static void Update()
        {
            for (int i = Lists.particleList.Count() - 1; i > 0; i--)
            {
                if (Lists.particleList[i].Update() == false)
                {
                    Lists.particleList.RemoveAt(i);
                }
            }
        }

        public static void Draw(SpriteBatch sb, int drawLayer)
        {
            for (int i = Lists.particleList.Count() - 1; i > 0; i--)
            {
                Lists.particleList[i].Draw(sb, drawLayer);
            }
        }

        //Luo kulman ja pituuden perusteella vector2:sen, käytetään partikkelin nopeudessa.
        private static Vector2 RandomizeSpeed(float length, float angle, float rand)
        {
            //Jakajana olevalla luvulla voi säätää pituuden satunnaisvaihtelun maksimimäärää
            length += (rand - 1.0f) / 1;
            return new Vector2((length * (float)Math.Sin(angle)), length * (float)Math.Cos(angle));
        }
    }
}
