namespace Survivio.GameObjects.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Mechanisms.Controller;
    using System;

    public abstract class ControlledGameObject : GameObject
    {
        public Controller Controller { get; }

        public ControlledGameObject(Texture2D texture, Rectangle body, Controller controller)
            : base(texture, body)
        {
            this.Controller = controller;
            this.Controller.BindObject(this);
            //this.Controller = controller;
            //controller.BindObject(this);
        }
    }
}
