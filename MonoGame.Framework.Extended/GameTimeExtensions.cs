using Microsoft.Xna.Framework;

namespace MonoGame.Framework.Extended
{
    public static class GameTimeExtensions
    {
        public static float Delta(this GameTime gameTime) {
            return (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public static double ElapsedMS(this GameTime gameTime) {
            return gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}