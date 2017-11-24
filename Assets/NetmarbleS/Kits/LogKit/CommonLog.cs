using UnityEngine;
using System.Collections;

namespace NetmarbleS
{

    public class CommonLog
    {
        public delegate void UpdateEventDelegate();
        public delegate void ElementsDelegate(string elements);

        public static void SetCommonLogUpdateEventDelegate(UpdateEventDelegate callback)
        {
            Log.Debug("[CommonLog] SetCommonLogUpdateEventDelegate");
            commonLogImpl.SetCommonLogUpdateEventDelegate(callback);
        }

        public static void GetElements(ElementsDelegate callback)
        {
            Log.Debug("[CommonLog] GetElements");
            commonLogImpl.GetElements(callback);
        }

        private static readonly string VERSION = "1.0.0.4000";
        private static ICommonLog commonLog;
        private static ICommonLog commonLogImpl
        {
            get
            {
                if (null == commonLog)
                {
                    commonLog = NetmarbleS.Internal.ClassLoader.GetTargetClass("CommonLog") as ICommonLog;
                    Log.Debug("[CommonLog] NMGUnity Version : " + VERSION + "(" + commonLog.VERSION + ")");
                }
                return commonLog;
            }
        }
    }
}