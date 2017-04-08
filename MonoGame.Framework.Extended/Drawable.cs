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

        public Texture2D Texture;

        public Vector2 Position;
        public Vector2 Size;
        public Vector2 Origin;

        public Color Color;

        public SpriteEffects SpriteEffect;

        public float Depth;
        public float Rotation;

        public Rectangle Bounds => new Rectangle(
            (int)(Position.X - Size.X / (Texture.Width / Origin.X)), 
            (int)(Position.Y - Size.Y / (Texture.Height / Origin.Y)), 
            (int)Size.X, 
            (int)Size.Y);

        public Point Center => new Point(
            Bounds.X + (int)Size.X / 2,
            Bounds.Y + (int)Size.Y / 2);

        public Rectangle CenterRectangle(int width = 1, int height = 1) {
            return new Rectangle(
                Center.X - width / 2, 
                Center.Y - height / 2,
                width, 
                height);
        }

        public bool CollidesWith(Drawable target) {
            return Bounds.Intersects(target.Bounds);
        }

        public void MoveFacing(float amount) {
            Vector2 dir = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));

            dir.Normalize();

            Position += dir * amount;
        }

        public Drawable(Texture2D texture, Vector2 position, Vector2 size, Vector2 origin, Color color) {
            this.Texture = texture;
            this.Position = position;
            this.Size = size;
            this.Color = color;
            this.Origin = origin;

            this.SpriteEffect = SpriteEffects.None;
        }

        public Drawable(Texture2D texture, Vector2 position, Vector2 size, Color color) {
            this.Texture = texture;
            this.Position = position;
            this.Size = size;
            this.Color = color;

            this.SpriteEffect = SpriteEffects.None;
            this.Origin = new Vector2(texture.Width, texture.Height) / 2f;
        }

        public Drawable(Texture2D texture, Vector2 position, Vector2 size) {
            this.Texture = texture;
            this.Position = position;
            this.Size = size;

            this.Color = Color.White;
            this.SpriteEffect = SpriteEffects.None;
            this.Origin = new Vector2(texture.Width, texture.Height) / 2f;
        }

        public Drawable(Texture2D texture, Vector2 position) {
            this.Texture = texture;
            this.Position = position;

            this.Size = new Vector2(texture.Width, texture.Height);
            this.Color = Color.White;
            this.SpriteEffect = SpriteEffects.None;
            this.Origin = Size / 2f;
        }

        public Drawable(Texture2D texture) {
            this.Texture = texture;

            this.Position = Vector2.Zero;
            this.Size = new Vector2(texture.Width, texture.Height);
            this.Color = Color.White;
            this.SpriteEffect = SpriteEffects.None;
            this.Origin = Size / 2f;
        }

        public Drawable() { }

        public virtual void Update(GameTime gameTime) {
            PositionTransform.Update(gameTime);
            SizeTransform.Update(gameTime);
            RotationTransform.Update(gameTime);
            ColorTransform.Update(gameTime);

            if (!PositionTransform.IsFinished && PositionTransform.IsActive)
                Position = PositionTransform.CurrentProgress;

            if (!SizeTransform.IsFinished && SizeTransform.IsActive)
                Size = SizeTransform.CurrentProgress;

            if (!RotationTransform.IsFinished && RotationTransform.IsActive)
                Rotation = RotationTransform.CurrentProgress;

            if (!ColorTransform.IsFinished && ColorTransform.IsActive)
                Color = ColorTransform.CurrentProgress;
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), null, Color, Rotation, Origin, SpriteEffect, Depth);
        }
    }
}