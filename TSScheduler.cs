using System;
using System.Collections.Generic;
using UnityEngine;

namespace TS
{
    public class TSScheduler : MonoBehaviour
    {
        private static TSScheduler instance;
        private static TSSettings settings;

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

        public static void KillTweensOf(object target)
        {
            List<TweenSharp> toBeUnregistered = new List<TweenSharp>();
            foreach (TSTimeDef td in instance.tweens)
            {
                TweenSharp tweenSharp = td as TweenSharp;
                if (tweenSharp != null && tweenSharp.HasTarget(target))
                {
                    toBeUnregistered.Add(tweenSharp);
                }
            }
            
            foreach (TweenSharp tweenSharp in toBeUnregistered)
            {
                Unregister(tweenSharp);
            }
        }
        
        #region DelayCallMethods
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
        #endregion DelayCallMethods
 
        [RuntimeInitializeOnLoadMethod(loadType: RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void InitializeOnLoad() {
            if (Settings.InstantiateOnLoad)
            {
                GameObject gameObject = new GameObject("TweenSharp");
                gameObject.AddComponent<TSScheduler>();
                DontDestroyOnLoad(gameObject);
            }
        }

        private static TSSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = Resources.Load<TSSettings>("TSSettings");
                }

                return settings;
            }
        }
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                tweens = new List<TSTimeDef>();
                TSPluginManager.Init();

                TSKeywordParser.Init();
            }
            else
            {
                throw new Exception("TSScheduler is a singleton, but instatiated twice. Make sure only one copy exists, and consider disabling InstantiateOnLoad in TweenSharp settings.");
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