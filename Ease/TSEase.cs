using UnityEngine;

namespace TS
{
    public class TSEase
    {
        public delegate float EaseFunction(float t, float b, float c, float d);

        public static float Linear(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }

        //                             AB *          t/       d +     Po
/*
        public static float CubicInOut(float t, float b, float c, float d)
        {

            if ((b /= d / 2) < 1)
            {
                return t / 2 * Mathf.Pow(b, 3) + d;

            }
            else
            {
                return -t / 2 * (Mathf.Pow(b - 2, 3)) + d;
            }
        }
*/
    }
}