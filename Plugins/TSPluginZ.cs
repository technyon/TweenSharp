using UnityEngine;

namespace TS
{
    public class TSPluginZ : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "z";

        protected override float GetValTransform()
        {
            return transform.position.z;
        }
        protected override void SetValTransform(float value)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, value);
        }
        protected override float GetValRectTransform()
        {
            return rectTransform.position.z;
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}