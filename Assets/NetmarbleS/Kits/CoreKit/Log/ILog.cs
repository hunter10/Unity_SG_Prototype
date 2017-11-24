namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public interface ILog
    {
        void SendGameLog(int logId, int detailId, string pcSeq, Dictionary<string, object> logDataDic);
    }
}