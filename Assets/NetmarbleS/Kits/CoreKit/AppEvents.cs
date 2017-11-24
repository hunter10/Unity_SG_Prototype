namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;

    public class AppEvents
    {
        public delegate void DeepLinkDelegate(Uri uri);

        public delegate void RewardDelegate();

        public static void SetDeepLinkDelegate(DeepLinkDelegate callback)
        {
            Log.Debug("[AppEvents] SetDeepLinkDelegate");
            AppEventsImpl.SetDeepLinkDelegate(callback);
        }

        public static void SetRewardDelegate(RewardDelegate callback)
        {
            Log.Debug("[AppEvents] SetRewardDelegate");
            AppEventsImpl.SetRewardDelegate(callback);
        }

        private static IAppEvents appEvents;
        private static IAppEvents AppEventsImpl
        {
            get
            {
                if(null == appEvents)
                {
                    appEvents = Internal.ClassLoader.GetTargetClass("AppEvents") as IAppEvents;
                }
                return appEvents;
            }
        }
    }
}