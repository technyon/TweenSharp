using UnityEngine;

namespace TS
{
    public class TSPluginPositionY : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "positionY";

        public override float Value
        {
            get { return transform.position.y; }
            set
            {
                Vector3 pos = transform.position;
                pos.y = value;
                transform.position = pos;
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}