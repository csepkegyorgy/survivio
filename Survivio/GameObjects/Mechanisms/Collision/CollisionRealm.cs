namespace Survivio.GameObjects.Mechanisms.Collision
{
    using Microsoft.Xna.Framework;
    using Survivio.GameObjects.Base;
    using System.Collections.Generic;
    using System.Linq;

    public class CollisionRealm
    {
        public List<GameObject> GameObjectsPrivate;
        public List<GameObject> GameObjects => GameObjectsPrivate.ToList();

        public Rectangle Area { get; }

        public int CollisionRealmId { get; private set; }

        public CollisionRealm(int x, int y, int id)
        {
            this.CollisionRealmId = id;
            this.GameObjectsPrivate = new List<GameObject>();
            this.Area = new Rectangle(x, y, GameConfig.CollisionRealmSize, GameConfig.CollisionRealmSize);
        }

        public void RemoveGameObject(GameObject obj)
        {
            if (this.GameObjectsPrivate.Contains(obj))
                this.GameObjectsPrivate.RemoveAll(x => x == obj);
        }

        public void AddGameObject(GameObject obj)
        {
            if (!this.GameObjectsPrivate.Contains(obj))
                this.GameObjectsPrivate.Add(obj);
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
