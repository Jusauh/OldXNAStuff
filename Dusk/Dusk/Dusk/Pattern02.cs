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

namespace Dusk
{
    class Pattern02 : Methods
    {
        int frame,frame2;
        float angle,angle2,angle3, angleMod = 2.5f,rad = 100;

        public void Initialise()
        {
            frame = 0;
            frame2 = 0;
            angle = 0;
        }


        public void Update()
        {
            
            frame++;
            frame2++;
            if (frame == 60)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        //CreateBullet02(GetCenterX + Cos(angle + angle2) * (rad), 100 + Sin(angle + angle2) * (rad), 3, 0.01f, AngleTo(GetCenterX + Cos(angle + angle2) * (rad), 100 + Sin(angle + angle2) * (rad), GetPlayerX(), GetPlayerY()) + angle2, 0, "Green11");
                        CreateBullet02(GetCenterX + Cos(angle) * rad, 100 + Sin(angle) * rad, 3, -0.01f, angle2,2, 0,15, "Blue02");

                        angle2 += 360f/5f;
                    }
                    angle2 += 4.5f;
                    angle += 360f / 5f;
                }
                rad -= 5.5f;
                if (rad < 0)
                {
                    rad = 100;
                    frame = -60;
                }
                angle += angleMod;
                frame -= 6;
                frame2 = 55;
            }
            if (frame2 == 65)
            {
                for (int i = 0; i < 80; i++)
                {
                    CreateBullet01(GetCenterX, 100, 0.8f+Rand(0.2f,0.6f), angle3,15, "Cyan12");
                    angle3 += 360f / 80f;
                }
                angle3 += Rand(0, 360);
                frame2 = -60;
            }
        }
    }
}
