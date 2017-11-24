#if UNITY_ANDROID
using UnityEngine;
using System.Collections;

namespace NetmarbleS
{
    public class NotificationAndroid : INotification
    {
        private AndroidJavaClass notificationJavaClass;
        private string version;

        public NotificationAndroid()
        {
            notificationJavaClass = new AndroidJavaClass("com.netmarble.unity.NMGNotificationUnity");
            version = notificationJavaClass.GetStatic<string>("VERSION");
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }
        public int GetNewNotificationCount(string serviceCode)
        {
            return notificationJavaClass.CallStatic<int>("nmg_notification_getNewNotificationCount", serviceCode);
        }
    }
}
#endif