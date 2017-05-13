using System.Collections.Generic;
using System.Threading;
using TS.Plugins;
using UnityEngine;

namespace TS
{
    public class TSScheduler : MonoBehaviour
    {
        private static TSScheduler instance;

        private List<TweenSharp> tweens;

        public static void Register(TweenSharp tweensharp)
        {
            instance.tweens.Add(tweensharp);
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                tweens = new List<TweenSharp>();
                PluginManager.Init();
            }
        }


    }
}