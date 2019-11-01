namespace Survivio.GameObjects.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    /// <summary>
    /// A visible game object.
    /// </summary>
    public abstract class GameObject
    {
        public static int NextId { get; private set; }

        public int EntityId { get; }

        public CollisionRealm CollisionRealm { get; }

        public Texture2D Texture { get; set; }

        public RectangleD Body { get; set; }

        public double Speed { get; set; }

        // Rotation in degrees
        // 0    : object facing to the right
        // 90   : object facing up
        // 180  : object facing to the left
        // 270  : object facing down
        public int Rotation { get; set; }

        public List<Rectangle> CollisionRectangles { get; }

        static GameObject()
        {
            NextId = 0;
        }

        public GameObject()
        {
            this.EntityId = NextId;
            NextId++;
        }

        public bool CollidesWith(List<Rectangle> rectangles)
        {
            foreach (Rectangle item in rectangles)
            {
                if (this.Body.Rectangle.Intersects(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CollidesWith(Rectangle rectangle)
        {
            if (this.Body.Rectangle.Intersects(rectangle))
            {
                return true;
            }
            return false;
        }
    }
}
