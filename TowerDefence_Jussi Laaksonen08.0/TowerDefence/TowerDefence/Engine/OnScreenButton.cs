using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TowerDefence.Game;

namespace TowerDefence.Engine
{
    /// <summary>
    /// Voidaan luoda ruudulle graafisia nappeja jotka reagoivat klikkaukseen sekä niiden pääle kohdistamiseen
    /// </summary>
    class OnScreenButton
    {
        GameTimer timer = new GameTimer(1.0f, new Vector2(100, 100), Color.White);

        Texture2D _texture;
        Texture2D texture;
        Texture2D newTexture;

        Vector2 position;

        Rectangle rectangle;
        Rectangle drawArea;
        Rectangle passiveRectangle;
        Rectangle targetedRectangle;

        public bool constPressed;
        public bool pressed;

        public bool useNewTexture = false;

        Color color, untargetedColor, targetedColor;


        public OnScreenButton(Texture2D texture, Texture2D newTexture, Vector2 position, bool constPressed, Rectangle drawArea, Rectangle startSize, Rectangle hoverSize, Color untargetedColor, Color isTargetedTint)
        {
            this.texture = texture;
            this.newTexture = newTexture;
            this._texture = texture;
            this.position = position;
            this.drawArea = drawArea;
            this.constPressed = constPressed;
            this.passiveRectangle = new Rectangle((int)position.X - (startSize.Width / 2), (int)position.Y - startSize.Height / 2, startSize.Width, startSize.Height);
            this.targetedRectangle = new Rectangle((int)position.X - (hoverSize.Width / 2), (int)position.Y - hoverSize.Height / 2, hoverSize.Width, hoverSize.Height);
            this.untargetedColor = untargetedColor;
            this.targetedColor = isTargetedTint;
        }

        /// <summary>
        /// Päivitys
        /// </summary>
        public void Update()
        {
            if (Input.CursorOverArea(rectangle))
            {
                pressed = false;

                rectangle = targetedRectangle;
                color = targetedColor;

                if (constPressed == true)
                {
                    if (Input.MouseLeftPressed())
                    {
                        pressed = true;
                    }

                    if (Input.MouseLeftDown())
                    {
                        timer.Start();

                        if (timer.IsFinished())
                        {
                            timer.SetFinishedFalse();

                            pressed = true;
                        }
                    }
                    else if (Input.MouseLeftReleased())
                    {
                        timer.Reset();

                        pressed = false;
                    }
                }
                else if (constPressed == false && Input.MouseLeftPressed())
                {
                    if (useNewTexture == true)
                    {
                        _texture = newTexture;
                    }
                    else if (useNewTexture == false)
                    {
                        _texture = texture;
                    }

                    pressed = true;
                }
            }
            else
            {
                rectangle = passiveRectangle;
                color = untargetedColor;
                pressed = false;
            }
        }

        /// <summary>
        /// Piirto
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, rectangle, drawArea, color);
        }
    }
}