#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class UtilAndroid : IUtil
    {
        private AndroidJavaClass utilAndroidClass;
        public UtilAndroid()
        {
            utilAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGUtilUnity");
        }
        public string GetTimeZone()
        {
            return utilAndroidClass.CallStatic<string>("nmg_util_getTimeZone");
        }

        public string GetNMDeviceKey()
        {
            return utilAndroidClass.CallStatic<string>("nmg_util_getNMDeviceKey");
        }

        public string GetPlatformADID()
        {
            Log.Debug("[UtilAndroid] not supported API");
            return null;

        }
    }
}
#endif