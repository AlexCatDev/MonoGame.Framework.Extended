using Microsoft.Xna.Framework;

namespace MonoGame.Framework.Extended
{
    public abstract class Transform<T> : ITransform
    {
        public abstract T CurrentProgress { get; }

        public virtual T StartValue { get; set; }
        public virtual T EndValue { get; set; }

        public double StartTime { get; set; }
        public double EndTime { get; set; }

        public double ElapsedTime { get; set; }

        public EasingTypes Easing { get; set; }

        public bool ClampTime { get; set; }

        public double Duration {
            get {
                return EndTime - StartTime;
            }
            set {
                StartTime = 0;
                EndTime = value;
            }
        }

        public Transform(bool clampTime = true) {
            this.ClampTime = clampTime;
        }

        public void Update(GameTime gameTime) {
            var time = ElapsedTime + gameTime.ToMS();

            if (ClampTime) {
                if (time > EndTime)
                    ElapsedTime = EndTime;
                else
                    ElapsedTime = time;
            } else
                ElapsedTime = time;
        }

        public bool IsFinished {
            get {
                if (ElapsedTime >= Duration)
                    return true;
                else
                    return false;
            }
        }
    }
}