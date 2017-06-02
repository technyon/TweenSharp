using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class TSHelper
{
    public static Dictionary<string, object> ToDictionary(this object obj)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();

        foreach (PropertyInfo pi in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            string key = pi.Name;
            object value = pi.GetValue(obj, null);

            result.Add(key, value);
        }

        return result;
    }
}
