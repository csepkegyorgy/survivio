namespace Survivio.GameObjects.Item.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class ThrowableWeaponItem : Item
    {
        public ThrowableWeaponItem(Texture2D texture, Rectangle body, Texture2D iconTexture)
            : base(texture, body, iconTexture)
        {
        }
    }
}
