namespace MonoGame.Framework.Extended
{
    public interface ITransform
    {
        double StartTime { get; set; }
        double EndTime { get; set; }
        double ElapsedTime { get; set; }
        double Duration { get; set; }

        bool IsFinished { get; }

        EasingTypes Easing { get; set; }
    }
}