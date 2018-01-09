using UnityEngine;

namespace TS
{
    public class TSPluginLocalX : TSAutoTransformPlugin
    {
        private readonly string PROPERTY_NAME = "localX";

        public override float Value
        {
            get
            {
                if (transform != null)
                {
                    return transform.localPosition.x;
                }
                else
                {
                    return rectTransform.localPosition.x;
                }
            }
            set
            {
                if (transform != null)
                {
                    transform.localPosition = new Vector3(value, transform.localPosition.y, transform.localPosition.z);
                }
                else
                {
                    rectTransform.localPosition = new Vector3(value, rectTransform.localPosition.y, rectTransform.localPosition.z);
                }
                
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}