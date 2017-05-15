using System;
using System.Xml.Schema;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginAlpha : TSPlugin
    {
        private readonly string PROPERTY_NAME = "alpha";

        protected Renderer renderer;

        public override object Target
        {
            get { return base.Target; }
            set
            {
                base.Target = value;
                GameObject go = value as GameObject;
                if (go != null)
                {
                    renderer = go.transform.GetComponent<Renderer>();
                }
                if (renderer == null)
                {
                    Transform transform = value as Transform;
                    if (transform != null)
                    {
                        renderer = transform.GetComponent<Renderer>();
                    }
                }
                if (renderer == null)
                {
                    throw new Exception("TweenSharp: Target is not of type GameObject or Transform.");
                }
            }
        }

        public override float Value
        {
            get { return renderer.material.color.a; }
            set
            {
                Material material = renderer.material;
                material.color = new Vector4(material.color.r, material.color.g, material.color.b, value);
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}