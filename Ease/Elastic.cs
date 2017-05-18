using TS;
using UnityEngine;

public class Elastic
{
    public static TSEase.EaseFunction EaseIn = FEaseIn;
    private static float FEaseIn(float t, float b, float c, float d)
    {
        float s;
        float p=0;
        float a=c;
        if (t == 0)
        {
            return b;
        }
        if ((t /= d) == 1)
        {
            return b+c;
        }

        if (p == 0)
        {
            p=d * 0.3f;
        }
        if (a < Mathf.Abs(c))
        {
            a = c;
            s = p / 4;
        }
        else
        {
            s = p/(2*Mathf.PI) * Mathf.Asin(c/a);
        }

        return -(a * Mathf.Pow(2f,10f*(t-=1)) * Mathf.Sin((t * d-s) * (2f * Mathf.PI) / p)) + b;
    }

    public static TSEase.EaseFunction EaseOut = FEaseOut;
    private static float FEaseOut(float t, float b, float c, float d)
    {
        float s;
        float p=0;
        float a=c;

        if (t == 0)
        {
            return b;
        }
        if ((t /= d) == 1)
        {
            return b+c;
        }


        if (p == 0)
        {
            p = d * 0.3f;
        }

        if (a < Mathf.Abs(c))
        {
            a = c;
            s = p / 4;
        }
        else
        {
            s = p/(2f*Mathf.PI) * Mathf.Asin(c/a);
        }

        return a * Mathf.Pow(2f, -10f * t) * Mathf.Sin( (t * d-s) * (2f * Mathf.PI) / p ) + c + b;
    }

    public static TSEase.EaseFunction EaseInOut = FEaseInOut;
    private static float FEaseInOut(float t, float b, float c, float d)
    {
        float s;
        float p=0;
        float a=c;

        if (t == 0)
        {
            return b;
        }
        if ((t /= d / 2) == 2)
        {
            return b+c;
        }
        if (p == 0)
        {
            p=d * (0.3f * 1.5f);
        }

        if (a < Mathf.Abs(c))
        {
            a=c;
            s=p/4;
        }
        else
        {
            s = p / (2*Mathf.PI) * Mathf.Asin (c/a);
        }
        if (t < 1)
        {
            return -0.5f * (a * Mathf.Pow(2f,10f * (t-=1)) * Mathf.Sin((t * d-s) * (2f * Mathf.PI)/p )) + b;
        }
        return a * Mathf.Pow(2f, -10f * (t-=1)) * Mathf.Sin((t * d-s) * (2 * Mathf.PI) / p)*0.5f + c + b;

    }
}