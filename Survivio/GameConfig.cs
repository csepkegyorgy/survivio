namespace Survivio
{
    using Microsoft.Xna.Framework;
    using Survivio.GameObjects;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Mechanisms.Controller;

    public static class GameConfig
    {
        public const double FPS = 60;
        public const double Delta = 1000 / FPS;

        public const int CollisionRealmSize = 350;

        public const int ScreenWidth = 1920;
        public const int ScreenHeight = 1080;
        public const int StandardScreenCenterX = ScreenWidth / 2;
        public const int StandardScreenCenterY = ScreenHeight / 2;

        public static class GameObjectStandards
        {
            public static class AvatarStandards
            {
                public const int StandardBodyWidth = 50;
                public const int StandardBodyHeight = 50;

                public const int StandardAvatarSpeed = 130; // per seconds

                public static Rectangle GetStandardAvatarBody(int x = 0, int y = 0)
                {
                    return new Rectangle(x, y, AvatarStandards.StandardBodyWidth, AvatarStandards.StandardBodyHeight);
                }
            }

            public static class WeaponStandards
            {
                public const int StandardShortGunWidth = 10;
                public const int StandardShortGunHeight = 20;

                public static Rectangle GetStandardShortGunBody(int x = 0, int y = 0)
                {
                    return new Rectangle(x, y, WeaponStandards.StandardShortGunWidth, WeaponStandards.StandardShortGunHeight);
                }
            }

            public static class AmmunitionStandards
            {
                public const int StandardAmmunitionWidth = 40;
                public const int StandardAmmunitionHeight = 40;

                public const int StandardMaxAmmunitionAmountInOneLootInstance = 60;

                public static Rectangle GetStandardAmmunitionBody(int x = 0, int y = 0)
                {
                    return new Rectangle(x, y, AmmunitionStandards.StandardAmmunitionWidth, AmmunitionStandards.StandardAmmunitionHeight);
                }
            }

            public static Rectangle GetStandardBody<T>(T gameObject, int x = 0, int y = 0) where T : GameObject
            {
                if (gameObject is Avatar)
                {
                    return AvatarStandards.GetStandardAvatarBody(x, y);
                }
                else
                {
                    return new Rectangle(x, y, gameObject.Texture?.Width ?? 0, gameObject.Texture?.Height ?? 0);
                }
            }
        }
    }
}
