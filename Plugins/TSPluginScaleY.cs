using UnityEngine;

namespace TS
{
    public class TSPluginScaleY : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "scaleY";

        public override float Value
        {
            get { return transform.localScale.y; }
            set { transform.localScale = new Vector3(transform.localScale.x, value, transform.localScale.z); }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}