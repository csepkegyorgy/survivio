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
            obstacleCrate1 = Content.Load<Texture2D>("obstacle-crate-01");
            ammo762mm = Content.Load<Texture2D>("ammo-762mm");
            lootCircleOuter01 = Content.Load<Texture2D>("loot-circle-outer-01");
            weaponIconOT38 = Content.Load<Texture2D>("loot-weapon-ot38");
            gunShort = Content.Load<Texture2D>("gun-short");
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

        private static Texture2D obstacleCrate1;
        public static Texture2D ObstacleCrate1 { get => obstacleCrate1; }

        private static Texture2D ammo762mm;
        public static Texture2D Ammo762mm { get => ammo762mm; }

        private static Texture2D lootCircleOuter01;
        public static Texture2D LootCircleOuter01 { get => lootCircleOuter01; }

        private static Texture2D gunShort;
        public static Texture2D GunShort { get => gunShort; }

        private static Texture2D weaponIconOT38;
        public static Texture2D WeaponIconOT38 { get => weaponIconOT38; }
    }
}
