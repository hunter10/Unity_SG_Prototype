#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

    public class UtiliOS : IUtil
    {
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_util_getTimeZone();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_util_getNMDeviceKey();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_util_getPlatformAdId();

        public string GetTimeZone()
        {
			return Marshal.PtrToStringAuto(nmg_util_getTimeZone());
        }

        public string GetNMDeviceKey()
        {
			return Marshal.PtrToStringAuto(nmg_util_getNMDeviceKey());
        }

        public string GetPlatformADID()
        {
			return Marshal.PtrToStringAuto(nmg_util_getPlatformAdId());
        }
    }
}
#endif