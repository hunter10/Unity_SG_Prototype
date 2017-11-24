namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface IUtil
    {
        string GetTimeZone();
        string GetNMDeviceKey();
        string GetPlatformADID();
    }
}