using System;
using UnityEngine;

namespace TS
{
    public class TSAutoTransformPlugin : TSPlugin
    {
        protected Transform transform;
        protected RectTransform rectTransform;

        private TSDelegates.TSGetVal getVal;
        private TSDelegates.TSSetVal setVal;

        public override object Target
        {
            set
            {
                GameObject go = value as GameObject;
                if (go != null)
                {
                    rectTransform = go.GetComponent<RectTransform>();
                    if (rectTransform != null)
                    {
                        getVal = GetValRectTransform;
                        setVal = SetValRectTransform;
                    }
                    else
                    {
                        transform = go.transform;
                        getVal = GetValTransform;
                        setVal = SetValTransform;
                    }
                }
                else
                {
                    rectTransform = value as RectTransform;
                    if (rectTransform != null)
                    {
                        getVal = GetValRectTransform;
                        setVal = SetValRectTransform;
                    }
                    else
                    {
                        transform = value as Transform;
                        if (transform != null)
                        {
                            getVal = GetValTransform;
                            setVal = SetValTransform;
                        }
                    }
                }
                base.Target = value;

                if (getVal == null)
                {
                    throw new Exception("TweenSharp: Trying to tween property " + PropertyName + ", but object isn't of type GameObject, Transform or RectTransform.");
                }
            }
        }

        public override float Value
        {
            get
            {
                return getVal();
            }
            set
            {
                setVal(value);
            }
        }

        protected virtual float GetValTransform()
        {
            return 0;
        }
        protected virtual void SetValTransform(float value)
        {
        }
        protected virtual float GetValRectTransform()
        {
            return 0;
        }
        protected virtual void SetValRectTransform(float value)
        {
        }
    }
}