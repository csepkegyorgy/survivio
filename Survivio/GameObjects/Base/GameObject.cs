namespace Survivio.GameObjects.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    /// <summary>
    /// A visible game object.
    /// </summary>
    public abstract class GameObject
    {
        public Texture2D Texture { get; set; }

        public RectangleD Body { get; set; }

        public double Speed { get; set; }

        // Rotation in degrees
        // 0    : object facing to the right
        // 90   : object facing up
        // 180  : object facing to the left
        // 270  : object facing down
        public int Rotation { get; set; }
    }
}
