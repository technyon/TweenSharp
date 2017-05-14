using System;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginScaleZ : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "scaleZ";

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
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, value);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}