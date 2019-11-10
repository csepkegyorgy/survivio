namespace Survivio.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Item;
    using Survivio.GameObjects.Item.Inventory;
    using Survivio.GameObjects.Mechanisms.Collision;
    using Survivio.GameObjects.Mechanisms.Controller;
    using System.Collections.Generic;
    using System.Linq;

    public class Avatar : ControlledGameObject, IRigid
    {
        public AvatarInventory Inventory { get; private set; }

        public Rectangle RigidBody => this.Body.Rectangle;

        private List<GameObject> InteractableGameObjectsPrivate;
        public List<GameObject> InteractableGameObjects => InteractableGameObjectsPrivate.ToList();

        public Avatar(Texture2D texture, Rectangle body, Controller controller)
            : base(texture, body, controller)
        {
            this.Speed = GameConfig.GameObjectStandards.AvatarStandards.StandardAvatarSpeed;
            this.Inventory = new AvatarInventory(this);
            this.InteractableGameObjectsPrivate = new List<GameObject>();
            this.DrawPriority = DrawPriority.High;
        }

        public override void MovementPreActions()
        {
            List<GameObject> objectsToRemove = new List<GameObject>();
            foreach (GameObject item in InteractableGameObjectsPrivate)
            {
                if (item.GameWorld == null || !this.CollidesWith(item.CollisionRectangles))
                {
                    objectsToRemove.Add(item);
                }
            }
            InteractableGameObjectsPrivate.RemoveAll(x => objectsToRemove.Contains(x));
        }

        public void AddInteractableGameObject(GameObject gameObject)
        {
            if (!InteractableGameObjectsPrivate.Contains(gameObject))
                InteractableGameObjectsPrivate.Add(gameObject);
        }

        public void RemoveInteractableGameObject(GameObject gameObject)
        {
            if (InteractableGameObjectsPrivate.Contains(gameObject))
                InteractableGameObjectsPrivate.RemoveAll(x => x.EntityId == gameObject.EntityId);
        }
    }
}
