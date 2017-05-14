using System;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginX : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "X";

        public override float Value
        {
            get
            {
                if (transform != null)
                {
                    return transform.position.x;
                }
                return 0;
            }
            set
            {
                if (transform != null)
                {
                    transform.position = new Vector3(value, transform.position.y, transform.position.z);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}