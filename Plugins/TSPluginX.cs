using System;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginX : TSTransformPlugin
    {
        private readonly string PROPERTY_NAME = "x";

        protected override float GetValTransform()
        {
            return transform.position.x;
        }
        protected override void SetValTransform(float value)
        {
            transform.position = new Vector3(value, transform.position.y, transform.position.z);
        }
        protected override float GetValRectTransform()
        {
            return rectTransform.anchoredPosition.x;
        }
        protected override void SetValRectTransform(float value)
        {
            rectTransform.anchoredPosition = new Vector2(value, rectTransform.anchoredPosition.y);
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}