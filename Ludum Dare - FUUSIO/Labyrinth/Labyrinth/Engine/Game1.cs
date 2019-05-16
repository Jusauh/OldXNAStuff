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
using Labyrinth.Engine;
using Labyrinth.Objects;

namespace Labyrinth
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Objects & Variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SceneManager sceneManager;

        Song bgm;

        public static Rectangle screenSize;

        public Game1()
        {
            // Changing the resolution to 1080x666
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 666;
            graphics.PreferredBackBufferWidth = 1080;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Initializing objects and variables things
            Recources.Initialize(Content);
            
            screenSize = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            sceneManager = new SceneManager();
            MediaPlayer.IsRepeating = true;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Initializing more objects and variables
            spriteBatch = new SpriteBatch(GraphicsDevice);
            DrawSys.InitializeDraw(spriteBatch);

            bgm = Content.Load<Song>("Creepypasta luolajukka");
            Recources.LoadTexture("Light");
            Recources.LoadTexture("Tile");


            MediaPlayer.Play(bgm);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            // setting the deltatime
            float deltaTime = gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            
            
            
            // If esc is pressed the game shuts down
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            
            // Updates
            Input.UpdateState();
            sceneManager.Update(deltaTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Background color
            GraphicsDevice.Clear(Color.DarkGoldenrod);

            // Begin and end drawing
            spriteBatch.Begin();

            sceneManager.Draw();
            Cursor.Draw();
            
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
