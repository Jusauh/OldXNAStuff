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
using TowerDefence.Game;

namespace TowerDefence.Game.Level_data
{
    /// <summary>
    /// Tällä voidaan määritellä ja laskea tasoille ruudut, joihin ei voi rakentaa torneja
    /// </summary>
    class BuildableTerrain
    {
        protected static Vector2[] Level1UnBuildableTerrain()
        {
            Vector2[] area = new Vector2[5];
            area[0] = new Vector2(135, 195);
            area[1] = new Vector2(525, 195);
            area[2] = new Vector2(375, 435);
            area[3] = new Vector2(15, 105);
            area[4] = new Vector2(15, 165);
            return area;
        }
        /// <summary>
        /// Tämä kääntää jonkin tietyn reitin Vector2:ksi, joihin ei voida rakentaa mitään.
        /// </summary>
        public static Vector2[] ReadPath(Vector2[] path, Vector2 startPoint)
        {
            int temp = 0;
            int currentVector = 0;
            Vector2 occupiedLocation = startPoint;
            for (int i = 0; i < path.Count(); i++) //Lasketaan, miten monta "ruutua" tulee asettaa varatuiksi
            {
                temp += (int)path[i].Length();
            }
            Vector2[] area = new Vector2[temp];

            for (int i = 0; i < path.Count(); i++) //Luodaan taulukko, jossa on kaikki varatut "ruudut"
            {
                temp = (int)path[i].Length();
                while (temp > 0)
                {
                    Vector2 tempVector = Vector2.Normalize(path[i]);
                    occupiedLocation += new Vector2(tempVector.X * 30, tempVector.Y * 30);
                    temp -= 1;
                    area[currentVector] = occupiedLocation;
                    currentVector += 1;
                }
            }
            return area;
        }

        public static Vector2[] GetTerrain(int stage)
        {
            if (stage == 1)
            {
                Vector2[] area1 = ReadPath(LevelPath.Stage1Path(), new Vector2(315, -15));
                Vector2[] area2 = Level1UnBuildableTerrain();

                Vector2[] area = new Vector2[area1.Count() + area2.Count()];

                for (int i = 0; i < area1.Count(); i++)
                {
                    area[i] = area1[i];
                }
                for (int i = 0; i < area2.Count(); i++)
                {
                    area[i + area1.Count()] = area2[i];
                }
                return area;
            }
            else
            {
                return new Vector2[0];
            }
        }
    }
}
