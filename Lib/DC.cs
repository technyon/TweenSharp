using TS;

public class DC : TSTimeDef
{
    public DC(float duration) : base(duration)
    {
        
    }

    public void Kill()
    {
        TSScheduler.Unregister(this);
    }
}
