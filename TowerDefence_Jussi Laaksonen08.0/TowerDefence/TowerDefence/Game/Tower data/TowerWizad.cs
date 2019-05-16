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
    class TowerWizad : TowerMother
    {
        /// <summary>
        /// Tällä luodaan Wizard torni
        /// </summary>
        public TowerWizad(Vector2 position)
            : base()
        {
            s1 = Assests.wizardSummon01;
            s2 = Assests.wizardSummon02;
            s3 = Assests.wizardSummon03;
            s4 = Assests.wizardSummon04;
            s5 = Assests.wizardSummon05;
            PlaySummonSFX();
            this.position = position;
            value = 100;
            level = 31;
            sprite = Assests.wizardTower;
            spriteDrawArea = new Rectangle(0, 0, 30, 30);
            attackSpeed = 60;
            damage = 17;
            AoE = 30;
            range = 70;
            idleAnimationSpeed = 8;
            idleAnimationFrames = 7;
            attackAnimationSpeed = 3;
            attackAnimationFrames = 11;
            attackPoint = 0.5f;
            attackBase = attackAnimationSpeed * attackAnimationFrames;
            animation = new Animation(sprite, spriteDrawArea, idleAnimationSpeed, idleAnimationFrames);
        }

        public override void Upgrade()
        {
            if (level != 35)
            {
                level += 1;
                value += 100;//111

                Random rand = new Random();

                int temp = rand.Next(0, 15);

                if (temp >= 10)
                    SFXEngine.PlaySFX(Assests.wizardUpgrade03);

                else if (temp >= 5)
                    SFXEngine.PlaySFX(Assests.wizardUpgrade02);

                else SFXEngine.PlaySFX(Assests.wizardUpgrade01);

                CheckLevel();
            }
        }

        public override void CheckLevel()
        {
            //LEVEL 2
            if (level == 32)
            {
                attackSpeed = 60;
                damage = 23;
                AoE = 35;
                range = 70;
            }
            //LEVEL 3
            if (level == 33)
            {
                animation = new Animation(sprite, new Rectangle(0, 60, 30, 30), idleAnimationSpeed, idleAnimationFrames);
                attackSpeed = 55;
                damage = 30;
                AoE = 40;
                range = 80;
            }
            //LEVEL 4
            if (level == 34)
            {
                attackSpeed = 55;
                damage = 39;
                AoE = 50;
                range = 80;
            }
            //LEVEL 5
            if (level == 35)
            {
                animation = new Animation(sprite, new Rectangle(0, 120, 30, 30), idleAnimationSpeed, idleAnimationFrames);
                attackSpeed = 45;
                damage = 46;
                AoE = 0;
                range = 100;
            }
            //Back to LEVEL 5
            if (level == 36)
            {
                level = 35;
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
                //tarkastaa levelin ja säätää sen mukaan partikkelit
                if (level < 35)
                {
                    CreateProjectile(position, (int)damage, (int)AoE, 5, target, new Animation(Assests.wizardTower, new Rectangle(210, 0, 30, 30), 0, 1), 1);
                }
                else
                {
                    CreateProjectile(position, (int)damage, (int)AoE, 5, target, new Animation(Assests.wizardTower, new Rectangle(210, 0, 30, 30), 0, 1), 2);
                }
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
