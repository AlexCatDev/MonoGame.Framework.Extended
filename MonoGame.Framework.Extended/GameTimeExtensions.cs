using Microsoft.Xna.Framework;

namespace MonoGame.Framework.Extended
{
    public static class GameTimeExtensions
    {
        public static float Delta(this GameTime gameTime) {
            return (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public static float DeltaMS(this GameTime gameTime) {
            return (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public static double ToMS(this GameTime gameTime) {
            return gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}