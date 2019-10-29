namespace Survivio.GameObjects
{
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Mechanisms.Controller;

    public class Avatar<TController> : ControlledGameObject<TController> where TController : IController
    {
        public Avatar(TController controller)
            : base(controller)
        {
            this.Speed = GameConfig.StandardAvatarSpeed;
        }
    }
}
