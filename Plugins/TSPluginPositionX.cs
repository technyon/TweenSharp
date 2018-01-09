using UnityEngine;

namespace TS
{
    public class TSPluginPositionX : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "positionX";

        public override float Value
        {
            get { return transform.position.x; }
            set
            {
                Vector3 pos = transform.position;
                pos.x = value;
                transform.position = pos;
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}