namespace Survivio.GameObjects.Mechanisms.Camera
{
    using Microsoft.Xna.Framework;
    using Survivio.GameObjects.Base;
    using System;

    public class Camera
    {
        public Rectangle VisibleArea { get; private set; }

        public CameraMode CameraMode { get; private set; }

        public Point Point { get; set; }

        public GameObject GameObject { get; set; }

        private Action<Point?> updateAction;

        public Camera()
        {
            this.VisibleArea = new Rectangle(0, 0, GameConfig.ScreenWidth, GameConfig.ScreenHeight);
        }

        public Camera(CameraMode cameraMode, Point startPoint)
            : this()
        {
            this.Point = startPoint;
            this.CameraMode = cameraMode;
            if (CameraMode == CameraMode.FollowGameObject || CameraMode == CameraMode.FollowPoint)
            {
                updateAction = (point) =>
                {
                    if (this.VisibleArea.Center != point)
                    {
                        this.VisibleArea = new Rectangle(
                            new Point(
                                this.VisibleArea.X - (this.VisibleArea.X - point.Value.X),
                                this.VisibleArea.Y - (this.VisibleArea.Y - point.Value.Y)),
                            this.VisibleArea.Size);
                    }
                };
            }
            else
            {
                updateAction = (point) => { };
            }
        }

        public Camera(GameObject gameObject)
            : this(CameraMode.FollowGameObject, gameObject.Body.Center)
        {
            this.GameObject = gameObject;
        }

        public void UpdateCamera(Point? point = null)
        {
            if (GameObject != null)
            {
                updateAction.Invoke(GameObject.Body.Center);
            }
            else
            {
                updateAction.Invoke(point);
            }
        }

        public Vector2 GetCameraShift()
        {
            //return new Vector2(
            //        GameConfig.StandardScreenCenterX - (GameConfig.StandardScreenCenterX - VisibleArea.X),
            //        GameConfig.StandardScreenCenterY - (GameConfig.StandardScreenCenterY - VisibleArea.Y)
            //    );

            return new Vector2(
                    GameConfig.StandardScreenCenterX - VisibleArea.X,
                    GameConfig.StandardScreenCenterY - VisibleArea.Y
                );
        }
    }
}
