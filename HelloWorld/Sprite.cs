using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace HelloWorld
{
    internal class Sprite
    {
        private Texture2D _texture;
        private Color _spriteColor;

        public Color SpriteColor
        {
            get { return _spriteColor; }
            set { _spriteColor = value; }
        }

        /// <summary>
        /// Width of the loaded texture
        /// </summary>
        public int Width
        {
            get
            {
                return _texture.width;
            }
            set
            {
                _texture.width = value;
            }
        }

        /// <summary>
        ///  Height of the loaded texture
        /// </summary>
        public int Height
        {
            get
            {
                return _texture.height;
            }
            set
            {
                _texture.height = value;
            }
        }

        /// <summary>
        /// Loads the given texture
        /// </summary>
        /// <param name="texture">Sets the sprites image to be the given texture</param>
        public Sprite(Texture2D texture)
        {
            _texture = texture;
            SpriteColor = Color.WHITE;
        }

        /// <summary>
        /// Loads the texture at the given path
        /// </summary>
        /// <param name="path">The file path of the texture</param>
        public Sprite(string path)
        {
            _texture = Raylib.LoadTexture(path);
            SpriteColor = Color.WHITE;
        }

        /// <summary>
        /// Draws the sprite using the rotation, translation, and scale
        /// of the given transform
        /// </summary>
        /// <param name="transform"></param>
        public void Draw(Matrix3 transform)
        {
            //Finds the scale of the sprite
            float xMagnitude = (float)Math.Round(new Vector2(transform.M00, transform.M01).Magnitude);
            float yMagnitude = (float)Math.Round(new Vector2(transform.M10, transform.M11).Magnitude);
            Width = (int)xMagnitude;
            Height = (int)yMagnitude;

            //Sets the sprite center to the transform origin
            System.Numerics.Vector2 position = new System.Numerics.Vector2(transform.M20, transform.M21);
            System.Numerics.Vector2 forward = new System.Numerics.Vector2(transform.M00, transform.M01);
            System.Numerics.Vector2 up = new System.Numerics.Vector2(transform.M10, transform.M11);
            position -= (forward / forward.Length()) * Width / 2;
            position -= (up / up.Length()) * Height / 2;

            //Find the transform rotation in radians 
            float rotation = (float)Math.Atan2(transform.M10, transform.M00);

            //Draw the sprite
            Raylib.DrawTextureEx(_texture, position,
                (float)(rotation * 180.0f / Math.PI), 1, SpriteColor);
        }
    }
}

