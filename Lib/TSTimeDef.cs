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

        public TSTimeDef(float duration)
        {
            startTime = Time.realtimeSinceStartup;
            this.duration = duration;
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