#if UNITY_IPHONE || UNITY_IOS
using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace NetmarbleS
{
    public class NotificationiOS : INotification
    {
        [DllImport("__Internal")]
        public static extern IntPtr nmg_notification_version();
        [DllImport("__Internal")]
        public static extern int nmg_notification_getNewNotificationCount(string serviceCode);

        private string version;
        public NotificationiOS()
        {
            version = Marshal.PtrToStringAuto(nmg_notification_version());
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
            return nmg_notification_getNewNotificationCount(serviceCode);
        }
    }
}
#endif