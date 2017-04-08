namespace MonoGame.Framework.Extended
{
    public static class MathUtils
    {
        public static float Map(this float value, float fromSource, float toSource, float fromTarget, float toTarget) {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }

        public static double Map(this double value, double fromSource, double toSource, double fromTarget, double toTarget) {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }

        public static double Clamp(this double value, double min, double max) {
            if (value > max)
                return max;
            else if (value < min)
                return min;
            else
                return value;
        }

        public static float Clamp(this float value, float min, float max) {
            if (value > max)
                return max;
            else if (value < min)
                return min;
            else
                return value;
        }

        public static int Clamp(this int value, int min, int max) {
            if (value > max)
                return max;
            else if (value < min)
                return min;
            else
                return value;
        }
    }
}