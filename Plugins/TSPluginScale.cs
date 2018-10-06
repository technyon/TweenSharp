using UnityEngine;

namespace TS
{
    public class TSPluginScale : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "scale";

        public override float Value
        {
            get { return (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3; }
            set { transform.localScale = new Vector3(value, value, value); }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}