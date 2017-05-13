using System.Collections.Generic;
using System.Threading;
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

        public static void Unregister(TweenSharp tweensharp)
        {
            instance.tweens.Remove(tweensharp);
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

        private void Update()
        {
            float time = Time.realtimeSinceStartup;
            foreach (TweenSharp tween in tweens)
            {
                tween.Update(time);
            }
        }
    }
}