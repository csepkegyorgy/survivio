namespace Survivio.GameObjects.Item.Inventory.Consumables
{
    public class MedKitInventory : SubInventory
    {
        public MedKitInventory(AvatarInventory parentInventory)
            : base(parentInventory)
        {
            this.CapacityLevels = new int[] { 1, 2, 3, 4 };
        }
    }
}
