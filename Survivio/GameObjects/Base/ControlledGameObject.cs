namespace Survivio.GameObjects.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Mechanisms.Controller;
    using System;

    public abstract class ControlledGameObject<TController> : GameObject where TController : IController
    {
        public TController Controller { get; }

        public ControlledGameObject(Texture2D texture, Rectangle body)
            : base(texture, body)
        {
            this.Controller = (TController)Activator.CreateInstance(typeof(TController));
            this.Controller.BindObject(this);
            //this.Controller = controller;
            //controller.BindObject(this);
        }
    }
}
