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
                Quaternion rotation = transform.localRotation;
                Vector3 euler = rotation.eulerAngles;
                euler.y = value;
                rotation.eulerAngles = euler;
                transform.localRotation = rotation;
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}