namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public interface IPush
    {
        void SendPushNotification(string message, List<string> playerIdList, Push.SendPushNotificationDelegate callback);
        void SendPushNotification(string message, int notificationId, List<string> playerIdList, Push.SendPushNotificationDelegate callback);
        void SetUseLocalPushNotification(bool use, int notificationId, Push.SetUsePushNotificationDelegate callback);
        void GetUseLocalPushNotificationList(Push.GetUsePushNotificationDelegate callback);
        int SetLocalNotification(int sec, string message, int notificationId, string soundFileName, Dictionary<string, object> extras);
        bool CancelLocalNotification(int localPushId);
        void DeleteAllNotification();
        void SetAllowPushNotification(AllowPushNotification notice, AllowPushNotification game, AllowPushNotification nightNotice, Push.SetAllowPushNotificationDelegate callback);
        void GetAllowPushNotification(Push.GetAllowPushNotificationDelegate callback);
        void SetWorldsAllowPushNotification(List<WorldAllowPushNotification> worldAllowPushNotificationList, Push.SetWorldsAllowPushNotificationDelegate callback);
        void GetWorldsAllowPushNotification(Push.GetWorldsAllowPushNotificationDelegate callback);
    }

}