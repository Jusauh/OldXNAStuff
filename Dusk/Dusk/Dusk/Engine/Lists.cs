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
using Dusk.Player;
using Dusk.EnemyData;
using Dusk.Items;

namespace Dusk.Engine
{
    class Lists
    {
        public static List<EnemyPrime> enemyList = new List<EnemyPrime>();
        public static List<Bullet> bulletList = new List<Bullet>();
        public static List<Bullet> bulletTemp = new List<Bullet>();
        public static List<ItemPrime> itemList = new List<ItemPrime>();

        public static List<FX> FXList = new List<FX>();

        public static List<Player.Player> playerList = new List<Player.Player>();
        public static List<Player.PlayerBulletPrime> playerBulletList = new List<PlayerBulletPrime>();
        public static List<Player.Bomb> bomb = new List<Bomb>();

    }
}
