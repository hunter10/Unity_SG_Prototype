namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class Log
    {

        /**
         * @brief Send a game log to log server.
         * 
         * @param logId Log Id.
         * @param detailId Detail Id.
         * @param pcSeq PCSeq.
         * @param logDataDic Log data dictionary.
         */
        public static void SendGameLog(int logId, int detailId, string pcSeq, Dictionary<string, object> logDataDic)
        {
            Log.Debug("[Log] SendGameLog logId:" + logId + ", detailId:" + detailId + ", pcSeq:" + pcSeq + ", logDataDic:" + logDataDic);
            LogImpl.SendGameLog(logId, detailId, pcSeq, logDataDic);
        }


        public static void Error(object message)
        {
            UnityEngine.Debug.LogError(message);
        }

        public static void Warning(object message)
        {
            if (Configuration.GetUseLog() == true)
            {
                UnityEngine.Debug.LogWarning(message);
            }
        }

        /**
        * @brief log message if useLog property in nmconfiguration.xml file set true.
        * 
        * @param message The message you would like logged.
        */
        public static void Debug(object message)
        {
            if (Configuration.GetUseLog() == true)
            {
                UnityEngine.Debug.Log(message);

#if NETMARBLES_UNITY_SAMPLE
                // 샘플용 로그

                string internalLog =  (string)message;

                //if (internalLog.Length > 150)
                //{
                //    internalLog = internalLog.Substring(0, 150);
                //}
                LogManager.Instance.AddInternalLog(internalLog);
#endif
            }
        }

        private static ILog log;
        private static ILog LogImpl
        {
            get
            {
                if(null == log)
                {
                    log = Internal.ClassLoader.GetTargetClass("Log") as ILog;
                }

                return log;
            }
        }
    }
}