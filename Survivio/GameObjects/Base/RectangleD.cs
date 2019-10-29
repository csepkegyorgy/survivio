namespace Survivio.GameObjects.Base
{
    using Microsoft.Xna.Framework;

    public class RectangleD
    {
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle()
                {
                    X = (int)this.X,
                    Y = (int)this.Y,
                    Width = (int)this.Width,
                    Height = (int)this.Height,
                };
            }
        }

        public Point Center
        {
            get { return new Point((int)(this.X + this.Width / 2), (int)(this.Y + this.Height / 2)); }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public RectangleD(double x, double y, double width, double height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public void Offset(double x, double y)
        {
            this.X += x;
            this.Y += y;
        }
    }
}
