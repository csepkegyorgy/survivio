﻿namespace Survivio.GameObjects.Item.Guns
{
    using Survivio.GameObjects.Item.Base;

    public class OT38Gun : GunWeaponItem
    {
        public OT38Gun()
            : base(ContentAccessor.GunShort, GameConfig.GameObjectStandards.WeaponStandards.GetStandardShortGunBody(), ContentAccessor.WeaponIconOT38)
        {
        }
    }
}