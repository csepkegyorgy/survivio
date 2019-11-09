namespace Survivio.GameObjects.Item.Inventory.Consumables
{
    public class BandageInventory : SubInventory
    {
        public BandageInventory(AvatarInventory parentInventory)
            : base(parentInventory)
        {
            this.CapacityLevels = new int[] { 5, 10, 15, 30 };
        }
    }
}
