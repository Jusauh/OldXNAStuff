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
using TowerDefence.Game.Tower_data;
using TowerDefence.Game.Enemy_data;

namespace TowerDefence.Engine
{
    class Lists
    {
        //Towers
        public static List<TowerArcher> towerArcherList = new List<TowerArcher>();
        public static List<TowerKnight> towerKnightList = new List<TowerKnight>();
        public static List<TowerWizad> towerWizardList = new List<TowerWizad>();
        //Vihut
        public static List<Enemy> enemyList = new List<Enemy>();
        //Buttons
        public static List<OnScreenButton> onScreenButtonList = new List<OnScreenButton>();
        //Fonts
        public static List<Font> fontList = new List<Font>();
        //Projectiles
        public static List<Projectile> projectileList = new List<Projectile>();
        //Partikkelit
        public static List<Particle> particleList = new List<Particle>();

        public static void ClearDeadObjects()
        {
            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                Enemy temp = enemyList[i];
                if (temp.isAlive == false)
                {
                    enemyList.Remove(temp);
                }
            }
            for (int i = projectileList.Count - 1; i >= 0; i--)
            {
                Projectile temp = projectileList[i];
                if (temp.isAlive == false)
                {
                    projectileList.Remove(temp);
                }
            }

        }
    }
}
