using UnityEngine;

namespace TS
{
    public class TSPluginPositionZ : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "positionZ";

        public override float Value
        {
            get { return transform.position.z; }
            set
            {
                Vector3 pos = transform.position;
                pos.z = value;
                transform.position = pos;
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}