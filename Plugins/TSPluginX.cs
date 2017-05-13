using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS
{
    public class TSPluginX : TSPlugin
    {
        private readonly string PROPERTY_NAME = "X";

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
                    return gameObject.transform.position.x;
                }
                return 0;
            }
            set
            {
                if (gameObject != null)
                {
                    Debug.Log(value.ToString());
                    gameObject.transform.position = new Vector3(value, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }
        }

        public override string PropertyName
        {
            get { return PROPERTY_NAME; }
        }
    }
}