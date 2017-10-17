using Microsoft.Xna.Framework;

namespace MonoGame.Framework.Extended
{
    public static class GameTimeExtensions
    {
        public static float Delta(this GameTime gameTime) => (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}