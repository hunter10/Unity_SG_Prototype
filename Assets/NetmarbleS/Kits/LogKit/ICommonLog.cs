using UnityEngine;
using System.Collections;

namespace NetmarbleS
{
    public interface ICommonLog
    {
        string VERSION { get; }
        void SetCommonLogUpdateEventDelegate(CommonLog.UpdateEventDelegate callback);
        void GetElements(CommonLog.ElementsDelegate callback);
    }
}