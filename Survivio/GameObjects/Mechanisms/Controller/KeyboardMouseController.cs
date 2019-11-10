namespace Survivio.GameObjects.Mechanisms.Controller
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Survivio.Extensions;
    using Survivio.GameObjects.Item;
    using System;
    using System.Linq;

    public class KeyboardMouseController : Controller
    {
        public override void FaceTowardsPoint(Vector2 point)
        {
            Point bodyCenter = ControlledObject.Body.Center;

            if (bodyCenter.Y == point.Y)
            {
                if (bodyCenter.X < point.X)
                {
                    ControlledObject.Rotation = 0;
                }
                else
                {
                    ControlledObject.Rotation = 180;
                }
                return;
            }
            if (bodyCenter.X == point.X)
            {
                if (bodyCenter.Y < point.Y)
                {
                    ControlledObject.Rotation = 270;
                }
                else
                {
                    ControlledObject.Rotation = 90;
                }
                return;
            }

            int rotation = 0;
            if (bodyCenter.X < point.X)
            {
                if (bodyCenter.Y < point.Y)
                {
                    // QUADRANT IV
                    double oppositeLength = point.Y - bodyCenter.Y;
                    double adjecentLength = point.X - bodyCenter.X;
                    rotation = 360 - (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan(oppositeLength / adjecentLength)));
                }
                else
                {
                    // QUADRANT I
                    double oppositeLength = bodyCenter.Y - point.Y;
                    double adjecentLength = point.X - bodyCenter.X;
                    rotation = (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan(oppositeLength / adjecentLength)));
                }
            }
            else
            {
                if (bodyCenter.Y < point.Y)
                {
                    // QUADRANT III
                    double oppositeLength = point.Y - bodyCenter.Y;
                    double adjecentLength = bodyCenter.X - point.X;
                    rotation = 180 + (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan(oppositeLength / adjecentLength)));
                }
                else
                {
                    // QUADRANT II
                    double oppositeLength = bodyCenter.Y - point.Y;
                    double adjecentLength = bodyCenter.X - point.X;
                    rotation = 180 - (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan(oppositeLength / adjecentLength)));
                }
            }
            ControlledObject.Rotation = rotation;
        }

        public override void Move(MovementDirection movementDirection, double units)
        {
            switch (movementDirection)
            {
                case MovementDirection.Right:
                    ControlledObject.Move(units, 0);
                    break;
                case MovementDirection.UpRight:
                    ControlledObject.Move(units, units * (-1));
                    break;
                case MovementDirection.Up:
                    ControlledObject.Move(0, units * (-1));
                    break;
                case MovementDirection.UpLeft:
                    ControlledObject.Move(units * (-1), units * (-1));
                    break;
                case MovementDirection.Left:
                    ControlledObject.Move(units * (-1), 0);
                    break;
                case MovementDirection.DownLeft:
                    ControlledObject.Move(units * (-1), units);
                    break;
                case MovementDirection.Down:
                    ControlledObject.Move(0, units);
                    break;
                case MovementDirection.DownRight:
                    ControlledObject.Move(units, units);
                    break;
                default:
                    break;
            }
        }

        public void HandleState(KeyboardMouseState state)
        {
            FaceTowardsPoint(state.MouseState.Position.ToVector2() - SpriteBatchExtensions.Camera.GetCameraShift());

            double units = ControlledObject.Speed / GameConfig.FPS;
            if (state.KeyboardState.IsKeyDown(Keys.W))
                Move(MovementDirection.Up, units);
            if (state.KeyboardState.IsKeyDown(Keys.A))
                Move(MovementDirection.Left, units);
            if (state.KeyboardState.IsKeyDown(Keys.S))
                Move(MovementDirection.Down, units);
            if (state.KeyboardState.IsKeyDown(Keys.D))
                Move(MovementDirection.Right, units);

            if (state.KeyboardState.IsKeyDown(Keys.Space))
            {
                var avatar = ControlledObject as Avatar;

                var interactableObject = avatar.InteractableGameObjects.OrderBy(x => (avatar.Body.Center.ToVector2() - x.Body.Center.ToVector2()).Length()).FirstOrDefault();
                if (interactableObject != null)
                {
                    (interactableObject as Loot).Interact(avatar);
                }
            }
        }
    }
}
