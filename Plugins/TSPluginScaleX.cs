using UnityEngine;

namespace TS
{
    public class TSPluginScaleX : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "scaleX";

        protected override float GetValTransform()
        {
            return transform.localScale.x;
        }
        protected override void SetValTransform(float value)
        {
            transform.localScale = new Vector3(value, transform.localScale.y, transform.localScale.z);
        }
        protected override float GetValRectTransform()
        {
            return rectTransform.localScale.x;
        }
        protected override void SetValRectTransform(float value)
        {
            rectTransform.localScale = new Vector2(value, rectTransform.localScale.y);
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}