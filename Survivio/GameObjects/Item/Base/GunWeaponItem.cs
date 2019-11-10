namespace Survivio.GameObjects.Item.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Item.Inventory;

    public abstract class GunWeaponItem : Item
    {
        public AmmunitionType AmmunitionType { protected get; set; }

        public int BulletDamage { get; protected set; }

        public double ReloadTime { get; protected set; }

        public double FiringDelay { get; protected set; }

        public int BulletCapacity { get; protected set; }

        public int BulletsLoaded { get; protected set; }

        public GunWeaponItem(Texture2D texture, Rectangle body, Texture2D iconTexture)
            : base(texture, iconTexture)
        {
        }

        protected void InitializeGun(AmmunitionType ammunitionType, int bulletDamage, double reloadTime, double firingDelay, int bulletCapacity, int bulletsLoaded)
        {
            this.AmmunitionType = ammunitionType;
            this.BulletDamage = bulletDamage;
            this.ReloadTime = reloadTime;
            this.FiringDelay = firingDelay;
            this.BulletCapacity = bulletCapacity;
            this.BulletsLoaded = bulletsLoaded;
        }
    }
}
