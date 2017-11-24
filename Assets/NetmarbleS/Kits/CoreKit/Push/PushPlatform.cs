namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class PushPlatform : IPush
    {
        public void SendPushNotification(string message, System.Collections.Generic.List<string> playerIdList, Push.SendPushNotificationDelegate callback)
        {
           
        }

        public void SendPushNotification(string message, int notificationId, System.Collections.Generic.List<string> playerIdList, Push.SendPushNotificationDelegate callback)
        {
           
        }

        public void SetUseLocalPushNotification(bool use, int notificationId, Push.SetUsePushNotificationDelegate callback)
        {
           
        }

        public void GetUseLocalPushNotificationList(Push.GetUsePushNotificationDelegate callback)
        {
           
        }

        public int SetLocalNotification(int sec, string message, int notificationId, string soundFileName, System.Collections.Generic.Dictionary<string, object> extras)
        {
            return 0;
        }

        public bool CancelLocalNotification(int localPushId)
        {
            return false;
        }

        public void DeleteAllNotification()
        {
           
        }

        public void SetAllowPushNotification(AllowPushNotification notice, AllowPushNotification game, AllowPushNotification nightNotice, Push.SetAllowPushNotificationDelegate callback)
        {
           
        }

        public void GetAllowPushNotification(Push.GetAllowPushNotificationDelegate callback)
        {
           
        }

        public void SetWorldsAllowPushNotification(System.Collections.Generic.List<WorldAllowPushNotification> worldAllowPushNotificationList, Push.SetWorldsAllowPushNotificationDelegate callback)
        {
           
        }

        public void GetWorldsAllowPushNotification(Push.GetWorldsAllowPushNotificationDelegate callback)
        {
           
        }
    }
}