#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

    public class AppEventsiOS : IAppEvents
    {
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_appEvents_setDeepLinkDelegate(int handlerNum);
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_appEvents_setRewardDelegate(int handlerNum);

		private AppEventsCallback appEventsCallback;

		public AppEventsiOS()
        {
            appEventsCallback = new AppEventsCallback();
        }

        public void SetDeepLinkDelegate(AppEvents.DeepLinkDelegate callback)
        {
			//TODO : 아래의 코드가 맞는지 체크
            int handlerNum = appEventsCallback.SetDeepLinkCallback(callback);
			nmg_appEvents_setDeepLinkDelegate(handlerNum);
        }

        public void SetRewardDelegate(AppEvents.RewardDelegate callback)
        {
			//TODO : 아래의 코드가 맞는지 체크
            int handlerNum = appEventsCallback.SetRewardCallback(callback);
			nmg_appEvents_setRewardDelegate(handlerNum);
        }
    }
}
#endif