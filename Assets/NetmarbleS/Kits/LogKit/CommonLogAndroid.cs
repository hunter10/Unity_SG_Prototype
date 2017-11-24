#if UNITY_ANDROID
using UnityEngine;
using System.Collections;

namespace NetmarbleS
{

    public class CommonLogAndroid : ICommonLog
    {
        private AndroidJavaClass commonLogClass;
        private CommonLogCallback commonLogCallback;
        private string version;

        public CommonLogAndroid()
        {
            commonLogClass = new AndroidJavaClass("com.netmarble.unity.log.NMGLogUnity");
            commonLogCallback = new CommonLogCallback();
            version = commonLogClass.GetStatic<string>("VERSION");
        }

        public string VERSION
        {
            get { return version; }
        }

        public void SetCommonLogUpdateEventDelegate(CommonLog.UpdateEventDelegate callback)
        {
            int handlerNum = commonLogCallback.SetCommonLogUpdateEventCallback(callback);
            commonLogClass.CallStatic("nmg_commonLog_setCommonLogUpdateEventDelegate", handlerNum);
        }

        public void GetElements(CommonLog.ElementsDelegate callback)
        {
            int handlerNum = commonLogCallback.SetElementsCallback(callback);
            commonLogClass.CallStatic("nmg_commonLog_getElements", handlerNum);
        }
    }
}
#endif