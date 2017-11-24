using UnityEngine;
using System.Collections;

namespace NetmarbleS
{
    public class CommonLogPlatform : ICommonLog
    {
        public string VERSION
        {
            get { return "0.0.0.0000"; }
        }
        public void SetCommonLogUpdateEventDelegate(CommonLog.UpdateEventDelegate callback)
        {
        }

        public void GetElements(CommonLog.ElementsDelegate callback)
        {
        }
    }
}