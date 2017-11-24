#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

    public class LogiOS : ILog
    {
		[DllImport("__Internal")] 
		public static extern void nmg_log_sendGameLog(int logId, int detailId, string pcSeq, string jsonLogDataDic);

        public void SendGameLog(int logId, int detailId, string pcSeq, Dictionary<string, object> logDataDic)
        {
            string logDataJson = Internal.Utils.ToJson(logDataDic);
            nmg_log_sendGameLog(logId, detailId, pcSeq, logDataJson);
        }
    }
}
#endif