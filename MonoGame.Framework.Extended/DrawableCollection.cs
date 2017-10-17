using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Framework.Extended
{
    public class DrawableCollection : System.Collections.CollectionBase
    {
        private double minDelay;
        public double MinDelay => minDelay;

        private double delta;
        public double Delta => delta;

        public DrawableCollection(double minDelay = 0) {
            this.minDelay = minDelay;
        }

        public void Remove(Drawable drawable) {
            InnerList.Remove(drawable);
        }

        public void Add(Drawable drawable, GameTime gameTime) {
            if (delta >= minDelay) {
                delta = 0;
                InnerList.Add(drawable);
            }
        }

        public void Update(GameTime gameTime) {
            delta += gameTime.ElapsedGameTime.TotalMilliseconds;

            for (int i = 0; i < List.Count; i++) {
                var drawable = (InnerList[i] as Drawable);
                drawable.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < List.Count; i++) {
                var drawable = (InnerList[i] as Drawable);
                drawable.Draw(spriteBatch);
            }
        }
    }
}