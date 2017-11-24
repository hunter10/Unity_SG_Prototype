#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class LogAndroid : ILog
    {
        public AndroidJavaClass logAndroidClass;

        public LogAndroid()
        {
            logAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGLogUnity");
        }

        public void SendGameLog(int logId, int detailId, string pcSeq, Dictionary<string, object> logDataDic)
        {
            string logDataJson = Internal.Utils.ToJson(logDataDic);
            logAndroidClass.CallStatic("nmg_log_sendGameLog", logId, detailId, pcSeq, logDataJson);
        }
    }
}
#endif