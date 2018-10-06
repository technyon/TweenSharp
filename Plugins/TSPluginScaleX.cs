using UnityEngine;

namespace TS
{
    public class TSPluginScaleX : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "scaleX";

        public override float Value
        {
            get { return transform.localScale.x; }
            set { transform.localScale = new Vector3(value, transform.localScale.y, transform.localScale.z); }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}