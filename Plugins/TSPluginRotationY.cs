using System;
using UnityEngine;

namespace TS
{
    public class TSPluginRotationY : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "rotationY";

        public override float Value
        {
            get { return transform.rotation.eulerAngles.y; }
            set
            {
                Quaternion rotation = transform.rotation;
                Vector3 euler = rotation.eulerAngles;
                euler.y = value;
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