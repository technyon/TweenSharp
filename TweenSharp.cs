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
    private TSEase.EaseFunction easeFunction = TSEase.Linear;

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
        TSScheduler.Register(this);
    }

    public bool Update(float time)
    {
        int len = propertyNames.Count;

        float timePassed = time - startTime;

        if (timePassed <= duration)
        {
            for (int i = 0; i < len; i++)
            {
                string propertyName = propertyNames[i];
                float startVal = propertyStartValues[i];
                float targetVal = propertyTargetValues[i];
                TSPlugin plugin = propertyPlugins[i];


                if (plugin == null)
                {
                    PropertyInfo pi = propertyInfos[i];
                    pi.SetValue(target, easeFunction(timePassed, startVal, targetVal - startVal, duration), null);
                }
                else
                {
                    plugin.Value = easeFunction(timePassed, startVal, targetVal - startVal, duration);
                }
            }
            return false;
        }
        else
        {
            return true;
        }
    }
}
