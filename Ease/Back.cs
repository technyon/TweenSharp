using TS;

public class Back
{
    public static TSEase.EaseFunction EaseIn = FEaseIn;
    private static float FEaseIn(float t, float b, float c, float d, object p = null)
    {
        float s = 1.70158f;
        return c * (t/=d) * t * ((s+1) * t - s) + b;
    }

    public static TSEase.EaseFunction EaseOut = FEaseOut;
    private static float FEaseOut(float t, float b, float c, float d, object p = null)
    {
        float s = 1.70158f;        
        return c * ((t=t/d-1) * t * ((s+1) * t + s) + 1) + b;
    }

    public static TSEase.EaseFunction EaseInOut = FEaseInOut;
    private static float FEaseInOut(float t, float b, float c, float d, object p = null)
    {
        float s = 1.70158f;
        if ((t /= d / 2) < 1)
        {
            return c/2*(t*t*(((s*=(1.525f))+1)*t - s)) + b;
        }
        return c/2*((t-=2)*t*(((s*=(1.525f))+1)*t + s) + 2) + b;
    }
}