using System;
using System.Xml.Schema;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginAutoAlpha : TSPluginAlpha
    {
        private readonly string PROPERTY_NAME = "autoAlpha";

        private GameObject gameObject;

        public override object Target
        {
            get { return base.Target; }
            set
            {
                base.Target = value;
                gameObject = value as GameObject;
            }
        }

        public override float Value
        {
            get { return renderer.material.color.a; }
            set
            {
                base.Value = value;
                if (gameObject != null)
                {
                    Debug.Log(value.ToString());
                    gameObject.SetActive(value != 0);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}