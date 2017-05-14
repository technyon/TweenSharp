using System;
using System.Collections.Generic;
using System.Reflection;
using TS;
using UnityEngine;

public class TweenSharp
{
    private Dictionary<string, float> properties;

    private object target;
    private float duration;

    private List<string> propertyNames;
    private List<float> propertyStartValues;
    private List<float> propertyTargetValues;
    private List<TSPlugin> propertyPlugins;
    private List<PropertyInfo> propertyInfos;

    private float startTime;
    public TSEase.EaseFunction ease = Linear.EaseNone;

    public float delay = 0;
    public int overwrite = 0;
    public Action onComplete = null;
    public Action<object> onCompleteArg = null;
    public object onCompleteParams = null;
/*
        , onCompleteScope:1,
    useFrames:1, runBackwards:1, startAt:1, onUpdate:1, onUpdateParams:1, onUpdateScope:1,
    onStart:1, onStartParams:1, onStartScope:1, onReverseComplete:1, onReverseCompleteParams:1, onReverseCompleteScope:1,
    onRepeat:1, onRepeatParams:1, onRepeatScope:1, easeParams:1,
    yoyo:1, onCompleteListener:1, onUpdateListener:1, onStartListener:1, onReverseCompleteListener:1, onRepeatListener:1,
    orientToBezier:1, immediateRender:1, repeat:1, repeatDelay:1, data:1, paused:1, reversed:1};
*/

    public TweenSharp(object target, float duration, Dictionary<string, object> args)
    {
        float f = 0;
        this.target = target;
        this.duration = duration;

        startTime = Time.realtimeSinceStartup;

        propertyNames = new List<string>();
        propertyStartValues = new List<float>();
        propertyTargetValues = new List<float>();
        propertyPlugins = new List<TSPlugin>();
        propertyInfos = new List<PropertyInfo>();

        foreach (KeyValuePair<string, object> kvp in args)
        {
            string key = kvp.Key;

            if (!TSKeywordParser.Parse(this, kvp) )
            {

                propertyNames.Add(key);
                propertyInfos.Add(null);

                TSPlugin plugin = PluginManager.GetPlugin(key);
                if (plugin != null)
                {
                    plugin.Target = target;
                }
                propertyPlugins.Add(plugin);

                if (kvp.Value is float)
                {
                    if (plugin != null)
                    {
                        propertyStartValues.Add(plugin.Value);
                    }
                    else
                    {
                        propertyStartValues.Add(0f);
                    }
                    propertyTargetValues.Add((float) kvp.Value);
                }
            }
        }

        PropertyInfo[] pis = target.GetType().GetProperties();
        foreach (PropertyInfo pi in pis)
        {
            int ind = propertyNames.IndexOf(pi.Name);
            if (ind != -1 && propertyPlugins[ind] == null)
            {
                object val = pi.GetValue(target, null);
                if (val is float)
                {
                    propertyStartValues[ind] = (float) val;
                }
                propertyInfos[ind] = pi;
            }
        }

        int len = propertyNames.Count;
        for (int i = 0; i < len; i++)
        {
            if (propertyInfos[i] == null && propertyPlugins[i] == null)
            {
                throw new Exception("Tweensharp(): Property " + propertyNames[i] + " not found on object " + target +".");
            }
        }


        TSScheduler.Register(this);
    }

    public bool Update(float time)
    {
        int len = propertyNames.Count;
        float timePassed = time - startTime;
        bool finished = false;

        if (timePassed > duration)
        {
            timePassed = duration;
            finished = true;
        }

        for (int i = 0; i < len; i++)
        {
            float startVal = propertyStartValues[i];
            float targetVal = propertyTargetValues[i];
            TSPlugin plugin = propertyPlugins[i];

            if (plugin == null)
            {
                PropertyInfo pi = propertyInfos[i];
                pi.SetValue(target, ease(timePassed, startVal, targetVal - startVal, duration), null);
            }
            else
            {
                plugin.Value = ease(timePassed, startVal, targetVal - startVal, duration);
            }        }
        return finished;
    }
}