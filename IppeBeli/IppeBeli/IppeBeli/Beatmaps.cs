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

namespace IppeBeli
{
    class Beatmaps
    {
        public static List<char> beatmap1;
        public static List<char> beatmap2;

        public static float beatmap1_BPM = 160.0f;
        public static float beatmap2_BPM = 160.0f;
        public static Song beatmap1_Song;
        public static Song beatmap2_Song;


        public static void InitializeBeatmaps()
        {
            InitializeBeatmap1();
            InitializeBeatmap2();
        }

        static void InitializeBeatmap1()
        {
            beatmap1 = new List<char>();
            beatmap1_Song = Assets.turuponpon;

            beatmap1.Add('4');
            beatmap1.Add('o');
            beatmap1.Add('o');
            beatmap1.Add('o');
            beatmap1.Add('o');

            beatmap1.Add('o');
            beatmap1.Add('o');
            beatmap1.Add('o');
            beatmap1.Add('o');

            beatmap1.Add('o');
            beatmap1.Add('o');
            beatmap1.Add('o');
            beatmap1.Add('o');

            beatmap1.Add('o');
            beatmap1.Add('o');
            beatmap1.Add('o');
            beatmap1.Add('o');
            // PART 1
            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('8');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('y');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('8');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('y');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('8');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('y');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('8');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('y');
            // PART 2
            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('8');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('y');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('8');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('y');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('8');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('y');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('8');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('y');
            // PART 4
            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');
            // PART 5
            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');

            // PART7
            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('y');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');

            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('y');

            // PART7
            /*
            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');

            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');

            beatmap1.Add('S');
            beatmap1.Add('x');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('y');
            beatmap1.Add('x');

            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('y');
            beatmap1.Add('o');
            beatmap1.Add('x');
            beatmap1.Add('x');
            beatmap1.Add('x');
            */
        }

        static void InitializeBeatmap2()
        {
            beatmap2 = new List<char>();
            beatmap2_Song = Assets.liikaaES;

            beatmap2.Add('4');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');

            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');

            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');

            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('x');
            beatmap2.Add('y');
            beatmap2.Add('x');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');

            beatmap2.Add('8');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('x');
            beatmap2.Add('x');
            beatmap2.Add('y');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('y');
            beatmap2.Add('o');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('y');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('x');
            beatmap2.Add('y');
            beatmap2.Add('y');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('y');
            beatmap2.Add('o');
            beatmap2.Add('o');

            beatmap2.Add('S');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('x');
            beatmap2.Add('x');
            beatmap2.Add('x');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('y');
            beatmap2.Add('o');
            beatmap2.Add('o');
            beatmap2.Add('o');

            beatmap2.Add('8');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('y');
            beatmap2.Add('o');
            beatmap2.Add('o');

            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('o');
            beatmap2.Add('x');
            beatmap2.Add('x');
            beatmap2.Add('y');
            beatmap2.Add('y');


        }

    }
}
