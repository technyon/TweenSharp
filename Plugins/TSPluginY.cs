using UnityEngine;

namespace TS
{
    public class TSPluginY : TSAutoTransformPlugin
    {
        private readonly string PROPERTY_NAME = "y";

        protected override float GetValTransform()
        {
            return transform.position.y;
        }
        protected override void SetValTransform(float value)
        {
            Vector3 pos = transform.localPosition;
            pos.y = value;
            transform.position = pos;
        }
        protected override float GetValRectTransform()
        {
            return rectTransform.anchoredPosition.y;
        }
        protected override void SetValRectTransform(float value)
        {
            if (rectTransform != null)
            {
                Vector2 pos = rectTransform.anchoredPosition;
                pos.y = value;
                rectTransform.anchoredPosition = pos;
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}