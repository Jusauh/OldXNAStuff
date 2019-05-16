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


namespace WindowsGame1
{
    enum GameState
    {
        MainMenu,
        Game,
        EndScreen
    }


    class JvsIMain
    {
        InGame Game = new InGame();
        Ending endScreen = new Ending();
        public static GameState gameState = GameState.MainMenu;
        public static Player player1;
        public static Player player2;

        int frame;
        int alpha1 = 0;
        int alpha1mod = 2;
        int alpha2 = 255;
        float scale = 0;
        float angle;
        double theSin;
        double theCos;

        KeyboardState kb;

        void MenuSceneInitialise()
        {
            frame = 0;
            alpha1 = 0;
            alpha1mod = 2;
            alpha2 = 255;
            scale = 0;
            angle = 0;
            theSin = 0;
            theCos = 0;
        }

        void Initialise()
        {
            MediaPlayer.IsRepeating = true;
            player1 = new Player(1, Assests.jukkaSprite, Color.White);
            player2 = new Player(2, Assests.ippeSprite, Color.White);
            MediaPlayer.Play(Assests.BGM03);
            gameState = GameState.Game;
        }
        void MainMenu()
        {
            StartScene();

            if (MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.Play(Assests.BGM02);
                MenuSceneInitialise();
            }
            
            if (kb.IsKeyDown(Keys.Enter))      
                Initialise();
        }

        void StartScene()
        {
            frame++;

            theSin = Math.Sin(MathHelper.ToRadians(frame));
            theCos = Math.Cos(MathHelper.ToRadians(frame));

            if (frame > 1000 && frame < 1090)
                scale += (0.01f);

            if (frame < 1090)
                angle += 0.06f;
            else
                angle += 0.01f;

            if (frame == 1090)
                alpha2 = 0;

            if (alpha2 < 255)
                alpha2 += 5;


            if (alpha1 > 255)
                alpha1mod *= -1;
            if (alpha1 < 0)
                alpha1mod *= -1;
                alpha1 += alpha1mod;
        }
        
        public void Update()
        {
            kb = Keyboard.GetState();
            switch (gameState)
            {
                case GameState.MainMenu:
                    MainMenu();
                    break;
                case GameState.Game:
                    Game.Update();
                    break;
                case GameState.EndScreen:
                    endScreen.Update();
                    if (kb.IsKeyDown(Keys.Space))
                    {
                        gameState = GameState.MainMenu;
                        MediaPlayer.Stop();
                        MenuSceneInitialise();
                        angle = 0;
                    }
                    break;
            }
            
        }

        public void Draw(SpriteBatch sb)
        {
            switch (gameState)
            {
                case GameState.MainMenu:

                    sb.Draw(Assests.menuBG, new Vector2(0, 0), new Color(0,0,0,255));
                    sb.DrawString(Assests.font, "PRESS ENTER", new Vector2(333, 400), new Color(alpha1, alpha1, alpha1, alpha1));
                    if(frame <= 256)
                    sb.DrawString(Assests.font, "In the year 2020, the timespace was in complete human control. \n The war for it lasted for ages, horrible things were done...", new Vector2(50, 100), new Color(alpha1,alpha1,alpha1,alpha1));
                    else if (frame > 256 && frame <= 256*2)
                        sb.DrawString(Assests.font, " ...But then, two heroes emerged, trying to claim \nthe timespace in their own hands and end the war...", new Vector2(130, 100), new Color(alpha1, alpha1, alpha1, alpha1));
                    else if (frame > 256 * 2 && frame <= 256 * 3)
                        sb.DrawString(Assests.font, "...being equally powerful, the timespace remained untouched from them.\n             The world waited for their conflicts end...", new Vector2(10, 100), new Color(alpha1, alpha1, alpha1, alpha1));
                    else if (frame > 256 * 3 && frame <= 256 * 4)
                        sb.DrawString(Assests.font, "...Now, the time has come to decide the winner for once and for all!", new Vector2(15, 100), new Color(alpha1, alpha1, alpha1, alpha1));                
                    
                    if (frame > 1090)
                    {
                        sb.Draw(Assests.jukkaSprite, new Vector2(395 + (float)theCos * 300, 250 + (float)theSin * 190), null, Color.White,0, new Vector2(25, 37), (1f + (float)theSin / 3), SpriteEffects.None, 0);
                        sb.Draw(Assests.ippeSprite, new Vector2(395 - (float)theCos * 300, 250 - (float)theSin * 190), null, Color.White,0, new Vector2(25, 37), (1f - (float)theSin / 3), SpriteEffects.None, 0);
                        sb.DrawString(Assests.font, "JUKKA vs IPPE, The Heroes of Timespace", new Vector2(190, 50), new Color(alpha1, alpha1, alpha1, alpha1));
                    }
                    sb.Draw(Assests.earth, new Vector2(395, 250), null, Color.White, 0, new Vector2(120, 120), 0.7f, SpriteEffects.None, 0);
                    if (frame > 1000)
                        sb.Draw(Assests.timeWheel, new Vector2(395, 250), null, Color.White, -angle, new Vector2(150, 150), scale, SpriteEffects.None, 0);
                    sb.Draw(Assests.menuBG, new Vector2(0, 0), new Color(255-alpha2,255-alpha2,255-alpha2,255-alpha2));
                    break;
                case GameState.Game:
                    Game.Draw(sb);
                    break;
                case GameState.EndScreen:
                    endScreen.Draw(sb);
                    break;
            }
        }

    }
}
