namespace Survivio.GameObjects.Item.Inventory.Consumables
{
    public class PillsInventory : SubInventory
    {
        public PillsInventory(AvatarInventory parentInventory)
            : base(parentInventory)
        {
            this.CapacityLevels = new int[] { 1, 2, 3, 4 };
        }
    }
}
