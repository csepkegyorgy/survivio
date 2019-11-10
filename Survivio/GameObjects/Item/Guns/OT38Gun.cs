namespace Survivio.GameObjects.Item.Guns
{
    using Survivio.GameObjects.Item.Base;

    public class OT38Gun : GunWeaponItem
    {
        public OT38Gun()
            : base(ContentAccessor.GunShort, GameConfig.GameObjectStandards.WeaponStandards.GetStandardShortGunBody(), ContentAccessor.WeaponIconOT38)
        {
            this.InitializeGun(
                Inventory.AmmunitionType.Blue762mm,
                26,
                2,
                0.4,
                5,
                0
                );
        }
    }
}
