namespace NetmarbleS.Internal
{
    using UnityEngine;
    using System.Collections;

    public class Utils
    {

        public static string ToJson(object obj)
        {
            if (null == obj)
                return null;
            else
                return LitJson.JsonMapper.ToJson(obj);
        }
    }
}