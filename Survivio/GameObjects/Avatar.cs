namespace Survivio.GameObjects
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Global;
    using Survivio.GameObjects.Mechanisms.Collision;
    using Survivio.GameObjects.Mechanisms.Controller;

    public class Avatar<TController> : ControlledGameObject<TController>, IRigid where TController : IController
    {
        public Avatar(Texture2D texture, Rectangle body)
            : base(texture, body)
        {
            this.Speed = GameConfig.StandardAvatarSpeed;
        }

        public Rectangle RigidBody => this.Body.Rectangle;
    }
}
