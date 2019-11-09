namespace Survivio.GameObjects.Item.Inventory.Consumables
{
    public class SodaInventory : SubInventory
    {
        public SodaInventory(AvatarInventory parentInventory)
            : base(parentInventory)
        {
            this.CapacityLevels = new int[] { 2, 5, 10, 15 };
        }
    }
}
