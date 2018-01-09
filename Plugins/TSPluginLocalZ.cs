using UnityEngine;

namespace TS
{
    public class TSPluginLocalZ : TSAutoTransformPlugin
    {
        private readonly string PROPERTY_NAME = "localZ";

        public override float Value
        {
            get { return transform.localPosition.z; }
            set { transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, value); }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}