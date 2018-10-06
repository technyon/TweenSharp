using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TS
{
    public class TSPluginAlpha : TSPlugin
    {
        private readonly string PROPERTY_NAME = "alpha";

        protected CanvasGroup canvasGroup;
        protected Renderer[] renderer;
        protected Graphic[] graphics;
        protected TMP_Text[] texts;
        

        protected TSDelegates.TSGetVal getVal;
        protected TSDelegates.TSSetVal setVal;

        public override object Target
        {
            get { return base.Target; }
            set
            {
                
                base.Target = value;
                GameObject go = value as GameObject;

                if (go != null)
                {
                    canvasGroup = go.GetComponent<CanvasGroup>();

                    if (canvasGroup == null)
                    {
                        if (go.GetComponent<RectTransform>() == null)
                        {
                            renderer = go.GetComponentsInChildren<Renderer>();
                        }
                        else
                        {
                            graphics = go.GetComponentsInChildren<Graphic>();
                        }
                        texts = go.GetComponentsInChildren<TMP_Text>();
                    }
                }
                if (canvasGroup == null && renderer == null && graphics == null)
                {
                    Transform transform = value as Transform;
                    if (transform != null)
                    {
                        renderer = transform.GetComponentsInChildren<Renderer>();
                    }
                }
                if (canvasGroup == null && renderer == null && graphics == null)
                {
                    throw new Exception("TweenSharp: Can't tween alpha of object " + value + ". No suitable components found.");
                }
                
                if (renderer != null)
                {
                    getVal = GetValRenderer;
                    setVal = SetValRenderer;
                } else if (graphics != null)
                {
                    getVal = GetValGraphics;
                    setVal = SetValGraphics;
                } else if (canvasGroup != null)
                {
                    getVal = GetValCanvasGroup;
                    setVal = SetValCanvasGroup;
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
            if (renderer.Length > 0)
            {
                return renderer[0].material.color.a;
            }
            return 0;
        }
        private void SetValRenderer(float value)
        {
            foreach (Renderer graphic in renderer)
            {
                Color c = graphic.material.color;
                c.a = value;
                graphic.material.color = c;
            }
            foreach (TMP_Text text in texts)
            {
                Color c = text.color;
                c.a = value;
                text.color = c;
            }
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
                Color c = graphic.color;
                c.a = value;
                graphic.color = c;
            }
            foreach (TMP_Text text in texts)
            {
                Color c = text.color;
                c.a = value;
                text.color = c;
            }
        }
        
        private float GetValCanvasGroup()
        {
            return canvasGroup.alpha;
        }
        private void SetValCanvasGroup(float value)
        {
            canvasGroup.alpha = value;
        }
    }
}
