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
    class Enemy : EnemyMother
    {
        public Enemy(int speed, int HP,Vector2 position, Vector2[] path,int type)
        {
            this.speed = speed;
            this.HP = HP;
            this.MaxHP = HP;
            this.path = path;
            this.position = position;
            this.type = type;
            Random rand = new Random();
            if (type == 1)
            {
                this.animation = new Animation(Assests.goblinEnemy, new Rectangle(0, 0, 20, 20), 7, 7);
                int temp = rand.Next(1, 6);
                if (temp == 1)
                    deathSFX = Assests.goblinDeath01;
                if (temp == 2)
                    deathSFX = Assests.goblinDeath02;
                if (temp == 3)
                    deathSFX = Assests.goblinDeath03;
                if (temp == 4)
                    deathSFX = Assests.goblinDeath04;
                if (temp == 5)
                    deathSFX = Assests.goblinDeath05;
            }
            if (type == 2)
            {
                this.animation = new Animation(Assests.orcEnemy, new Rectangle(0, 0, 30, 30), 8, 8);
                int temp = rand.Next(1, 6);
                if (temp == 1)
                    deathSFX = Assests.orcDeath01;
                if (temp == 2)
                    deathSFX = Assests.orcDeath02;
                if (temp == 3)
                    deathSFX = Assests.orcDeath03;
                if (temp == 4)
                    deathSFX = Assests.orcDeath04;
                if (temp == 5)
                    deathSFX = Assests.orcDeath05;
            }
            else if (type == 3)
            {
                this.animation = new Animation(Assests.bossEnemy, new Rectangle(0, 0, 36, 37), 8, 4);
                deathSFX = Assests.bossDefeat01;
                spawnSFX = Assests.bossSummon01;
                troughSFX = Assests.bossVictorious01;
            }
            PlaySFX(spawnSFX);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}

