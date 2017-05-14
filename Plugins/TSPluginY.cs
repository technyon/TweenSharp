using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginY : TSPlugin
    {
        private readonly string PROPERTY_NAME = "Y";

        private GameObject gameObject;

        public override object Target
        {
            set
            {
                gameObject = value as GameObject;
                base.Target = value;
            }
        }

        public override float Value
        {
            get
            {
                if (gameObject != null)
                {
                    return gameObject.transform.position.y;
                }
                return 0;
            }
            set
            {
                if (gameObject != null)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, value, gameObject.transform.position.z);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}