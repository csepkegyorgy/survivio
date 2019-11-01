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
        public Avatar(TController controller, GameWorld gameWorld, Texture2D texture, Rectangle body)
            : base(controller, gameWorld, texture, body)
        {
            this.Speed = GameConfig.StandardAvatarSpeed;
        }
    }
}
