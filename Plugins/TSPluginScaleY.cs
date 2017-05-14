using UnityEngine;

namespace TS
{
    public class TSPluginScaleY : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "scaleY";

        protected override float GetValTransform()
        {
            return transform.localScale.y;
        }
        protected override void SetValTransform(float value)
        {
            transform.localScale = new Vector3(transform.localScale.x, value, transform.localScale.z);
        }
        protected override float GetValRectTransform()
        {
            return rectTransform.localScale.y;
        }
        protected override void SetValRectTransform(float value)
        {
            rectTransform.localScale = new Vector2(rectTransform.localScale.x, value);
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}