using UnityEngine;

namespace TS
{
    public class TSPluginLocalY : TSAutoTransformPlugin
    {
        private readonly string PROPERTY_NAME = "localY";

        public override float Value
        {
            get
            {
                if (transform != null)
                {
                    return transform.localPosition.y;
                }
                else
                {
                    return rectTransform.localPosition.y;
                }                
            }
            set
            {
                if (transform != null)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, value, transform.localPosition.z);
                }
                else
                {
                    rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, value, rectTransform.localPosition.z);
                }                
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}