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
    class TowerArcher : TowerMother
    {
        /// <summary>
        /// Tällä luodaan Archer torni
        /// </summary>
        public TowerArcher(Vector2 position)
            : base()
        {

            s1 = Assests.archerSummon01;
            s2 = Assests.archerSummon02;
            s3 = Assests.archerSummon03;
            s4 = Assests.archerSummon04;
            s5 = Assests.archerSummon05;
            u1 = Assests.archerUpgrade01; 
            u2 = Assests.archerUpgrade02; 
            u3 = Assests.archerUpgrade03; 
            PlaySummonSFX();
            this.position = position;
            level = 11;
            value = 40;
            sprite = Assests.archerTower;
            spriteDrawArea = new Rectangle(0, 0, 30, 30);
            attackSpeed = 60;
            damage = 7;
            AoE = 0;
            range = 70;
            idleAnimationSpeed = 8;
            idleAnimationFrames = 5;
            attackAnimationSpeed = 3;
            attackAnimationFrames = 12;
            attackPoint = 0.85f;
            attackBase = attackAnimationSpeed * attackAnimationFrames;
            animation = new Animation(sprite, spriteDrawArea, idleAnimationSpeed, idleAnimationFrames);
        }

        /// <summary>
        /// Upgradeus
        /// </summary>
        public override void Upgrade()
        {
            if (level != 15)
            {
                value += 40;//111
                level += 1;
                CheckLevel();
                PlayUpgradeSFX();
            }
        }

        public override void CheckLevel()
        {
            //LEVEL 2
            if (level == 12)
            {
                attackSpeed = 57.5f;
                damage = 9;
                AoE = 0;
                range = 75;
            }
            //LEVEL 3
            if (level == 13)
            {
                animation = new Animation(sprite, new Rectangle(0, 60, 30, 30), idleAnimationSpeed, idleAnimationFrames);
                attackSpeed = 55;
                damage = 11;
                AoE = 0;
                range = 80;
            }
            //LEVEL 4
            if (level == 14)
            {
                attackSpeed = 52.5f;
                damage = 13;
                AoE = 0;
                range = 85;
            }
            //LEVEL 5
            if (level == 15)
            {
                animation = new Animation(sprite, new Rectangle(0, 120, 30, 30), idleAnimationSpeed, idleAnimationFrames);
                attackSpeed = 50;
                damage = 16;
                AoE = 0;
                range = 90;
            }
            //Back to LEVEL 5
            if (level == 16)
            {
                level = 15;
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
                CreateProjectile(position, (int)damage, (int)AoE, 5, target, new Animation(Assests.archerTower, new Rectangle(240, 0, 30, 29), 0, 1), 4);
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
