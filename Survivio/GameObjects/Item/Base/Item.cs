namespace Survivio.GameObjects.Item.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Base;

    public class Item : GameObject, IIconed
    {
        public Texture2D IconTexture { get; private set; }

        public Item(Texture2D texture, Rectangle body, Texture2D iconTexture)
            : base(texture, body)
        {
            this.IconTexture = iconTexture;
        }
    }
}
