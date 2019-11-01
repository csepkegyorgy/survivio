namespace Survivio
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Survivio.Extensions;
    using Survivio.GameObjects;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Global;
    using Survivio.GameObjects.Mechanisms.Controller;

    public class SurvivioMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Avatar<KeyboardMouseController> player;
        Obstacle box;
        Point mousePosition;
        GameWorld gameWorld;

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

            gameWorld = new GameWorld(1900, 1100);
            player = new Avatar<KeyboardMouseController>(new KeyboardMouseController(), gameWorld, ContentAccessor.CircleColoredTest, new Rectangle(200, 200, 50, 50));
            box = new Obstacle(gameWorld, ContentAccessor.ObstacleCrate1, new Rectangle(50, 50, 100, 100));
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
                mousePosition = Mouse.GetState().Position;

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

                foreach (var item in gameWorld.CollisionRealms)
                {
                    SpriteBatchExtensions.DrawHollowRectangle(item.Area.Location, item.Area.Width, item.Area.Height, 2, Color.Gray);
                }

                player.DrawWithDevBorder();
                box.DrawWithDevBorder();

                spriteBatch.DrawString(ContentAccessor.StandardFont, player.Rotation.ToString(), new Vector2(30, 30), Color.Black);
                spriteBatch.DrawString(ContentAccessor.StandardFont, $"MouseState: {mousePosition.X} {mousePosition.Y}", new Vector2(130, 30), Color.Black);

                SpriteBatchExtensions.DrawHollowRectangle(mousePosition, 3, 3, 3, Color.Red);

                spriteBatch.End();
                base.Draw(gameTime);

                nextDraw = gameTime.TotalGameTime.TotalMilliseconds + GameConfig.Delta;
            }
        }
    }
}
