namespace Survivio.GameObjects.Global
{
    using Microsoft.Xna.Framework;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Mechanisms.Collision;
    using System;
    using System.Collections.Generic;

    public class GameWorld
    {
        public List<GameObject> GameObjects { get; }

        public List<CollisionRealm> CollisionRealms { get; }

        public Rectangle Area { get; }

        public GameWorld(int width, int height)
        {
            this.GameObjects = new List<GameObject>();
            this.CollisionRealms = new List<CollisionRealm>();
            this.Area = new Rectangle(0, 0, width, height);

            this.Initialize();
        }

        private void Initialize()
        {
            this.InitializeCollisionRealms();
        }

        private void InitializeCollisionRealms()
        {
            int horizontalRealmsCount = (int)Math.Ceiling((double)this.Area.Width / GameConfig.CollisionRealmSize);
            int verticalRealmsCount = (int)Math.Ceiling((double)this.Area.Height / GameConfig.CollisionRealmSize);

            for (int i = 0; i < verticalRealmsCount; i++)
            {
                for (int j = 0; j < horizontalRealmsCount; j++)
                {
                    CollisionRealms.Add(new CollisionRealm(j * GameConfig.CollisionRealmSize, i * GameConfig.CollisionRealmSize));
                }
            }
        }
    }
}
