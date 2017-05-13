using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace TS
{
    public class TSScheduler : MonoBehaviour
    {
        private static TSScheduler instance;

        private List<TweenSharp> tweens;
        private List<TweenSharp> removeList;

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
                removeList = new List<TweenSharp>();
            }
        }

        private void Update()
        {
            removeList.Clear();

            float time = Time.realtimeSinceStartup;
            foreach (TweenSharp tween in tweens)
            {
                if (tween.Update(time))
                {
                    removeList.Add(tween);
                }
            }

            foreach (TweenSharp tween in removeList)
            {
                tweens.Remove(tween);
            }
        }
    }
}