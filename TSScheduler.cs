using System;
using System.Collections.Generic;
using UnityEngine;

namespace TS
{
    public class TSScheduler : MonoBehaviour
    {
        private static TSScheduler instance;

        private List<TSTimeDef> tweens;
        private List<TSTimeDef> removeList;

        public static void Register(TSTimeDef tweensharp)
        {
            instance.tweens.Add(tweensharp);
        }

        public static void Unregister(TSTimeDef tween)
        {
            instance.tweens.Remove(tween);
        }

        public static void KillAllDelayedCallsTo(Action callback)
        {
            instance.removeList.Clear();
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
            instance.removeList.Clear();
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
                removeList = new List<TSTimeDef>();

                TSKeywordParser.Init();
            }
        }

        private void Update()
        {
            removeList.Clear();

            float time = Time.realtimeSinceStartup;
            foreach (TSTimeDef tween in tweens)
            {
                if (tween.Update(time))
                {
                    removeList.Add(tween);
                }
            }

            foreach (TSTimeDef tween in removeList)
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