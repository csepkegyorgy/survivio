namespace Survivio.GameObjects.Item.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class GunWeaponItem : Item
    {
        public int BulletDamage { get; protected set; }

        public double ReloadTime { get; protected set; }

        public double FiringDelay { get; protected set; }

        public int BulletCapacity { get; protected set; }

        public int BulletsLoaded { get; protected set; }

        public GunWeaponItem(Texture2D texture, Rectangle body, Texture2D iconTexture)
            : base(texture, body, iconTexture)
        {
        }

        protected void InitializeGun(int bulletDamage, double reloadTime, double firingDelay, int bulletCapacity, int bulletsLoaded)
        {
            this.BulletDamage = bulletDamage;
            this.ReloadTime = reloadTime;
            this.FiringDelay = firingDelay;
            this.BulletCapacity = bulletCapacity;
            this.BulletsLoaded = bulletsLoaded;
        }
    }
}
