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
using Dusk.EnemyData;
using Dusk.Player;
using Dusk.Stages;
using Dusk.Items;
using Dusk.Game;

namespace Dusk
{
    class Main : Methods
    {
        Stage1 stage = new Stage1();
        int playerSpawnFrame;
        bool init = false;


        public void Update()
        {
            if (!init)
            {
                Lists.playerList.Add(new Player.Player(new Vector2(GetCenterX+PlayScreenMinX, 440)));
                playerSpawnFrame = 0;
                init = true;
            }
            playerSpawnFrame--;
            stage.Update();

            if (playerSpawnFrame == 0)
            {
                Lists.playerList.Add(new Player.Player(new Vector2(GetCenterX + PlayScreenMinX, 440)));                
            }
            if (playerSpawnFrame < 0)
            {
                Lists.playerList[0].Update();
                GameStats.UpdatePlayerPosition();
                if (Lists.playerList[0].IsDead())
                {
                    Lists.playerList.Clear();
                    playerSpawnFrame = 60;
                }
            }

            for (int i = Lists.itemList.Count - 1; i >= 0; i--)
            {
                ItemPrime item = Lists.itemList[i];
                item.Update();

                if (!item.GetAlive())
                {
                    Lists.itemList.Remove(item);
                }
            }

            for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
            {
                EnemyPrime enemy = Lists.enemyList[i];
                enemy.Update();

                if (!enemy.GetAlive())
                {
                    Lists.enemyList.Remove(enemy);
                }
            }
            for (int i = 0; i <= Lists.bomb.Count - 1; i++)
            {
                Bomb bomb = Lists.bomb[i];
                bomb.Update();
                if (bomb.GetOver())
                {
                    Lists.bomb.Clear();
                }
            }
            for (int i = Lists.bulletList.Count - 1; i >= 0; i--)
            {
                Bullet bullet= Lists.bulletList[i];
                bullet.Update();

                if (!bullet.IsAlive())
                    Lists.bulletList.Remove(bullet);
            }
            for (int i = Lists.FXList.Count - 1; i >= 0; i--)
            {
                FX fx = Lists.FXList[i];
                fx.Update();

                if (!fx.IsAlive())
                    Lists.FXList.Remove(fx);
            }
            for (int i = 0; i <= Lists.playerBulletList.Count - 1; i++)
            {
                PlayerBulletPrime playerbullet = Lists.playerBulletList[i];
                playerbullet.Update();

                if (!playerbullet.GetAlive())
                {
                    Lists.playerBulletList.Remove(playerbullet);
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            stage.Draw(sb);

            for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
            {
                EnemyPrime enemy = Lists.enemyList[i];
                enemy.Draw(sb);
            }

            for (int i = 0; i <= Lists.playerBulletList.Count - 1; i++)
            {
                PlayerBulletPrime playerbullet = Lists.playerBulletList[i];
                playerbullet.Draw(sb);
            }

            for (int i = 0; i <= Lists.bomb.Count - 1; i++)
            {
                Bomb bomb = Lists.bomb[i];
                bomb.Draw(sb);
            }

            for (int i = 0; i <= Lists.itemList.Count - 1; i++)
            {
                ItemPrime item = Lists.itemList[i];
                item.Draw(sb);
            }

            if(Lists.playerList.Count == 1)
            Lists.playerList[0].Draw(sb);

            for (int i = Lists.FXList.Count - 1; i >= 0; i--)
            {
                FX fx = Lists.FXList[i];
                if(!fx.GetAdditiveStatus())
                fx.Draw(sb);
            }
            for (int i = 0; i <= Lists.bulletList.Count - 1; i++)
            {
                Bullet bullet = Lists.bulletList[i];
                if (!bullet.GetAdditiveStatus())
                bullet.Draw(sb);
            }
            sb.End();

            sb.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            for (int i = Lists.FXList.Count - 1; i >= 0; i--)
            {
                FX fx = Lists.FXList[i];
                if (fx.GetAdditiveStatus())
                    fx.Draw(sb);
            }
            for (int i = 0; i <= Lists.bulletList.Count - 1; i++)
            {
                Bullet bullet = Lists.bulletList[i];
                if (bullet.GetAdditiveStatus() || bullet.GetDelay())
                    bullet.Draw(sb);
            }
            sb.End();

            sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            if (Lists.playerList.Count == 1)
            {
                if (Lists.playerList[0].GetFocused())
                    sb.Draw(Assets.player, Lists.playerList[0].GetPosition(), new Rectangle(22, 0, 28, 28), Color.White, 0, new Vector2(14f, 14f), 1, SpriteEffects.None, 0);
            }



            sb.Draw(Assets.hud, new Vector2(0, 0), Color.White);
            GameStats.Draw(sb);

            for (int i = Lists.enemyList.Count - 1; i >= 0; i--)
            {
                EnemyPrime enemy = Lists.enemyList[i];
                enemy.BossStatsDraw(sb);
            }
        }
    }
}
