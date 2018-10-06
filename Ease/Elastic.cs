using TS;
using UnityEngine;

public static class Elastic
{
    public static TSEase.EaseFunction EaseIn = FEaseIn;
    private static float FEaseIn(float t, float b, float c, float d, object p = null)
    {
        float s;
        float r=0;
        float a=c;
        if (t == 0)
        {
            return b;
        }
        if ((t /= d) == 1)
        {
            return b+c;
        }

        if (r == 0)
        {
            r=d * 0.3f;
        }
        if (a < Mathf.Abs(c))
        {
            a = c;
            s = r / 4;
        }
        else
        {
            s = r/(2*Mathf.PI) * Mathf.Asin(c/a);
        }

        return -(a * Mathf.Pow(2f,10f*(t-=1)) * Mathf.Sin((t * d-s) * (2f * Mathf.PI) / r)) + b;
    }

    public static TSEase.EaseFunction EaseOut = FEaseOut;
    private static float FEaseOut(float t, float b, float c, float d, object p = null)
    {
        float s;
        float r=0;
        float a=c;

        if (t == 0)
        {
            return b;
        }
        if ((t /= d) == 1)
        {
            return b+c;
        }


        if (r == 0)
        {
            r = d * 0.3f;
        }

        if (a < Mathf.Abs(c))
        {
            a = c;
            s = r / 4;
        }
        else
        {
            s = r/(2f*Mathf.PI) * Mathf.Asin(c/a);
        }

        return a * Mathf.Pow(2f, -10f * t) * Mathf.Sin( (t * d-s) * (2f * Mathf.PI) / r ) + c + b;
    }

    public static TSEase.EaseFunction EaseInOut = FEaseInOut;
    private static float FEaseInOut(float t, float b, float c, float d, object p = null)
    {
        float s;
        float r=0;
        float a=c;

        if (t == 0)
        {
            return b;
        }
        if ((t /= d / 2) == 2)
        {
            return b+c;
        }
        if (r == 0)
        {
            r=d * (0.3f * 1.5f);
        }

        if (a < Mathf.Abs(c))
        {
            a=c;
            s=r/4;
        }
        else
        {
            s = r / (2*Mathf.PI) * Mathf.Asin (c/a);
        }
        if (t < 1)
        {
            return -0.5f * (a * Mathf.Pow(2f,10f * (t-=1)) * Mathf.Sin((t * d-s) * (2f * Mathf.PI)/r )) + b;
        }
        return a * Mathf.Pow(2f, -10f * (t-=1)) * Mathf.Sin((t * d-s) * (2 * Mathf.PI) / r)*0.5f + c + b;

    }
}