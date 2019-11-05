namespace Survivio.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Global;
    using Survivio.GameObjects.Mechanisms.Collision;

    public class Obstacle : GameObject, IRigid
    {
        public Obstacle(GameWorld gameWorld, Texture2D texture, Rectangle body)
            : base(texture, body)
        {
        }

        public Rectangle RigidBody => this.Body.Rectangle;
    }
}
