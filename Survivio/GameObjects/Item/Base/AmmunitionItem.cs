namespace Survivio.GameObjects.Item.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class AmmunitionItem : Item
    {
        public int Amount { get; protected set; }

        public AmmunitionItem(Texture2D texture, Rectangle body, Texture2D iconTexture)
            : base(texture, body, iconTexture)
        {
        }

        public void SetAmount(int amount)
        {
            if (Amount + amount > GameConfig.GameObjectStandards.AmmunitionStandards.StandardMaxAmmunitionAmountInOneLootInstance)
            {
                Amount = GameConfig.GameObjectStandards.AmmunitionStandards.StandardMaxAmmunitionAmountInOneLootInstance;
            }
            else
            {
                Amount += amount;
            }
        }
    }
}
