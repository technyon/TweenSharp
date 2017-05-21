using System;
using UnityEngine;

namespace TS
{
    public class TSPluginRotationX : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "rotationX";

        public override float Value
        {
            get { return transform.rotation.eulerAngles.x; }
            set
            {
                Quaternion rotation = transform.rotation;
                Vector3 euler = rotation.eulerAngles;
                euler.x = value;
                rotation.eulerAngles = euler;
                transform.rotation = rotation;
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}