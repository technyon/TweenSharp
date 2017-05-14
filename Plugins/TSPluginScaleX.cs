using System;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginScaleX : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "scaleX";

        public override float Value
        {
            get
            {
                if (transform != null)
                {
                    return transform.localScale.x;
                }
                return 0;
            }
            set
            {
                if (transform != null)
                {
                    transform.localScale = new Vector3(value, transform.localScale.y, transform.localScale.z);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}