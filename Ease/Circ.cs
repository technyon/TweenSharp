using TS;
using UnityEngine;

public class Circ
{
    public static TSEase.EaseFunction EaseIn = FEaseIn;
    private static float FEaseIn(float t, float b, float c, float d)
    {
        t /= d;
        return -c * (Mathf.Sqrt(1 - t*t) - 1) + b;    }

    public static TSEase.EaseFunction EaseOut = FEaseOut;
    private static float FEaseOut(float t, float b, float c, float d)
    {
        t /= d;
        t--;
        return c * Mathf.Sqrt(1 - t*t) + b;    }

    public static TSEase.EaseFunction EaseInOut = FEaseInOut;
    private static float FEaseInOut(float t, float b, float c, float d)
    {
        t /= d/2;
        if (t < 1) return -c/2 * (Mathf.Sqrt(1 - t*t) - 1) + b;
        t -= 2;
        return c/2 * (Mathf.Sqrt(1 - t*t) + 1) + b;    }
}