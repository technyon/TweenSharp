using UnityEngine;

namespace TS
{
    public class TSPluginSizeDeltaY : TSRectTransformPlugin
    {
        private readonly string PROPERTY_NAME = "sizeDeltaY";

        public override float Value
        {
            get { return rectTransform.sizeDelta.y; }
            set { rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.y, value); }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}