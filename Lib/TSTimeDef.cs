using System;
using UnityEngine;

namespace TS
{
    public class TSTimeDef
    {
        protected float duration;
        protected float startTime;
        public Action<object> onCompleteArg = null;
        public object onCompleteParams = null;
        public Action onComplete = null;


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
        
        public TSTimeDef(float duration)
        {
            startTime = Time.realtimeSinceStartup;
            this.duration = duration;
        }

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