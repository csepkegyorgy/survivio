namespace Survivio.GameObjects.Item.Inventory
{
    public abstract class SubInventory
    {
        public AvatarInventory ParentInventory { get; protected set; }

        public int[] CapacityLevels { get; protected set; }

        public int Amount { get; protected set; }

        public SubInventory(AvatarInventory parentInventory)
        {
            this.ParentInventory = parentInventory;
        }

        // Returns the reduced amount 
        public int ReduceAmount(int value)
        {
            if (value <= Amount)
            {
                Amount -= value;
                return value;
            }
            else
            {
                int returnValue = Amount;
                Amount = 0;
                return returnValue;
            }
        }

        // Returns the leftover ammunition
        public int AddAmount(int value)
        {
            int currentMaximum = CapacityLevels[(int)ParentInventory.BackpackLevel];
            if (Amount < currentMaximum)
            {
                Amount += value;
                int leftover = 0;
                if (Amount > currentMaximum)
                {
                    leftover = currentMaximum - Amount;
                    Amount = currentMaximum;
                }
                return leftover;
            }
            else
            {
                return 0;
            }
        }
    }
}
