#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class PushAndroid : IPush
    {
        private AndroidJavaClass pushAndroidClass;
        private PushCallback pushCallback;
        public PushAndroid()
        {
            pushAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGPushUnity");
            pushCallback = new PushCallback();
        }
        public void SendPushNotification(string message, List<string> playerIdList, Push.SendPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetSendPushNotificationCallback(callback);
            string playerIdJson = Internal.Utils.ToJson(playerIdList);
            pushAndroidClass.CallStatic("nmg_push_sendPushNotification", message, playerIdJson, handlerNum);
        }

        public void SendPushNotification(string message, int notificationId, List<string> playerIdList, Push.SendPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetSendPushNotificationCallback(callback);
            string playerIdJson = Internal.Utils.ToJson(playerIdList);
            pushAndroidClass.CallStatic("nmg_push_sendPushNotificationWithNotificationId", message, notificationId, playerIdJson, handlerNum);
        }

        public void SetUseLocalPushNotification(bool use, int notificationId, Push.SetUsePushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetSetUsePushNotificationCallback(callback);
            pushAndroidClass.CallStatic("nmg_push_setUseLocalPushNotification", use, notificationId, handlerNum);
        }

        public void GetUseLocalPushNotificationList(Push.GetUsePushNotificationDelegate callback)
        {
            int hanelerNum = pushCallback.SetGetUsePushNotificationCallback(callback);
            pushAndroidClass.CallStatic("nmg_push_getUseLocalPushNotificationList", hanelerNum);
        }

        public int SetLocalNotification(int sec, string message, int notificationId, string soundFileName, Dictionary<string, object> extras)
        {
            string extrasJson = Internal.Utils.ToJson(extras);
            return pushAndroidClass.CallStatic<int>("nmg_push_setLocalNotification", sec, message, notificationId, soundFileName, extrasJson);
        }

        public bool CancelLocalNotification(int localPushId)
        {
            return pushAndroidClass.CallStatic<bool>("nmg_push_cancelLocalNotification", localPushId);
        }

        public void DeleteAllNotification()
        {
            pushAndroidClass.CallStatic("nmg_push_deleteAllNotification");
        }

        public void SetAllowPushNotification(AllowPushNotification notice, AllowPushNotification game, AllowPushNotification nightNotice, Push.SetAllowPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetSetAllowPushNotificationCallback(callback);
            pushAndroidClass.CallStatic("nmg_push_setAllowPushNotification", (int)notice, (int)game, (int)nightNotice, handlerNum);
        }

        public void GetAllowPushNotification(Push.GetAllowPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetGetAllowPushNotificationCallback(callback);
            pushAndroidClass.CallStatic("nmg_push_getAllowPushNotification", handlerNum);
        }

        public void SetWorldsAllowPushNotification(List<WorldAllowPushNotification> worldAllowPushNotificationList, Push.SetWorldsAllowPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetSetWorldsAllowPushNotificationCallback(callback);
            string worldAllowPushNotificationJson = Internal.Utils.ToJson(worldAllowPushNotificationList);
            pushAndroidClass.CallStatic("nmg_push_setWorldsAllowPushNotification", worldAllowPushNotificationJson, handlerNum);
        }

        public void GetWorldsAllowPushNotification(Push.GetWorldsAllowPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetGetWorldsAllowPushNotificationCallback(callback);
            pushAndroidClass.CallStatic("nmg_push_getWorldsAllowPushNotification", handlerNum);
        }
    }
}
#endif