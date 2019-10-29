namespace Survivio.GameObjects.Mechanisms.Controller
{
    using Microsoft.Xna.Framework;
    using Survivio.GameObjects.Base;

    public abstract class Controller : IController
    {
        public GameObject ControlledObject { get; private set; }

        public void BindObject(GameObject gameObject)
        {
            if (ControlledObject == null && gameObject != null)
                this.ControlledObject = gameObject;
        }

        public abstract void FaceTowardsPoint(Vector2 point);

        public abstract void Move(MovementDirection movementDirection, double units);
    }
}
