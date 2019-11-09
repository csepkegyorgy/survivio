namespace Survivio.GameObjects.Item.Ammunitions
{
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Item.Base;

    public class Blue762Ammunition : AmmunitionItem
    {
        public Blue762Ammunition()
            : base(ContentAccessor.Ammo762mm, GameConfig.GameObjectStandards.AmmunitionStandards.GetStandardAmmunitionBody(), ContentAccessor.Ammo762mm)
        {
        }

        public Blue762Ammunition(int amount)
            : this()
        {
            this.Amount = amount;
        }
    }
}
