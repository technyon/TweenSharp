using System;
using System.Collections.Generic;
using System.Reflection;
using TS;
using UnityEngine;

public class TweenSharp: TSTimeDef
{
    public float delay = 0;
    public int overwrite = 0;
    public Action onUpdate = null;
    public Action<object> onUpdateArg = null;
    public object onUpdateParams = null;
    public bool reversed = false;

    private float position;
    private Dictionary<string, float> properties;

    private object target;

    private List<string> propertyNames;
    private List<float> propertyStartValues;
    private List<float> propertyTargetValues;
    private List<TSPlugin> propertyPlugins;
    private List<PropertyInfo> propertyInfos;

    public TSEase.EaseFunction ease = Linear.EaseNone;

    public TweenSharp(object target, float duration, object args) : base(duration)
    {
        this.target = target;
        Init((args as Dictionary<string, object>) ?? args.ToDictionary());
    }

    // -- Internal functions --
    private void Init(Dictionary<string, object> args)
    {
        InitVariables();

        foreach (KeyValuePair<string, object> kvp in args)
        {
            string key = kvp.Key;
            object value = kvp.Value;

            if (!TSKeywordParser.Parse(this, kvp))
            {
                ParseKeyValue(key, value);
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
                    propertyStartValues[ind] = (float)val;
                }
                propertyInfos[ind] = pi;
            }
        }

        int len = propertyNames.Count;
        for (int i = 0; i < len; i++)
        {
            if (propertyInfos[i] == null && propertyPlugins[i] == null)
            {
                throw new Exception("Tweensharp(): Property " + propertyNames[i] + " not found on object " + target + ".");
            }
        }

        TSScheduler.Register(this);
    }

    private void InitVariables()
    {
        propertyNames = new List<string>();
        propertyStartValues = new List<float>();
        propertyTargetValues = new List<float>();
        propertyPlugins = new List<TSPlugin>();
        propertyInfos = new List<PropertyInfo>();
    }

    private void ParseKeyValue(string key, object value)
    {
        propertyNames.Add(key);
        propertyInfos.Add(null);

        TSPlugin plugin = TSPluginManager.GetPlugin(key);
        if (plugin != null)
        {
            plugin.Target = target;
        }
        propertyPlugins.Add(plugin);

        if (value is float)
        {
            if (plugin != null)
            {
                propertyStartValues.Add(plugin.Value);
            }
            else
            {
                propertyStartValues.Add(0f);
            }
            propertyTargetValues.Add((float)value);
        }
        else
        {
            propertyStartValues.Add(0f);
            propertyTargetValues.Add(0f);
            throw new Exception("Tweensharp: Value is not of type float.");
        }
    }    

    public void Restart()
    {
        startTime = Time.realtimeSinceStartup;
        TSScheduler.Register(this, true);
    }
    
    public override bool Update(float time)
    {
        if (!paused && startTime + delay < time)
        {
            int len = propertyNames.Count;
            float timePassed;
            bool finished = false;

            if (reversed)
            {
                timePassed = duration - (time - startTime - delay);
                if (timePassed <= 0)
                {
                    timePassed = 0;
                    finished = true;
                }
            }
            else
            {
                timePassed = time - startTime - delay;

                if (timePassed > duration)
                {
                    timePassed = duration;
                    finished = true;
                }
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
                }

                if (onUpdate != null && !suppressEvents) { onUpdate(); }
                if (onUpdateArg != null && !suppressEvents) { onUpdateArg(onUpdateParams); }
            }
            return finished;
        }
        return false;
    }

    public static TweenSharp To(object target, float duration, object args)
    {
        return new TweenSharp(target, duration, args);
    }
    
    // -- Static functions --
    public static DC DelayedCall(float delay, Action callback)
    {
        DC dc = new DC(delay);
        dc.onComplete = callback;
        TSScheduler.Register(dc);
        return dc;
    }
    public static DC DelayedCall(float delay, Action<object> callback, object pars)
    {
        DC dc = new DC(delay);
        dc.onCompleteArg = callback;
        dc.onCompleteParams = pars;
        TSScheduler.Register(dc);
        return dc;
    }
    public static void KillAllDelayedCallsTo(Action callback)
    {
        TSScheduler.KillAllDelayedCallsTo(callback);
    }
    public static void KillAllDelayedCallsTo(Action<object> callback)
    {
        TSScheduler.KillAllDelayedCallsTo(callback);
    }
    
    public static void Activate(Type pluginType)
    {
        TSPluginManager.Activate(pluginType);
    }
}