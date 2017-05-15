using UnityEngine;

namespace TS
{
    public class TSPluginY : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "y";

        protected override float GetValTransform()
        {
            return transform.position.y;
        }
        protected override void SetValTransform(float value)
        {
            transform.position = new Vector3(transform.position.x, value, transform.position.z);
        }
        protected override float GetValRectTransform()
        {
            return rectTransform.anchoredPosition.y;
        }
        protected override void SetValRectTransform(float value)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, value);
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}