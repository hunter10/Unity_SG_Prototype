#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class AppEventsAndroid : IAppEvents
    {
        private AndroidJavaClass appEventsAndroidClass;
        private AppEventsCallback appEventsCallback;

        public AppEventsAndroid()
        {
            appEventsAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGAppEventsUnity");
            appEventsCallback = new AppEventsCallback();
        }

        public void SetDeepLinkDelegate(AppEvents.DeepLinkDelegate callback)
        {
            int handlerNum = appEventsCallback.SetDeepLinkCallback(callback);
            appEventsAndroidClass.CallStatic("nmg_appEvents_setDeepLinkDelegate", handlerNum);
        }

        public void SetRewardDelegate(AppEvents.RewardDelegate callback)
        {
            int handlerNum = appEventsCallback.SetRewardCallback(callback);
            appEventsAndroidClass.CallStatic("nmg_appEvents_setRewardDelegate", handlerNum);
        }
    }
}
#endif