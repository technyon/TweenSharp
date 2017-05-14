using System;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginAnchoredX : TSRectTransformPlugin
    {
        private readonly string PROPERTY_NAME = "anchoredX";

        public override float Value
        {
            get
            {
                if (transform != null)
                {
                    return transform.anchoredPosition.x;
                }
                return 0;
            }
            set
            {
                if (transform != null)
                {
//                    Debug.Log(value.ToString());
                    transform.anchoredPosition = new Vector2(value, transform.anchoredPosition.y);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}