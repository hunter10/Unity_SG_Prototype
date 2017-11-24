namespace NetmarbleS.Internal
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class Plugin : ScriptableObject
    {
        public virtual Dictionary<string, object> GetStrings()
        {
            return null;
        }

        public virtual Dictionary<string, object> GetInfoPlists(Dictionary<string, object> dic)
        {
            return dic;
        }
    }
}
