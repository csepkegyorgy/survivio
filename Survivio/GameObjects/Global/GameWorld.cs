namespace Survivio.GameObjects.Global
{
    using Microsoft.Xna.Framework;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Mechanisms.Collision;
    using Survivio.GameObjects.Mechanisms.Controller;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GameWorld
    {
        private List<GameObject> GameObjectsPrivate;
        public List<GameObject> GameObjects => GameObjectsPrivate.ToList();

        private List<CollisionRealm> CollisionRealmsPrivate;
        public List<CollisionRealm> CollisionRealms => CollisionRealmsPrivate.ToList();

        public Rectangle Area { get; private set; }

        public Rectangle VisibleArea { get; set; }

        public GameWorld(int width, int height)
        {
            this.Initialize(width, height);
        }

        private void Initialize(int width, int height)
        {
            this.GameObjectsPrivate = new List<GameObject>();
            this.CollisionRealmsPrivate = new List<CollisionRealm>();
            this.Area = new Rectangle(0, 0, width, height);
            this.VisibleArea = new Rectangle(0, 0, GameConfig.ScreenWidth, GameConfig.ScreenHeight);

            this.InitializeCollisionRealms();
        }

        private void InitializeCollisionRealms()
        {
            int horizontalRealmsCount = (int)Math.Ceiling((double)this.Area.Width / GameConfig.CollisionRealmSize);
            int verticalRealmsCount = (int)Math.Ceiling((double)this.Area.Height / GameConfig.CollisionRealmSize);

            int idCounter = 0;
            for (int i = 0; i < verticalRealmsCount; i++)
            {
                for (int j = 0; j < horizontalRealmsCount; j++)
                {
                    CollisionRealmsPrivate.Add(new CollisionRealm(j * GameConfig.CollisionRealmSize, i * GameConfig.CollisionRealmSize, idCounter));
                    idCounter++;
                }
            }
        }

        public void AddNewGameObject(GameObject gameObject)
        {
            gameObject.GameWorld = this;
            gameObject.UpdateCollisionRealms();
            this.GameObjectsPrivate.Add(gameObject);
            
        }
    }
}
