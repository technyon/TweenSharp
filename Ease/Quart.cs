public class Quart
{
    public static float EaseIn(float t, float b, float c, float d)
    {
        t /= d;
        return c*t*t*t*t + b;
    }

    public static float EaseOut(float t, float b, float c, float d)
    {
        t /= d;
        t--;
        return -c * (t*t*t*t - 1) + b;
    }

    public static float EaseInOut(float t, float b, float c, float d)
    {

        t /= d/2;
        if (t < 1) return c/2*t*t*t*t + b;
        t -= 2;
        return -c/2 * (t*t*t*t - 2) + b;
    }
}