namespace Survivio
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ContentAccessor
    {
        private ContentManager Content;

        public ContentAccessor(ContentManager contentManager)
        {
            this.Content = contentManager;
        }

        public void LoadContent()
        {
            standardFont = Content.Load<SpriteFont>("basicspritefont");
            emptyTexture = Content.Load<Texture2D>("emptytexture");
            transparentTexture = Content.Load<Texture2D>("transparenttexture");
            circleFilledBlack = Content.Load<Texture2D>("circle_filled_black");
            circleColoredTest = Content.Load<Texture2D>("circle_colored_test");
        }

        private static SpriteFont standardFont;
        public static SpriteFont StandardFont { get => standardFont; }

        private static Texture2D emptyTexture;
        public static Texture2D Empty { get => emptyTexture; }

        private static Texture2D transparentTexture;
        public static Texture2D Transparent { get => transparentTexture; }

        private static Texture2D circleFilledBlack;
        public static Texture2D CircleFilledBlack { get => circleFilledBlack; }

        private static Texture2D circleColoredTest;
        public static Texture2D CircleColoredTest { get => circleColoredTest; }
    }
}
