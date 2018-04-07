using UnityEngine;

namespace TS
{
    public class TSPluginZ : TSAutoTransformPlugin
    {
        private readonly string PROPERTY_NAME = "z";

        protected override float GetValTransform()
        {
            return transform.position.z;
        }
        protected override void SetValTransform(float value)
        {
            Vector3 pos = transform.localPosition;
            pos.z = value;
            transform.localPosition = pos;
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