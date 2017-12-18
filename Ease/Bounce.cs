using TS;

public class Bounce
{
    public static TSEase.EaseFunction EaseIn = FEaseIn;
    private static float FEaseIn(float t, float b, float c, float d, object p = null)
    {
        return c - FEaseOut(d-t, 0, c, d) + b;
    }

    public static TSEase.EaseFunction EaseOut = FEaseOut;
    private static float FEaseOut(float t, float b, float c, float d, object p = null)
    {
        if ((t/=d) < (1f/2.75f)) {
            return c*(7.5625f*t*t) + b;
        } else if (t < (2/2.75)) {
            return c*(7.5625f*(t-=(1.5f/2.75f))*t + .75f) + b;
        } else if (t < (2.5/2.75)) {
            return c*(7.5625f*(t-=(2.25f/2.75f))*t + .9375f) + b;
        } else {
            return c*(7.5625f*(t-=(2.625f/2.75f))*t + .984375f) + b;
        }
    }

    public static TSEase.EaseFunction EaseInOut = FEaseInOut;

    private static float FEaseInOut(float t, float b, float c, float d, object p = null)
    {
        if (t < d / 2)
        {
            return FEaseIn(t * 2f, 0, c, d) * .5f + b;
        }
        else
        {
            return FEaseOut(t * 2f - d, 0, c, d) * .5f + c * .5f + b;
        }
    }
}
