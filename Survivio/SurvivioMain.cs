namespace Survivio
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Survivio.Extensions;
    using Survivio.GameObjects;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Mechanisms.Controller;

    public class SurvivioMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Avatar<KeyboardMouseController> player;

        double nextDraw = 0;
        double nextUpdate = 0;

        public SurvivioMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteBatchExtensions.MainSpriteBatch = spriteBatch;

            ContentAccessor contentAccessor = new ContentAccessor(Content);
            contentAccessor.LoadContent();

            player = new Avatar<KeyboardMouseController>(new KeyboardMouseController());
            player.Body = new RectangleD(200, 200, 50, 50);
            player.Texture = ContentAccessor.CircleColoredTest;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds + GameConfig.Delta >= nextUpdate)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                player.Controller.HandleState(gameTime, Keyboard.GetState(), Mouse.GetState());

                base.Update(gameTime);

                nextUpdate = gameTime.TotalGameTime.TotalMilliseconds + GameConfig.Delta;
            }
        }
        
        protected override void Draw(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds + GameConfig.Delta >= nextDraw)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();

                player.DrawWithDevBorder();


                spriteBatch.DrawString(ContentAccessor.StandardFont, player.Rotation.ToString(), new Vector2(30, 30), Color.Black);

                spriteBatch.End();
                base.Draw(gameTime);

                nextDraw = gameTime.TotalGameTime.TotalMilliseconds + GameConfig.Delta;
            }
        }
    }
}
