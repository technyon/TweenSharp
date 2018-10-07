using System;
using UnityEngine;

namespace TS
{
    public abstract class TSTimeDef
    {
        protected float duration;
        protected float startTime;
        public Action<object> onCompleteArg = null;
        public object onCompleteParams = null;
        public Action onComplete = null;
        protected bool paused = false;
        public bool suppressEvents = false;
        
        private float pausedTime;
        private bool useFrames;

        public float Progress
        {
            get
            {
                float now = Time.realtimeSinceStartup;
                if (now > startTime + duration)
                {
                    return 1;
                }
                return (now - startTime) / duration ;
            }
            set {
                float now = Time.realtimeSinceStartup;
                startTime = now - value * duration;
                Update(now);
            }
        }

        public bool Paused
        {
            get { return paused; }
            set
            {
                if (paused != value)
                {
                    paused = value;
                    if (paused)
                    {
                        pausedTime = Time.realtimeSinceStartup;
                    }
                    else
                    {
                        startTime =  Time.realtimeSinceStartup - (pausedTime - startTime);
                    }
                }
            }
        }

        public bool UseFrames
        {
            get { return useFrames; }
        }

        public TSTimeDef(float duration, bool useFrames = false)
        {
            startTime = Time.realtimeSinceStartup;
            this.useFrames = useFrames;
            if (useFrames)
            {
                this.duration = duration / (float)Screen.currentResolution.refreshRate;
            }
            else
            {
                this.duration = duration;
            }        }

        public void Kill()
        {
            TSScheduler.Unregister(this);
        }        
        
        public virtual bool Update(float time)
        {
            if ((time - startTime) > duration)
            {
                return true;
            }
            return false;
        }
    }
}