namespace NetmarbleS.Internal
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System;

    public static class DicExtension
    {
        public static string GetString(this IDictionary data, string key)
        {
            if (data.Contains(key))
            {
                return data[key].ToString();
            }
            else
            {
                Debug.Log("key not found : " + key);
                return null;
            }
        }

        public static int GetInt(this IDictionary data, string key)
        {
            if (data.Contains(key))
            {
                return Convert.ToInt32(data[key].ToString());
            }
            else
            {
                Debug.Log("key not found : " + key);
                return 0;
            }
        }

        public static bool GetBool(this IDictionary data, string key)
        {
            if (data.Contains(key))
            {
                return Convert.ToBoolean(data[key].ToString());
            }
            else
            {
                Debug.Log("key not found : " + key);
                return false;
            }
        }
    }
}