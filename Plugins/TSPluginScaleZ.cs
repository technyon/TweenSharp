using System;
using UnityEngine;

namespace TS
{
    public class TSPluginScaleZ : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "scaleZ";

        public override float Value
        {
            get { return transform.localScale.z; }
            set { transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, value); }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}