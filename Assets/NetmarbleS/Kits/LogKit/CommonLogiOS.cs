#if UNITY_IPHONE || UNITY_IOS
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace NetmarbleS
{
    public class CommonLogiOS : ICommonLog
    {
        [DllImport("__Internal")]
        public static extern IntPtr nmg_commonLog_version();
        [DllImport("__Internal")]
        public static extern void nmg_commonLog_setCommonLogUpdateEventDelegate(int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_commonLog_getElements(int handlerNum);

        private CommonLogCallback commonLogCallback;
        private string version;
        public CommonLogiOS()
        {
            commonLogCallback = new CommonLogCallback();
            version = Marshal.PtrToStringAuto(nmg_commonLog_version());
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public void SetCommonLogUpdateEventDelegate(CommonLog.UpdateEventDelegate callback)
        {
            int handlerNum = commonLogCallback.SetCommonLogUpdateEventCallback(callback);
            nmg_commonLog_setCommonLogUpdateEventDelegate(handlerNum);
        }

        public void GetElements(CommonLog.ElementsDelegate callback)
        {
            int handlerNum = commonLogCallback.SetElementsCallback(callback);
            nmg_commonLog_getElements(handlerNum);
        }
    }
}
#endif