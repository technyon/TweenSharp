namespace TS
{
    public class TSKeywordFunctions
    {

        public void Delay(TweenSharp tween, object args)
        {
            tween.delay = (float) args;
        }
    }
}