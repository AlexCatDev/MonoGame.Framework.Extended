using Microsoft.Xna.Framework;

namespace MonoGame.Framework.Extended
{
    public abstract class Transform<T>
    {
        public abstract T CurrentProgress { get; }

        public virtual T StartValue { get; set; }
        public virtual T EndValue { get; set; }

        public double StartTime { get; set; }
        public double EndTime { get; set; }

        public double ElapsedTime { get; set; }

        public EasingTypes Easing { get; set; }

        public void SwitchValues() {
            T tStart = StartValue;
            T tEnd = EndValue;

            StartValue = tEnd;
            EndValue = tStart;
        }

        public double Duration {
            get {
                return EndTime - StartTime;
            }
            set {
                ElapsedTime = 0;
                StartTime = 0;
                EndTime = value;
            }
        }

        public void Update(GameTime gameTime) {
            double time = ElapsedTime + gameTime.ElapsedGameTime.TotalMilliseconds;

            if (time > EndTime)
                ElapsedTime = EndTime;
            else
                ElapsedTime = time;
        }

        public bool IsFinished => ElapsedTime >= Duration;
    }
}