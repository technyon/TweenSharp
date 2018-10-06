using TS;
using UnityEngine;

public static class Sine
{
    public static TSEase.EaseFunction EaseIn = FEaseIn;
    private static float FEaseIn(float t, float b, float c, float d, object p = null)
    {
        return -c * Mathf.Cos(t/d * (Mathf.PI/2)) + c + b;
    }

    public static TSEase.EaseFunction EaseOut = FEaseOut;
    private static float FEaseOut(float t, float b, float c, float d, object p = null)
    {
        return c * Mathf.Sin(t/d * (Mathf.PI/2)) + b;
    }

    public static TSEase.EaseFunction EaseInOut = FEaseInOut;
    private static float FEaseInOut(float t, float b, float c, float d, object p = null)
    {
        return -c/2 * (Mathf.Cos(Mathf.PI*t/d) - 1) + b;
    }
}