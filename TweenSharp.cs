using System.Collections.Generic;
using System.Reflection;
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

    public TweenSharp(object target, float duration, Dictionary<string, object> args)
    {
        float f = 0;
        this.target = target;
        this.duration = duration;

        propertyKeys = new List<string>();
        propertyStartValues = new List<float>();
        propertyTargetValues = new List<float>();

        foreach (KeyValuePair<string, object> kvp in args)
        {
            string key = kvp.Key;
            propertyKeys.Add(key);
            Debug.Log(key + ": " + PluginManager.GetPlugin(key));
            if (kvp.Value is float)
            {
                propertyStartValues.Add(0f);
                propertyTargetValues.Add((float) kvp.Value);
            }
        }

        PropertyInfo[] propertyInfos = target.GetType().GetProperties();
        foreach (PropertyInfo pi in propertyInfos)
        {
            int ind = propertyKeys.IndexOf(pi.Name);
            if (ind != -1)
            {

            }
//            pi.SetValue(planet1, "qwe", null);

        }
    }
}
