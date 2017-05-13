using System.Collections.Generic;
using System.Reflection;
using TS;
using TS.Plugins;
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

    public TweenSharp(object target, float duration, Dictionary<string, object> args)
    {
        float f = 0;
        this.target = target;
        this.duration = duration;

        propertyKeys = new List<string>();
        propertyStartValues = new List<float>();
        propertyTargetValues = new List<float>();
        propertyPlugins = new List<TSPlugin>();

        foreach (KeyValuePair<string, object> kvp in args)
        {
            string key = kvp.Key;
            propertyKeys.Add(key);

            TSPlugin plugin = PluginManager.GetPlugin(key);
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

    }
}
