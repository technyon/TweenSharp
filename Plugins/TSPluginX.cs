using UnityEngine;

namespace TS
{
    public class TSPluginX : TSAutoTransformPlugin
    {
        private readonly string PROPERTY_NAME = "x";

        protected override float GetValTransform()
        {
            return transform.position.x;
        }
        protected override void SetValTransform(float value)
        {
            Vector3 pos = transform.localPosition;
            pos.x = value;
            transform.localPosition = pos;        }
        protected override float GetValRectTransform()
        {
            return rectTransform.anchoredPosition.x;
        }
        protected override void SetValRectTransform(float value)
        {
            Vector2 pos = rectTransform.anchoredPosition;
            pos.x = value;
            rectTransform.anchoredPosition = pos;
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}