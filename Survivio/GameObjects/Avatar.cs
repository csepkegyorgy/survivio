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

    public class Avatar<TController> : ControlledGameObject<TController>, IRigid where TController : IController
    {
        public AvatarInventory Inventory { get; private set; }

        public Rectangle RigidBody => this.Body.Rectangle;

        public List<Loot> InteractableLoots { get; private set; }

        public Avatar(Texture2D texture, Rectangle body)
            : base(texture, body)
        {
            this.Speed = GameConfig.GameObjectStandards.AvatarStandards.StandardAvatarSpeed;
            this.Inventory = new AvatarInventory(this as Avatar<IController>);
            this.InteractableLoots = new List<Loot>();
            this.DrawPriority = DrawPriority.High;
        }

        public override void SuccessfulMovementPostActions()
        {
            List<Loot> lootsToRemove = new List<Loot>();
            foreach (var item in InteractableLoots)
            {
                if (!this.CollidesWith(item.CollisionRectangles))
                {
                    lootsToRemove.Add(item);
                }
            }
            InteractableLoots.RemoveAll(x => lootsToRemove.Contains(x));
        }
    }
}
