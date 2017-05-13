using NUnit.Framework.Constraints;
using UnityEngine;

namespace TS.Plugins
{
    public class TSPluginX : TSPlugin
    {
        private GameObject gameObject;

        public TSPluginX()
        {
        }

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
                    gameObject.transform.position = new Vector3(value, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }
        }

        public override string PropertyName
        {
            get { return "X"; }
        }
    }
}