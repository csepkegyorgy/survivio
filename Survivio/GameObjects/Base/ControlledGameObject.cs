namespace Survivio.GameObjects.Base
{
    using Survivio.GameObjects.Mechanisms.Controller;
    using System;

    public abstract class ControlledGameObject<TController> : GameObject where TController : IController
    {
        public TController Controller { get; }

        public ControlledGameObject(TController controller)
            : base()
        {
            this.Controller = controller;
            controller.BindObject(this);
        }
    }
}
