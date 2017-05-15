using UnityEngine;

namespace TS
{
    public class TSPluginScaleZ : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "scaleZ";

        protected override float GetValTransform()
        {
            return transform.localScale.z;
        }
        protected override void SetValTransform(float value)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, value);
        }
        protected override float GetValRectTransform()
        {
            return rectTransform.localScale.z;
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}