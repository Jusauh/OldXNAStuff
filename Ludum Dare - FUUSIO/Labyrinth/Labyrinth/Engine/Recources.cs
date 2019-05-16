using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Labyrinth.Engine
{
    class Recources
    {
        // Variables
        static ContentManager content;

        private static Dictionary<string, Texture2D> textures;
        private static Dictionary<string, SpriteFont> fonts;

        // Recources initialization
        public static void Initialize(ContentManager cont)
        {
            content = cont;

            textures = new Dictionary<string, Texture2D>();
            fonts = new Dictionary<string, SpriteFont>();
        }

        // Loads a texture with the given string and names it with the same string
        public static void LoadTexture(string textureName)
        {
            Texture2D newTexture = content.Load<Texture2D>(textureName);
            textures.Add(textureName, newTexture);
        }

        // Gets the texture with given name
        public static Texture2D GetTexture(string textureName)
        {
            if (textures.ContainsKey(textureName))
            {
                return textures[textureName];
            }
            else
            {
                return null;
            }
        }

        // Return the width of wanted texture
        public static float GetTextureWidth(string textureName)
        {
            if (textures.ContainsKey(textureName))
            {
                return textures[textureName].Width;
            }
            else
            {
                return 32;
            }
        }

        // Return the height of wanted texture
        public static float GetTextureHeight(string textureName)
        {
            if (textures.ContainsKey(textureName))
            {
                return textures[textureName].Height;
            }
            else
            {
                return 32;
            }
        }

        public static Vector2 GetTextureOrigin(string textureName)
        {
            if (textures.ContainsKey(textureName))
            {
                return new Vector2(textures[textureName].Width * 0.5f, textures[textureName].Height * 0.5f);
            }
            else
            {
                return Vector2.Zero;
            }
        }

        // Loads a spritefont with the given string and names it with the same string
        public static void LoadFont(string fontName)
        {
            SpriteFont newFont = content.Load<SpriteFont>(fontName);
            fonts.Add(fontName, newFont);
        }

        // Gets the spritefont with given name
        public static SpriteFont GetFont(string fontName)
        {
            if (fonts.ContainsKey(fontName))
            {
                return fonts[fontName];
            }
            else
            {
                return null;
            }
        }
    }
}