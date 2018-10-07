using UnityEngine;

namespace TS
{
    public class TSSettings : ScriptableObject
    {
        [SerializeField]private bool _instantiateOnLoad = true;

        public bool InstantiateOnLoad
        {
            get { return _instantiateOnLoad; }
        }
    }
}