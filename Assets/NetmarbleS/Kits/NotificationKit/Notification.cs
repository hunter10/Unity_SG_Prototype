using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NetmarbleS
{
    public class Notification
    {
        public static int GetNewNotificationCount(string serviceCode)
        {
            Log.Debug("[Notification] GetNewNotificationCount");
            return NotificationImpl.GetNewNotificationCount(serviceCode);
        }

        private static readonly string VERSION = "1.0.0.4100";
        private static INotification notification;
        private static INotification NotificationImpl
        {
            get
            {
                if (null == notification)
                {
                    notification = NetmarbleS.Internal.ClassLoader.GetTargetClass("Notification") as INotification;
                    Log.Debug("[Notification] NMGUnity Version : " + VERSION + "(" + notification.VERSION + ")");
                }
                return notification;
            }

        }
    }
}