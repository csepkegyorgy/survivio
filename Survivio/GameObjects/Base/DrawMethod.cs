namespace Survivio.GameObjects.Base
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public class DrawMethod
    {
        public List<Texture2D> Textures { get; set; }

        public List<Rectangle> Rectangles { get; set; }

        public DrawMethod(Texture2D texture, Rectangle body)
        {
            this.Textures = new List<Texture2D>() { texture };
            this.Rectangles = new List<Rectangle>() { body };
        }

        public DrawMethod(List<Texture2D> textures, List<Rectangle> rectangles)
        {
            this.Textures = textures;
            this.Rectangles = rectangles;
        }
    }
}
