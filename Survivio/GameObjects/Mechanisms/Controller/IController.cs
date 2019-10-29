namespace Survivio.GameObjects.Mechanisms.Controller
{
    using Microsoft.Xna.Framework;
    using Survivio.GameObjects.Base;

    public interface IController
    {
        GameObject ControlledObject { get; }
        void BindObject(GameObject gameObject);

        void FaceTowardsPoint(Vector2 point);
        void Move(MovementDirection movementDirection, double units);
    }
}
