namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class SelfCertification
    {
        public static int SELF_CERTIFICATION
        {
            get
            {
				return SelfCertificationImpl.SELF_CERTIFICATION;
            }
        }

        private static readonly string VERSION = "1.0.1.4000";
		private static SelfCertificationBase selfCertification;
		private static SelfCertificationBase SelfCertificationImpl
        {
            get
            {
				if (null == selfCertification)
                {
					selfCertification = Internal.ClassLoader.GetTargetClass("SelfCertification") as SelfCertificationBase;
					Log.Debug("[SelfCertification] NMGUnity Version : " + VERSION + "(" + selfCertification.VERSION + ")");
                }
				return selfCertification;
            }
        }
    }
	public abstract class SelfCertificationBase
    {
        public string VERSION;
		public int SELF_CERTIFICATION;
    }
	public class SelfCertificationPlatform : SelfCertificationBase
    {

		public SelfCertificationPlatform()
        {
            VERSION = "0.0.0.0000";
			SELF_CERTIFICATION = 0;
        }
    }

#if UNITY_ANDROID
	public class SelfCertificationAndroid : SelfCertificationBase
    {
        private AndroidJavaClass selfCertificationClass;
		private readonly string javaClassName = "com.netmarble.uiview.SelfCertification";

		public SelfCertificationAndroid()
        {
            if (Internal.ClassLoader.ContainsKit(javaClassName))
            {
				selfCertificationClass = new AndroidJavaClass(javaClassName);
                VERSION = "1.0.0.4000";
				SELF_CERTIFICATION = selfCertificationClass.GetStatic<int>("SELF_CERTIFICATION");
            }
            else
            {
				Log.Warning("[SelfCertificationAndroid] Android SelfCertificationKit is not included");
            }

        }
    }
#endif

#if UNITY_IPHONE || UNITY_IOS
	public class SelfCertificationiOS : SelfCertificationBase
    {
        [DllImport("__Internal")]
		public static extern IntPtr nmg_selfCertification_version();
        [DllImport("__Internal")] 
		public static extern int nmg_selfCertification_getLocation();

		public SelfCertificationiOS()
        {
			VERSION = Marshal.PtrToStringAuto(nmg_selfCertification_version());
			SELF_CERTIFICATION = nmg_selfCertification_getLocation();
        }
    }

#endif
}
