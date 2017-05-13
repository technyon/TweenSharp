namespace TS
{
    public class TSEase
    {
        public delegate float EaseFunction(float t, float b, float c, float d);

        public static float Linear(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }
    }
}