using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;

namespace TS
{
    public class TSKeywordParser
    {
        private static Dictionary<string, Action<TweenSharp, object>> keywordTable;
        private static TSKeywordFunctions keywordFunctions;

        public static void Init()
        {
            keywordTable = new Dictionary<string, Action<TweenSharp, object>>();
            keywordFunctions = new TSKeywordFunctions();
            keywordTable["delay"] = keywordFunctions.Delay;
        }


        public static bool Parse(TweenSharp tween, KeyValuePair<string,object> kvp) {

            string key = kvp.Key;
            if (keywordTable.ContainsKey(key))
            {
                keywordTable[key](tween, kvp.Value);
                return true;
            }
            return false;
        }
    }
}