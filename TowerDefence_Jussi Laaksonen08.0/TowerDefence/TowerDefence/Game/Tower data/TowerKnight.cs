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

namespace TowerDefence.Game.Tower_data
{
    class TowerKnight : TowerMother
    {
        /// <summary>
        /// Tällä luodaan Knight torni
        /// </summary>
        public TowerKnight(Vector2 position)
            : base()
        {
            s1 = Assests.knightSummon01;
            s2 = Assests.knightSummon02;
            s3 = Assests.knightSummon03;
            s4 = Assests.knightSummon04;
            s5 = Assests.knightSummon05;
            PlaySummonSFX();
            this.position = position;
            value = 60;
            level = 21;
            sprite = Assests.knightTower;
            spriteDrawArea = new Rectangle(0, 0, 30, 30);
            attackSpeed = 65;
            damage = 18;
            AoE = 0;
            range = 40;
            idleAnimationSpeed = 8;
            idleAnimationFrames = 8;
            attackAnimationSpeed = 4;
            attackAnimationFrames = 9;
            attackPoint = 0.65f;
            attackBase = attackAnimationSpeed * attackAnimationFrames;
            animation = new Animation(sprite, spriteDrawArea, idleAnimationSpeed, idleAnimationFrames);
        }

        public override void Upgrade()
        {
            if (level != 25)
            {
                level += 1;
                value += 60;//111
                Random rand = new Random();

                int temp = rand.Next(0, 15);

                if (temp >= 10)
                    SFXEngine.PlaySFX(Assests.knightUpgrade03);

                else if (temp >= 5)
                    SFXEngine.PlaySFX(Assests.knightUpgrade02);
                else SFXEngine.PlaySFX(Assests.knightUpgrade01);

                CheckLevel();
            }
        }

        public override void CheckLevel()
        {
            //LEVEL 2
            if (level == 22)
            {
                attackSpeed = 60;
                damage = 23;
                AoE = 0;
                range = 40;
            }
            //LEVEL 3
            if (level == 23)
            {
                animation = new Animation(sprite, new Rectangle(0, 60, 30, 30), idleAnimationSpeed, idleAnimationFrames);
                attackSpeed = 55;
                damage = 30;
                AoE = 0;
                range = 40;
            }
            //LEVEL 4
            if (level == 24)
            {
                attackSpeed = 50;
                damage = 37;
                AoE = 0;
                range = 40;
            }
            //LEVEL 5
            if (level == 25)
            {
                animation = new Animation(sprite, new Rectangle(0, 120, 30, 30), idleAnimationSpeed, idleAnimationFrames);
                attackSpeed = 45;
                damage = 46;
                AoE = 0;
                range = 40;
            }
            //Back to LEVEL 5
            if (level == 26)
            {
                level = 25;
            }
        }

        /// <summary>
        /// Päivitys
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (createProjectile == true)
            {
                CreateProjectile(position, (int)damage, (int)AoE, 500, target, new Animation(Assests.knightTower, new Rectangle(240, 0, 30, 30), 50, 2), 3);
            }
        }

        /// <summary>
        /// Piirto
        /// </summary>
        public override void Draw(SpriteBatch sb)
        {
            animation.Draw(sb, position, angle);

            base.Draw(sb);
        }
    }
}
