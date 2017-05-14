using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginZ : TSPlugin
    {
        private readonly string PROPERTY_NAME = "Z";

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
                    return gameObject.transform.position.z;
                }
                return 0;
            }
            set
            {
                if (gameObject != null)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, value);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}