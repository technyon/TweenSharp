using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginY : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "Y";

        public override float Value
        {
            get
            {
                if (transform != null)
                {
                    return transform.position.y;
                }
                return 0;
            }
            set
            {
                if (transform != null)
                {
                    transform.position = new Vector3(transform.position.x, value, transform.position.z);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}