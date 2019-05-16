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
using Labyrinth.Engine;
using Labyrinth.Objects;

namespace Labyrinth.Engine
{
    class Cursor
    {
        public static Vector2 mousePosition;
        private Vector2 mousePositionOld, mouseMoved, mousePositionReal;
        float angle;

        public Cursor()
        {
            Recources.LoadTexture("pelaaja1d");
            //mousePosition = Input.MousePosition();

            mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            mousePosition.X -= 16;
            mousePosition.Y -= 16;
            mousePositionReal = mousePosition;

        }

        public float Update(Vector2 playerPosition)
        {

            mousePosition = Input.MousePosition();
            mouseMoved = new Vector2((int)Mouse.GetState().X, (int)Mouse.GetState().Y);
            //mouseMoved.X = (int)mouseMoved.X;
            //mouseMoved.Y = (int)mouseMoved.Y;
            mousePosition.X -= 16;
            mousePosition.Y -= 16;

            //if (mousePositionOld != mouseMoved)

            if(mousePositionOld.X == mouseMoved.X || mousePositionOld.Y == mouseMoved.Y)
            {
                mousePosition = SetCursorLocation(angle, playerPosition);
            }
            else
            {

                mousePosition = CursorLocation(mousePosition, playerPosition);
                //mousePositionReal = mousePosition;
                mousePositionReal.X = (int)mousePosition.X + 16;
                mousePositionReal.Y = (int)mousePosition.Y + 16;
                Mouse.SetPosition((int)mousePosition.X +16, (int)mousePosition.Y +16);
            }
            mousePositionOld = mouseMoved;
            return angle;
        }

        public static void Draw()
        {

            //Mouse Draw
            DrawSys.Draw(Recources.GetTexture("pelaaja1d"), new Rectangle(97, 32, 32, 32), mousePosition, 0);
        }

        //Tässä koitamme rajoittaa kursorin pyörimään pelaajan ympärillä
        private Vector2 CursorLocation(Vector2 mousePos, Vector2 playerPos)
        {

            playerPos.X += 16;
            playerPos.Y += 16;
            mousePos = Vector2.Subtract(mousePos, playerPos);
            angle = (float)Math.Atan2(mousePos.Y, mousePos.X);

            //mousePos.Normalize();
            //mousePos = Vector2.Multiply(mousePos, 100);
            
            
            mousePos.Y = (float)Math.Sin(angle) * 100;
            mousePos.X = (float)Math.Cos(angle) * 100;
            mousePos = Vector2.Add(mousePos, playerPos);

            return mousePos;
        }
        private Vector2 SetCursorLocation(float angle, Vector2 playerPos)
        {
            Vector2 temp;
            temp.Y = (float)Math.Sin(angle) * 100;
            temp.X = (float)Math.Cos(angle) * 100;
            playerPos.X += 16;
            playerPos.Y += 16;
            temp = Vector2.Add(temp, playerPos);
            Mouse.SetPosition((int)temp.X +16, (int)temp.Y +16);
            return temp;
        }
    }
}
