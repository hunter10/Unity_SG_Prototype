namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class TermsOfService
    {
        public static int TERMS_OF_SERVICE
        {
            get
            {
                return TermsOfServiceImpl.TERMS_OF_SERVICE;
            }
        }

        public static int LOCATION_INFO
        {
            get
            {
                return TermsOfServiceImpl.LOCATION_INFO;
            }
        }

        private static readonly string VERSION = "1.1.0.4000";
        private static TermsOfServiceBase termsOfService;
        private static TermsOfServiceBase TermsOfServiceImpl
        {
            get
            {
                if (null == termsOfService)
                {
                    termsOfService = Internal.ClassLoader.GetTargetClass("TermsOfService") as TermsOfServiceBase;
                    Log.Debug("[TermsOfService] NMGUnity Version : " + VERSION + "(" + termsOfService.VERSION + ")");
                }
                return termsOfService;
            }
        }
    }
    public abstract class TermsOfServiceBase
    {
        public string VERSION;
        public int TERMS_OF_SERVICE;
        public int LOCATION_INFO;

    }
    public class TermsOfServicePlatform : TermsOfServiceBase
    {

        public TermsOfServicePlatform()
        {
            VERSION = "0.0.0.0000";
            TERMS_OF_SERVICE = 0;
            LOCATION_INFO = 0;
        }
    }

#if UNITY_ANDROID
    public class TermsOfServiceAndroid : TermsOfServiceBase
    {
        private AndroidJavaClass termsOfServiceClass;
        private readonly string javaClassName = "com.netmarble.uiview.TermsOfService";

        public TermsOfServiceAndroid()
        {
            if (Internal.ClassLoader.ContainsKit(javaClassName))
            {
                termsOfServiceClass = new AndroidJavaClass(javaClassName);
                VERSION = "1.1.0.4000";
                TERMS_OF_SERVICE = termsOfServiceClass.GetStatic<int>("TERMS_OF_SERVICE");
                LOCATION_INFO = termsOfServiceClass.GetStatic<int>("LOCATION_INFO");
            }
            else
            {
                Log.Warning("[TermsOfServiceAndroid] Android TermsOfServiceKit is not included");
            }

        }
    }
#endif

#if UNITY_IPHONE || UNITY_IOS
    public class TermsOfServiceiOS : TermsOfServiceBase
    {
        [DllImport("__Internal")]
        public static extern IntPtr nmg_tos_version();
        [DllImport("__Internal")] 
        public static extern int nmg_tos_getLocation();
        [DllImport("__Internal")] 
        public static extern int nmg_tos_getLocationLBS();

        public TermsOfServiceiOS()
        {
            VERSION = Marshal.PtrToStringAuto(nmg_tos_version());
            TERMS_OF_SERVICE = nmg_tos_getLocation();
            LOCATION_INFO = nmg_tos_getLocationLBS();
        }
    }

#endif
}
