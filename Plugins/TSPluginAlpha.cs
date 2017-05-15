using System;
using UnityEngine;
using UnityEngine.UI;

namespace TS
{
    public class TSPluginAlpha : TSPlugin
    {
        private readonly string PROPERTY_NAME = "alpha";

        protected Renderer renderer;
        protected Graphic[] graphics;

        private TSDelegates.TSGetVal getVal;
        private TSDelegates.TSSetVal setVal;

        public override object Target
        {
            get { return base.Target; }
            set
            {
                base.Target = value;
                GameObject go = value as GameObject;

                if (go != null) {
                    if (go.GetComponent<RectTransform>() == null)
                    {
                        renderer = go.transform.GetComponent<Renderer>();
                    }
                    else
                    {
                        graphics = go.GetComponents<Graphic>();
                    }
                }
                if (renderer == null && graphics == null)
                {
                    Transform transform = value as Transform;
                    if (transform != null)
                    {
                        renderer = transform.GetComponent<Renderer>();
                    }
                }
                if (renderer == null && graphics == null)
                {
                    throw new Exception("TweenSharp: Can't tween alpha of object " + value);
                }
                if (renderer != null)
                {
                    getVal = GetValRenderer;
                    setVal = SetValRenderer;
                } else if (graphics != null)
                {
                    getVal = GetValGraphics;
                    setVal = SetValGraphics;
                }
            }
        }

        public override float Value
        {
            get { return getVal(); }
            set { setVal(value); }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }

        private float GetValRenderer()
        {
            return renderer.material.color.a;
        }
        private void SetValRenderer(float value)
        {
            Material material = renderer.material;
            material.color = new Vector4(material.color.r, material.color.g, material.color.b, value);
        }

        private float GetValGraphics()
        {
            if (graphics.Length > 0)
            {
                return graphics[0].color.a;
            }
            return 0;
        }
        private void SetValGraphics(float value)
        {
            foreach (Graphic graphic in graphics)
            {
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, value);
            }
        }
    }
}