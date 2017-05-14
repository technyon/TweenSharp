using System;
using UnityEngine;

namespace TS
{
    public class TSTransformPlugin : TSPlugin
    {
        protected Transform transform;

        public override object Target
        {
            set
            {
                GameObject go = value as GameObject;
                if (go != null)
                {
                    transform = go.transform;
                }
                else
                {
                    throw new Exception("TweenSharp: Trying to tween transform property on a non-GameObject.");
                }
                base.Target = value;
            }
        }
    }
}