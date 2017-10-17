using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGame.Framework.Extended
{
    public class Drawable
    {
        public TransformVector2 PositionTransform = new TransformVector2();
        public TransformVector2 SizeTransform = new TransformVector2();
        public TransformColor ColorTransform = new TransformColor();
        public TransformFloat RotationTransform = new TransformFloat();

        public Texture2D Texture { get; set; }

        public Rectangle? SourceRectangle { get; set; } = null;

        public Vector2 Position {
            get {
                return PositionTransform.CurrentProgress;
            }
            set {
                PositionTransform.EndValue = value;
                PositionTransform.StartValue = value;
            }
        }

        public Vector2 Size {
            get {
                return SizeTransform.CurrentProgress;
            }
            set {
                SizeTransform.EndValue = value;
                SizeTransform.StartValue = value;
            }
        }

        public Color Color {
            get {
                return ColorTransform.CurrentProgress;
            }
            set {
                ColorTransform.EndValue = value;
                ColorTransform.StartValue = value;
            }
        }

        public SpriteEffects SpriteEffect { get; set; }

        public float Depth { get; set; }

        public float Rotation {
            get {
                return RotationTransform.CurrentProgress;
            }
            set {
                RotationTransform.EndValue = value;
                RotationTransform.StartValue = value;
            }
        }

        public Rectangle Bounds => new Rectangle(
            (int)(Position.X - Size.X / 2f), 
            (int)(Position.Y - Size.Y / 2f), 
            (int)Size.X,  
            (int)Size.Y);

        public Rectangle CenterRectangle(int width, int height) {
            return new Rectangle(
                (int)Position.X - width / 2, 
                (int)Position.Y - height / 2,
                width, 
                height);
        }

        public bool IsCollidingWith(Drawable target) {
            return Bounds.Intersects(target.Bounds);
        }

        public void MoveFacingRotation(float amount) {
            Vector2 dir = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            dir.Normalize();
            Position += dir * amount;
        }

        public Drawable(Texture2D texture, Vector2 size, Vector2 position, Color color) {
            this.Texture = texture;
            this.Position = position;
            this.Size = size;
            this.Color = color;
        }

        public Drawable(Texture2D texture, Vector2 size, Vector2 position) : this(texture, size, position, Color.White) { }

        public Drawable(Texture2D texture, Vector2 size) : this(texture, size, Vector2.Zero, Color.White) { }

        public Drawable(Texture2D texture) : this(texture, new Vector2(texture.Width, texture.Height), Vector2.Zero, Color.White) { }

        public Drawable() { }

        public virtual void Update(GameTime gameTime) {
            PositionTransform.Update(gameTime);
            SizeTransform.Update(gameTime);
            RotationTransform.Update(gameTime);
            ColorTransform.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, SourceRectangle, Color, Rotation,
                new Vector2(Texture.Width / 2f, Texture.Height / 2f),
                new Vector2(Size.X / Texture.Width, Size.Y / Texture.Height),
                SpriteEffect, Depth);
        }
    }
}