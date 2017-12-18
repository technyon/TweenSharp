using TS;

public class Quint
{
    public static TSEase.EaseFunction EaseIn = FEaseIn;
    private static float FEaseIn(float t, float b, float c, float d, object p = null)
    {
        t /= d;
        return c*t*t*t*t*t + b;
    }

    public static TSEase.EaseFunction EaseOut = FEaseOut;
    private static float FEaseOut(float t, float b, float c, float d, object p = null)
    {
        t /= d;
        t--;
        return -c * (t*t*t*t*t - 1) + b;
    }

    public static TSEase.EaseFunction EaseInOut = FEaseInOut;
    private static float FEaseInOut(float t, float b, float c, float d, object p = null)
    {

        t /= d/2;
        if (t < 1) return c/2*t*t*t*t*t + b;
        t -= 2;
        return -c/2 * (t*t*t*t*t - 2) + b;
    }
}