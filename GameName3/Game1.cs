using GameFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameName3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : GameFramework.GameHost
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            Textures.Add("Ball", this.Content.Load<Texture2D>("Ball"));
            Textures.Add("Box", this.Content.Load<Texture2D>("Box"));
            Fonts.Add("Kootenay", this.Content.Load<SpriteFont>("Kootenay"));

            ResetGame();
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
            // TODO: Add your update logic here
            UpdateAll(gameTime);
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
            DrawSprites(gameTime, spriteBatch);
            DrawText(gameTime, spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void ResetGame()
        {
            TextObject message;
            GameObjects.Clear();
            for(int i = 0; i < 10; i++)
            {
                GameObjects.Add(new BoxObject(this, Textures["Box"]));
            }
            for (int i = 0; i < 10; i++)
            {
                GameObjects.Add(new BoxObject(this, Textures["Ball"]));
            }
            message = new TextObject(this, Fonts["Kootenay"], new Vector2(GraphicsDevice.Viewport.Bounds.Width / 2, GraphicsDevice.Viewport.Bounds.Height / 2),
                "MonoGame Game Development", TextObject.TextAlignment.Center, TextObject.TextAlignment.Center);
            message.SpriteColor = Color.DarkBlue;
            message.Scale = new Vector2(1.0f, 1.5f);
            GameObjects.Add(message);
        }
    }
}
