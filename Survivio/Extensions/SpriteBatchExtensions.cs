namespace Survivio.Extensions
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Base;
    using System;

    public static class SpriteBatchExtensions
    {
        public static SpriteBatch MainSpriteBatch { get; set; }

        public static void Draw(this GameObject gameObject)
        {
            Rectangle rectangle = gameObject.Body.Rectangle;
            rectangle.Location = new Point(rectangle.Location.X + rectangle.Width / 2, rectangle.Location.Y + rectangle.Height / 2);
            Vector2 origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
            float rotationRadian = (-1) * (float)(gameObject.Rotation * (Math.PI / 180));

            MainSpriteBatch.Draw(gameObject.Texture, rectangle, null, Color.White, rotationRadian, origin, SpriteEffects.None, 0f);
        }

        public static void DrawWithDevBorder(this GameObject gameObject)
        {
            gameObject.Draw();
            DrawHollowRectangle(gameObject.Body.Rectangle.Location, (int)gameObject.Body.Width, (int)gameObject.Body.Height, 2, Color.Red);
        }

        public static void DrawSimple(this GameObject gameObject)
        {
            MainSpriteBatch.Draw(gameObject.Texture, gameObject.Body.Rectangle, Color.White);
        }

        public static void DrawHollowRectangle(int x, int y, int w, int h, int thickness, Color color)
        {
            // draw top side
            MainSpriteBatch.Draw(ContentAccessor.Empty, new Rectangle(x, y, w, thickness), color);

            // draw right side
            MainSpriteBatch.Draw(ContentAccessor.Empty, new Rectangle(x + w - thickness, y, thickness, h), color);

            // draw bottom side
            MainSpriteBatch.Draw(ContentAccessor.Empty, new Rectangle(x, y + h - thickness, w, thickness), color);

            // draw left side
            MainSpriteBatch.Draw(ContentAccessor.Empty, new Rectangle(x, y, thickness, h), color);
        }

        public static void DrawHollowRectangle(Point point, int w, int h, int thickness, Color color)
        {
            DrawHollowRectangle(point.X, point.Y, w, h, thickness, color);
        }
    }
}
