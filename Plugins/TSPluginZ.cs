using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginZ : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "Z";

        public override float Value
        {
            get
            {
                if (transform != null)
                {
                    return transform.position.z;
                }
                return 0;
            }
            set
            {
                if (transform != null)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, value);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}