namespace Survivio.Extensions
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Survivio.GameObjects.Base;
    using Survivio.GameObjects.Mechanisms.Camera;
    using System;

    public static class SpriteBatchExtensions
    {
        public static SpriteBatch MainSpriteBatch { get; set; }

        public static Camera Camera { get; set; }

        private static Vector2 CameraShift => Camera.GetCameraShift();

        public static void Draw(this GameObject gameObject, bool devBorder = false)
        {
            Rectangle rectangle = gameObject.Body.Rectangle;
            // Camera shift
            // Camera shift
            rectangle.Location = new Point(rectangle.Location.X + rectangle.Width / 2, rectangle.Location.Y + rectangle.Height / 2);
            rectangle.Location += gameObject.GameWorld.VisibleArea.Location;

            Vector2 origin = new Vector2(gameObject.Texture.Width / 2, gameObject.Texture.Height / 2);
            float rotationRadian = (-1) * (float)(gameObject.Rotation * (Math.PI / 180));

            rectangle = new Rectangle((int)(rectangle.X + CameraShift.X), (int)(rectangle.Y + CameraShift.Y), rectangle.Width, rectangle.Height);
            MainSpriteBatch.Draw(gameObject.Texture, rectangle, null, Color.White, rotationRadian, origin, SpriteEffects.None, 0f);
            gameObject.Body.Rectangle.DrawDevBorder();
        }

        public static void DrawDevBorder(this Rectangle area)
        {
            DrawHollowRectangleUnshifted(area.Location.ToVector2() + CameraShift, area.Width, area.Height, 2, Color.Red);
        }

        public static void DrawSimple(this GameObject gameObject)
        {
            Rectangle rectangle = new Rectangle(gameObject.Body.Rectangle.Location + CameraShift.ToPoint(), gameObject.Body.Rectangle.Size);
            MainSpriteBatch.Draw(gameObject.Texture, rectangle, Color.White);
        }

        public static void DrawHollowRectangleUnshifted(int x, int y, int w, int h, int thickness, Color color)
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

        public static void DrawHollowRectangle(int x, int y, int w, int h, int thickness, Color color)
        {
            x += (int)CameraShift.X;
            y += (int)CameraShift.Y;

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

        public static void DrawHollowRectangle(Vector2 vector, int w, int h, int thickness, Color color)
        {
            DrawHollowRectangle((int)vector.X, (int)vector.Y, w, h, thickness, color);
        }

        public static void DrawHollowRectangleUnshifted(Point point, int w, int h, int thickness, Color color)
        {
            DrawHollowRectangleUnshifted(point.X, point.Y, w, h, thickness, color);
        }

        public static void DrawHollowRectangleUnshifted(Vector2 vector, int w, int h, int thickness, Color color)
        {
            DrawHollowRectangleUnshifted((int)vector.X, (int)vector.Y, w, h, thickness, color);
        }

        public static void DrawString(this string text, Vector2 position, Color? color = null, float scale = 1, SpriteFont font = null)
        {
            if (font == null) font = ContentAccessor.StandardFont;
            if (color == null) color = Color.Black;

            Vector2 stringSize = ContentAccessor.StandardFont.MeasureString(text);
            stringSize = new Vector2(stringSize.X * scale, stringSize.Y * scale);

            MainSpriteBatch.DrawString(font, text, (new Vector2(position.X - stringSize.X / 2, position.Y - stringSize.Y / 2)) + CameraShift, color.Value, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public static void DrawStringOnScreen(this string text, Vector2 position, Color? color = null, float scale = 1, SpriteFont font = null)
        {
            if (font == null) font = ContentAccessor.StandardFont;
            if (color == null) color = Color.Black;

            Vector2 stringSize = ContentAccessor.StandardFont.MeasureString(text);
            stringSize = new Vector2(stringSize.X * scale, stringSize.Y * scale);

            MainSpriteBatch.DrawString(font, text, (new Vector2(position.X - stringSize.X / 2, position.Y - stringSize.Y / 2)), color.Value, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
