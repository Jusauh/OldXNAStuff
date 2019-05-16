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
using TowerDefence.Game;

namespace TowerDefence
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MainLoop mainLoop = new MainLoop();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            MediaPlayer.IsRepeating = true;
            graphics.IsFullScreen = false;
            graphics.SynchronizeWithVerticalRetrace = false;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Assests.LoadAssests(Content);
            MusicEngine.PlayMusic(Assests.music01);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Input.UpdateState();
            MasterVolume.Update();
            MusicEngine.UpdateMusicPlayer();
            SFXEngine.UpdateSFX();
            mainLoop.Update();
            FontManager.Update();
            ButtonManager.Update();
            GameTimer.Update(gameTime);

            // Allows the game to exit
            if (Lists.onScreenButtonList[Lists.onScreenButtonList.Count - 1].pressed && MainLoop.gameState == MainLoop.GameState.mainMenu)
                this.Exit();

            //Musiikki
            if (Input.IsKeyPressed(Keys.Z))
            {
                MusicEngine.ChangeSong(Assests.music01, 100);
            }
            if (Input.IsKeyPressed(Keys.X))
            {
                MusicEngine.ChangeSong(Assests.music02, 100);
            }
            if (Input.IsKeyPressed(Keys.C)) //Pist‰‰ musiikkien volyymin nollille
            {
                MusicEngine.ChangeVolume(0);
            }
            if (Input.IsKeyPressed(Keys.V)) //Pist‰‰ musiikkien volyymin t‰ysille
            {
                MusicEngine.ChangeVolume(1);
            }
            //ƒ‰nitesti loppuu

            // TODO: Add your update logic here

            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            mainLoop.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
