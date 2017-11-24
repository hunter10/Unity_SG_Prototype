#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

    public class PushiOS : IPush
    {
		[DllImport("__Internal")] 
		public static extern void nmg_push_sendPushNotification(string message, string jsonPlayerIdArray, int handlerNum);
		[DllImport("__Internal")] 
		public static extern int nmg_push_setLocalNotification(int sec, string message, int notificationId, string soundFileName, string jsonExtras);
		[DllImport("__Internal")] 
		public static extern bool nmg_push_cancelLocalNotification(int localPushId);
		[DllImport("__Internal")] 
		public static extern bool nmg_push_setAllowPushNotification(int notice, int game, int nightNotice, int handlerNum);
		[DllImport("__Internal")] 
		public static extern bool nmg_push_getAllowPushNotification(int handlerNum);
		[DllImport("__Internal")] 
		public static extern void nmg_push_setWorldsAllowPushNotification(string jsonWorldAllows, int handlerNum);
		[DllImport("__Internal")] 
		public static extern void nmg_push_getWorldsAllowPushNotification(int handlerNum);

        private PushCallback pushCallback;
		public PushiOS()
        {
            pushCallback = new PushCallback();
        }

        public void SendPushNotification(string message, List<string> playerIdList, Push.SendPushNotificationDelegate callback)
        {
            string playerIdJson = Internal.Utils.ToJson(playerIdList);
            int handlerNum = pushCallback.SetSendPushNotificationCallback(callback);
			nmg_push_sendPushNotification(message, playerIdJson, handlerNum);
        }

        public void SendPushNotification(string message, int notificationId, List<string> playerIdList, Push.SendPushNotificationDelegate callback)
        {
            string playerIdJson = Internal.Utils.ToJson(playerIdList);
            int handlerNum = pushCallback.SetSendPushNotificationCallback(callback);
			nmg_push_sendPushNotification(message, playerIdJson, handlerNum);
        }

        public void SetUseLocalPushNotification(bool use, int notificationId, Push.SetUsePushNotificationDelegate callback)
        {
            Log.Debug("[PushiOS] not supported API");
            if (null != callback)
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.NOT_SUPPORTED, "Not supported API");
                callback(result);
            }
        }

        public void GetUseLocalPushNotificationList(Push.GetUsePushNotificationDelegate callback)
        {
            Log.Debug("[PushiOS] not supported API");
            if (null != callback)
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.NOT_SUPPORTED, "Not supported API");
                callback(result, true);
            }
        }

        public int SetLocalNotification(int sec, string message, int notificationId, string soundFileName, Dictionary<string, object> extras)
        {
            string extrasJson = Internal.Utils.ToJson(extras);
			return nmg_push_setLocalNotification(sec, message, notificationId, soundFileName, extrasJson);
        }

        public bool CancelLocalNotification(int localPushId)
        {
			return nmg_push_cancelLocalNotification(localPushId);
        }

        public void DeleteAllNotification()
        {
            Log.Debug("[PushiOS] not supported API");
        }

        public void SetAllowPushNotification(AllowPushNotification notice, AllowPushNotification game, AllowPushNotification nightNotice, Push.SetAllowPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetSetAllowPushNotificationCallback(callback);
			nmg_push_setAllowPushNotification((int)notice, (int)game, (int)nightNotice, handlerNum);
        }

        public void GetAllowPushNotification(Push.GetAllowPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetGetAllowPushNotificationCallback(callback);
			nmg_push_getAllowPushNotification(handlerNum);
        }

        public void SetWorldsAllowPushNotification(List<WorldAllowPushNotification> worldAllowPushNotificationList, Push.SetWorldsAllowPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetSetWorldsAllowPushNotificationCallback(callback);
            string worldAllowPushNotificationJson = Internal.Utils.ToJson(worldAllowPushNotificationList);
			nmg_push_setWorldsAllowPushNotification(worldAllowPushNotificationJson, handlerNum);
        }

        public void GetWorldsAllowPushNotification(Push.GetWorldsAllowPushNotificationDelegate callback)
        {
            int handlerNum = pushCallback.SetGetWorldsAllowPushNotificationCallback(callback);
			nmg_push_getWorldsAllowPushNotification(handlerNum);
        }
    }
}
#endif