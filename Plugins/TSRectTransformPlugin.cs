using System;
using UnityEngine;

namespace TS
{
    public class TSRectTransformPlugin : TSPlugin
    {
        protected RectTransform rectTransform;

        public override object Target
        {
            get { return base.Target; }
            set
            {
                base.Target = value;
                rectTransform = value as RectTransform;
                if (rectTransform == null)
                {
                    GameObject go = value as  GameObject;
                    if (go != null)
                    {
                        rectTransform = go.GetComponent<RectTransform>();
                    }
                }
                if (rectTransform == null)
                {
                    throw new Exception("TweenSharp: Trying to tween " + PropertyName + ", but object isn't of type RectTransform / GameObject with RectTransform");
                }
            }
        }
    }
}