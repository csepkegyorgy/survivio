namespace Survivio.GameObjects.Base
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;
    using System.Linq;

    public class CollisionRealm
    {
        public List<GameObject> GameObjects { get; }

        public Rectangle Area { get; }

        public CollisionRealm(int x, int y)
        {
            this.GameObjects = new List<GameObject>();
            this.Area = new Rectangle(x, y, GameConfig.CollisionRealmSize, GameConfig.CollisionRealmSize);
        }

        public List<GameObject> CheckCollision(GameObject gameObject)
        {
            List<GameObject> result = new List<GameObject>();
            foreach (GameObject item in GameObjects.Where(o => o.EntityId != gameObject.EntityId))
            {
                if (item.CollidesWith(item.CollisionRectangles))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
