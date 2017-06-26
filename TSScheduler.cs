using System;
using System.Collections.Generic;
using UnityEngine;

namespace TS
{
    public class TSScheduler : MonoBehaviour
    {
        private static TSScheduler instance;

        private List<TSTimeDef> tweens;

        public static void Register(TSTimeDef tweensharp, bool dupeCheck = false)
        {
            if (!dupeCheck || !instance.tweens.Contains(tweensharp))
            {
                instance.tweens.Add(tweensharp);
            }
        }

        public static void Unregister(TSTimeDef tween)
        {
            instance.tweens.Remove(tween);
        }

        public static void KillAllDelayedCallsTo(Action callback)
        {
            foreach (TSTimeDef td in instance.tweens)
            {
                if (td is DC)
                {
                    if (td.onComplete == callback)
                    {
                        Unregister(td);
                    }
                }
            }
        }
        public static void KillAllDelayedCallsTo(Action<object> callback)
        {
            foreach (TSTimeDef td in instance.tweens)
            {
                if (td is DC)
                {
                    if (td.onCompleteArg == callback)
                    {
                        Unregister(td);
                    }
                }
            }
        }
        
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                tweens = new List<TSTimeDef>();
                TSPluginManager.Init();

                TSKeywordParser.Init();
            }
        }

        private void Update()
        {
            List<TSTimeDef> removeListUpdate = new List<TSTimeDef>();

            float time = Time.realtimeSinceStartup;
            foreach (TSTimeDef tween in tweens)
            {
                if (tween.Update(time))
                {
                    removeListUpdate.Add(tween);
                }
            }

            foreach (TSTimeDef tween in removeListUpdate)
            {
                tweens.Remove(tween);

                if (tween.onComplete != null && !tween.suppressEvents)
                {
                    tween.onComplete();
                }
                if (tween.onCompleteArg != null && !tween.suppressEvents)
                {
                    tween.onCompleteArg(tween.onCompleteParams);
                }
            }
        }
    }
}