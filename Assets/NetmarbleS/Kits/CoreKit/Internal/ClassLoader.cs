namespace NetmarbleS.Internal
{
    using UnityEngine;
    using System;
    using System.Collections;

    public class ClassLoader
    {
        private const string netmarbleS_NS = "NetmarbleS";
        public static object GetTargetClass(string baseName)
        {
            string platformName;

            if (RuntimePlatform.OSXEditor == Application.platform || RuntimePlatform.WindowsEditor == Application.platform)
            {                
                platformName = "Editor";
            }
            else if (RuntimePlatform.Android == Application.platform)
            {
                platformName = "Android";
            }
            else if (RuntimePlatform.IPhonePlayer == Application.platform)
            {
                platformName = "iOS";
            }
            else
            {
                platformName = Enum.GetName(typeof(RuntimePlatform), Application.platform);
            }

            string className = netmarbleS_NS + "." + baseName + platformName;
            Type type = Type.GetType(className);

            if (null != type)
            {
                return Activator.CreateInstance(type);
            }
            else
            {
                Debug.LogWarning("[ClassLoader] Not supported platform");

                 className = netmarbleS_NS + "." + baseName + "Platform";
                 type = Type.GetType(className);
                 if (null != type)
                     return Activator.CreateInstance(type);
                 else
                     return null;
                 
            }
        }

        public static bool ContainsKit(string className)
        {

#if UNITY_ANDROID
            AndroidJavaClass utils = new AndroidJavaClass("com.netmarble.unity.NMGUnityPlayer");
            return utils.CallStatic<bool>("containsKit", className);
#else
			return false;
#endif
        }
    }
}
