using System;
using UnityEngine;

namespace TS
{
    public class TSTransformPlugin : TSPlugin
    {
        protected Transform transform;

        public override object Target
        {
            get { return base.Target; }
            set
            {
                base.Target = value;
                transform = value as Transform;
                if (transform == null)
                {
                    GameObject go = value as  GameObject;
                    if (go != null)
                    {
                        transform = go.transform;
                    }
                }
                if (transform == null)
                {
                    throw new Exception("TweenSharp: Trying to tween " + PropertyName + ", but object isn't of type GameObject or Transform");
                }
            }
        }
    }
}