namespace Survivio.GameObjects.Item.Inventory
{
    public class AmmunitionInventory : SubInventory
    {
        public AmmunitionType AmmunitionType { get; private set; }

        public AmmunitionInventory(AvatarInventory parentInventory, AmmunitionType ammunitionType)
            : base (parentInventory)
        {
            Amount = 0;
            AmmunitionType = ammunitionType;
            CapacityLevels = GetCapacityLevelByAmmunitionType(ammunitionType);
        }

        private int[] GetCapacityLevelByAmmunitionType(AmmunitionType ammunitionType)
        {
            switch (ammunitionType)
            {
                case AmmunitionType.Yellow9mm:
                    return new int[] { 120, 240, 330, 420 };
                case AmmunitionType.Blue762mm:
                    return new int[] { 90, 180, 240, 300 };
                case AmmunitionType.Green556mm:
                    return new int[] { 90, 180, 240, 300 };
                case AmmunitionType.Red12Gauge:
                    return new int[] { 15, 30, 60, 90 };
                default:
                    return null;
            }
        }
    }
}
