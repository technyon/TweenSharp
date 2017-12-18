using TS;
using UnityEngine;

public class Expo
{
    public static TSEase.EaseFunction EaseIn = FEaseIn;
    private static float FEaseIn(float t, float b, float c, float d, object p = null)
    {
        return c * Mathf.Pow( 2, 10 * (t/d - 1) ) + b;
    }

    public static TSEase.EaseFunction EaseOut = FEaseOut;
    private static float FEaseOut(float t, float b, float c, float d, object p = null)
    {
        return c * ( -Mathf.Pow( 2, -10 * t/d ) + 1 ) + b;
    }

    public static TSEase.EaseFunction EaseInOut = FEaseInOut;
    private static float FEaseInOut(float t, float b, float c, float d, object p = null)
    {
        t /= d/2;
        if (t < 1) return c/2 * Mathf.Pow( 2, 10 * (t - 1) ) + b;
        t--;
        return c/2 * ( -Mathf.Pow( 2, -10 * t) + 2 ) + b;
    }
}