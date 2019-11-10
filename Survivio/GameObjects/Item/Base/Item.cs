namespace Survivio.GameObjects.Item.Base
{
    using Microsoft.Xna.Framework.Graphics;

    public class Item
    {
        public Texture2D LootTexture { get; private set; }

        public Texture2D Texture { get; private set; }

        public Item(Texture2D texture, Texture2D lootTexture)
        {
            this.Texture = texture;
            this.LootTexture = lootTexture;
        }
    }
}
