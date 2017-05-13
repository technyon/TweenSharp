using System.Collections.Generic;
using System.Reflection;
using TS;
using UnityEngine;

public class TweenSharp
{
    private Dictionary<string, float> properties;

    private object target;
    private float duration;

    private List<string> propertyKeys;
    private List<float> propertyStartValues;
    private List<float> propertyTargetValues;
    private List<TSPlugin> propertyPlugins;

    private float startTime;
    private TSEase.EaseFunction easeFunction = TSEase.Linear;

    public TweenSharp(object target, float duration, Dictionary<string, object> args)
    {
        float f = 0;
        this.target = target;
        this.duration = duration;

        startTime = Time.realtimeSinceStartup;

        propertyKeys = new List<string>();
        propertyStartValues = new List<float>();
        propertyTargetValues = new List<float>();
        propertyPlugins = new List<TSPlugin>();

        foreach (KeyValuePair<string, object> kvp in args)
        {
            string key = kvp.Key;
            propertyKeys.Add(key);

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

            PropertyInfo[] propertyInfos = target.GetType().GetProperties();
            foreach (PropertyInfo pi in propertyInfos)
            {
                int ind = propertyKeys.IndexOf(pi.Name);
                if (ind != -1 && propertyPlugins[ind] == null)
                {
                    object val = pi.GetValue(target, null);
                    if (val is float)
                    {
                        propertyStartValues[ind] = (float) val;
                    }
                }
            }
        }
        TSScheduler.Register(this);
    }

    public void Update(float time)
    {
        int len = propertyKeys.Count;

        float timePassed = time - startTime;

        if (timePassed <= duration)
        {
            for (int i = 0; i < len; i++)
            {
                string propertyName = propertyKeys[i];
                float startVal = propertyStartValues[i];
                float targetVal = propertyTargetValues[i];
                TSPlugin plugin = propertyPlugins[i];


                if (plugin != null)
                {
                    plugin.Value = easeFunction(timePassed, startVal, targetVal - startVal, duration);
                }
            }
        }
        else
        {
            TSScheduler.Unregister(this);
        }
    }
}
