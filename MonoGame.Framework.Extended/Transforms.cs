using System;
using Microsoft.Xna.Framework;

namespace MonoGame.Framework.Extended
{
    public class TransformVector2 : Transform<Vector2> {
        public override Vector2 CurrentProgress {
            get {
                return Interpolation.ValueAt(ElapsedTime, StartValue, EndValue, StartTime, EndTime, Easing);
            }
        }
    }

    public class TransformFloat : Transform<float>
    {
        public override float CurrentProgress {
            get {
                return Interpolation.ValueAt(ElapsedTime, StartValue, EndValue, StartTime, EndTime, Easing);
            }
        }
    }

    public class TransformColor : Transform<Color>
    {
        public override Color CurrentProgress {
            get {
                return Interpolation.ValueAt(ElapsedTime, StartValue, EndValue, StartTime, EndTime, Easing);
            }
        }
    }
}