namespace Survivio.GameObjects.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Global;
    using Survivio.GameObjects.Mechanisms.Controller;

    public abstract class ControlledGameObject<TController> : GameObject where TController : IController
    {
        public TController Controller { get; }

        public ControlledGameObject(TController controller, GameWorld gameWorld, Texture2D texture, Rectangle body)
            : base(gameWorld, texture, body)
        {
            this.Controller = controller;
            controller.BindObject(this);
        }
    }
}
