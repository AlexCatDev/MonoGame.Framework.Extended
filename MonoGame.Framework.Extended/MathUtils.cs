using Microsoft.Xna.Framework;

namespace MonoGame.Framework.Extended
{
    public static class MathUtils
    {
        public static float Map(float value, float relativeTo, float from, float to) {
            return (((to - from) / relativeTo) * value) + from;
            
        }

        public static double Map(this double value, double relativeTo, double from, double to) {
            return (((to - from) / relativeTo) * value) + from;
            
        }

        public static double Clamp(this double value, double min, double max) {
            if (value > max)
                return max;
            else if (value < min)
                return min;
            else
                return value;
        }
    }
}