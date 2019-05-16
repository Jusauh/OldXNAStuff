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

namespace Dusk.EnemyData.Enemies.Stage01
{
    class Enemy01 : EnemyPrime
    {
        int frame,frame2;
        new float angle;

        public Enemy01(float positionX, float positionY)
        {
            SetPosition(positionX, positionY);
            MovePosition01(GetCenterX, 100,60);
            hitBox02 = 40;
            health = 300;
            bulletDamageRate = 1;
            bombDamageRate = 1;
        }

        public override void Update()
        {

            frame++;
            frame2++;
            if (frame == 60)
            {
                for (int i = 0; i < 60; i++)
                {
                    CreateBullet02(GetX(), GetY(), 2, 0, angle, 0.2f,2,20, "Yellow13");
                    CreateBullet02(GetX(), GetY(), 2, 0, angle, -0.2f,2,20, "Yellow13");
                    angle += 360f / 60f;
                }
                angle += Rand(0, 360);
                frame = 28;

            }

            if (frame2 == 120)
            {
                for (int i = 0; i < 50; i++)
                {
                    CreateBullet01(GetX(),GetY(), 1.2f, angle,20, "Orange11");
                    angle += (360f / 50f);
                }


                frame2 = 60;
            }

            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(Assets.enemy01, position, new Rectangle(64,0,32,32), Color.White, 0, new Vector2(16,16), 1f, SpriteEffects.None, 0);
        }
    }
}
