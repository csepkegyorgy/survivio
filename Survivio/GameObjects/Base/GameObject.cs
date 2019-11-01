namespace Survivio.GameObjects.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Global;
    using Survivio.GameObjects.Mechanisms.Collision;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A visible game object.
    /// </summary>
    public abstract class GameObject
    {
        public static int NextId { get; private set; }

        public int EntityId { get; }

        public List<CollisionRealm> CollisionRealms { get; }

        public Texture2D Texture { get; }

        public RectangleD Body { get; }

        public GameWorld GameWorld { get; }

        public double Speed { get; set; }

        // Rotation in degrees
        // 0    : object facing to the right
        // 90   : object facing up
        // 180  : object facing to the left
        // 270  : object facing down
        public int Rotation { get; set; }

        public virtual List<Rectangle> CollisionRectangles
        {
            get
            {
                return new List<Rectangle>() { this.Body.Rectangle };
            }
        }

        static GameObject()
        {
            NextId = 0;
        }

        public GameObject(GameWorld gameWorld, Texture2D texture, Rectangle body)
        {
            this.EntityId = NextId;
            NextId++;

            this.GameWorld = gameWorld;
            this.Texture = texture;
            this.Body = new RectangleD(body.X, body.Y, body.Width, body.Height);

            CollisionRealms = new List<CollisionRealm>();
            UpdateCollisionRealms();
        }

        private void UpdateCollisionRealms()
        {
            Rectangle body = this.Body.Rectangle;
            this.CollisionRealms.Clear();
            foreach (CollisionRealm collisionRealm in GameWorld.CollisionRealms)
            {
                if (body.Intersects(collisionRealm.Area))
                {
                    this.CollisionRealms.Add(collisionRealm);
                    if (!collisionRealm.GameObjects.Contains(this))
                    {
                        collisionRealm.GameObjects.Add(this);
                    }
                }
            }
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

        public virtual bool Collide(GameObject gameObject)
        {
            if (gameObject is IRigid)
            {
                return true;
            }

            return false;
        }

        public void Move(double x, double y)
        {
            bool cancelMovement = false;
            // Check if object would leave the game world's bounds
            // TODO

            // Handle collision
            List<GameObject> gameObjects = CollisionRealms
                .SelectMany(g => g.GameObjects)
                .Where(g => g.EntityId != this.EntityId)
                .GroupBy(g => g.EntityId)
                .Select(g => g.First())
                .ToList();

            this.Body.Offset(x, y);
            foreach (var item in gameObjects)
            {
                if (this.CollidesWith(item.Body.Rectangle))
                {
                    if (this.Collide(item))
                    {
                        cancelMovement = true;
                    }
                    if (item.Collide(this))
                    {
                        cancelMovement = true;
                    }
                }
            }

            // Check if object transitions between collision realms and update if so
            if (cancelMovement)
            {
                this.Body.Offset(-x, -y);
            }
            else
            {
                UpdateCollisionRealms();
            }
        }
    }
}
