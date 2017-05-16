using UnityEngine;

namespace TS
{
    public class TSPluginSizeDeltaX : TSRectTransformPlugin
    {
        private readonly string PROPERTY_NAME = "sizeDeltaX";

        public override float Value
        {
            get { return rectTransform.sizeDelta.x; }
            set { rectTransform.sizeDelta = new Vector2(value, rectTransform.sizeDelta.y); }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}