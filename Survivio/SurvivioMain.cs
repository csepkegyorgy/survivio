namespace Survivio
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Survivio.Extensions;
    using Survivio.GameObjects;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Global;
    using Survivio.GameObjects.Item.Ammunitions;
    using Survivio.GameObjects.Mechanisms.Camera;
    using Survivio.GameObjects.Mechanisms.Collision;
    using Survivio.GameObjects.Mechanisms.Controller;
    using System.Linq;

    public class SurvivioMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Avatar<KeyboardMouseController> player;
        Obstacle box;
        Blue762Ammunition blueAmmo;

        Point mousePosition;
        Point mouseWorldPosition;
        GameWorld gameWorld;
        Camera camera;

        double nextDraw = 0;
        double nextUpdate = 0;

        public SurvivioMain()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GameConfig.ScreenWidth;
            graphics.PreferredBackBufferHeight = GameConfig.ScreenHeight;
            graphics.ApplyChanges();

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

            gameWorld.AddNewGameObject(player = 
                new Avatar<KeyboardMouseController>(
                    ContentAccessor.CircleColoredTest,
                    GameConfig.GameObjectStandards.AvatarStandards.GetStandardAvatarBody(200, 200)
                    ));

            gameWorld.AddNewGameObject(box =
                new Obstacle(
                    gameWorld,
                    ContentAccessor.ObstacleCrate1,
                    new Rectangle(50, 50, 100, 100)));

            gameWorld.AddNewGameObject(blueAmmo =
                new Blue762Ammunition(
                    60
                    ));
            blueAmmo.Move(500, 500);

            camera = new Camera(player);
            SpriteBatchExtensions.Camera = camera;
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
                mouseWorldPosition = mousePosition - SpriteBatchExtensions.Camera.GetCameraShift().ToPoint();

                camera.UpdateCamera();

                base.Update(gameTime);

                nextUpdate = gameTime.TotalGameTime.TotalMilliseconds + GameConfig.Delta;
            }
        }
        
        protected override void Draw(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds + GameConfig.Delta >= nextDraw)
            {
                GraphicsDevice.Clear(Color.LawnGreen);
                spriteBatch.Begin();


                foreach (CollisionRealm item in gameWorld.CollisionRealms)
                {
                    SpriteBatchExtensions.DrawHollowRectangle(item.Area.Location, item.Area.Width, item.Area.Height, 2, Color.Gray);

                    item.CollisionRealmId.ToString().DrawString(new Vector2(item.Area.Center.X, item.Area.Center.Y), new Color(0, 0, 0, 64), 3);
                }

                foreach (GameObject item in gameWorld.GameObjects.Where(x => x.DrawPriority != DrawPriority.Invisible).OrderBy(x => x.DrawPriority))
                {
                    item.Draw(true);
                }



                player.Rotation.ToString().DrawStringOnScreen(new Vector2(30, 30));
                ($"MouseState: {mousePosition.X} {mousePosition.Y}").DrawStringOnScreen(new Vector2(130, 30));
                ($"MouseState (world): {mouseWorldPosition.X} {mouseWorldPosition.Y}").DrawStringOnScreen(new Vector2(130, 70));
                ($"Player collision realms: {string.Join(" ", player.CollisionRealms.Select(x => x.CollisionRealmId.ToString()).ToArray())}").DrawStringOnScreen(new Vector2(400, 30), new Color(0, 0, 0, 128));
                ($"Box collision realms: {string.Join(" ", box.CollisionRealms.Select(x => x.CollisionRealmId.ToString()).ToArray())}").DrawStringOnScreen(new Vector2(400, 130), new Color(500, 0, 0, 128));
                
                SpriteBatchExtensions.DrawHollowRectangleUnshifted(mousePosition, 3, 3, 3, Color.Red);

                SpriteBatchExtensions.DrawHollowRectangle(gameWorld.Area.Location, gameWorld.Area.Width, gameWorld.Area.Height, 5, Color.Black);

                spriteBatch.End();
                base.Draw(gameTime);

                nextDraw = gameTime.TotalGameTime.TotalMilliseconds + GameConfig.Delta;
            }
        }
    }
}
