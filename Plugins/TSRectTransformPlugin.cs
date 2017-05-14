using System;
using UnityEngine;

namespace TS
{
    public class TSRectTransformPlugin : TSPlugin
    {
        protected RectTransform transform;

        public override object Target
        {
            set
            {
                GameObject go = value as GameObject;
                if (go != null)
                {

                    transform = go.GetComponent<RectTransform>();
                    if (transform == null)
                    {
                        throw new Exception("TweenSharp: Trying to tween RectTransform property, but the GameObject doesn't have a RectTransform.");
                    }
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