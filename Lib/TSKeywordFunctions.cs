using System;

namespace TS
{
    public class TSKeywordFunctions
    {

        public void Delay(TweenSharp tween, object args)
        {
            tween.delay = (float) args;
        }

        public void OnComplete(TweenSharp tween, object args)
        {
            if (args is Action)
            {
                tween.onComplete = args as Action;
            }
            if (args is Action<object>)
            {
                tween.onCompleteArg = args as Action<object>;
            }
        }

        public void OnCompleteParams(TweenSharp tween, object args)
        {
            tween.onCompleteParams = args;
        }
    }
}