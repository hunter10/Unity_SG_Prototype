namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class UsePush
    {
        private int notificationId;
        private bool isUse;

        public UsePush()
        {
            this.notificationId = 0;
            this.isUse = true;
        }

        public UsePush(int notificationId, bool isUse)
        {

            this.notificationId = notificationId;
            this.isUse = isUse;
        }

        public override string ToString()
        {
            return "[UsePush] notificationId(" + notificationId + "), isUse(" + isUse + ")";
        }
        /**
         * @brief Gets notification Id.
         * 
         * @return notification Id.
         */
        public int NotificationID
        {
            get
            {
                return notificationId;
            }
        }
        /**
         * @brief Gets whether use push.
         * 
         * @return Use of push setting either 'true' or 'false'.
         */
        public bool IsUse
        {
            get
            {
                return isUse;
            }
        }
    }
    public enum AllowPushNotification
    {
        None = 0,
        On,
        Off
    }
    public class WorldAllowPushNotification
    {
        private string worldId;
        private AllowPushNotification notice;
        private AllowPushNotification game;
        private AllowPushNotification nightNotice;

        public WorldAllowPushNotification(string worldId, AllowPushNotification notice, AllowPushNotification game, AllowPushNotification nightNotice)
        {
            this.worldId = worldId;
            this.notice = notice;
            this.game = game;
            this.nightNotice = nightNotice;
        }

        public override string ToString()
        {
            return "[WorldAllowPushNotification] worldId(" + worldId + "), notice(" + notice + "), game(" + game + "), nightNotice(" + nightNotice + ")";
        }

        public string WorldID
        {
            get
            {
                return worldId;
            }
            set
            {
                worldId = value;
            }
        }

        public AllowPushNotification Notice
        {
            get
            {
                return notice;
            }
            set
            {
                notice = value;
            }
        }

        public AllowPushNotification Game
        {
            get
            {
                return game;
            }
            set
            {
                game = value;
            }
        }

        public AllowPushNotification NightNotice
        {
            get
            {
                return nightNotice;
            }
            set
            {
                nightNotice = value;
            }
        }
    }
    public class Push
    {

        /**
         * @brief SendPushNotification callback delegate.
         * 
         * @param result Reuslt.
         * @see Result
         */
        public delegate void SendPushNotificationDelegate(Result result);

        /**
         * @brief SetUsePushNotification callback delegate.
         * 
         * @param result Reuslt.
         * @see Result
         */
        public delegate void SetUsePushNotificationDelegate(Result result);

        /**
         * @brief GetUsePushNotification callback delegate.
         * 
         * @param result Reuslt.
         * @param use Use of push notification.
         * @see Result
         */
        public delegate void GetUsePushNotificationDelegate(Result result, bool use);

        public delegate void SetAllowPushNotificationDelegate(Result result);

        public delegate void GetAllowPushNotificationDelegate(Result result, AllowPushNotification notice, AllowPushNotification game, AllowPushNotification nightNotice);

        public delegate void SetWorldsAllowPushNotificationDelegate(Result result);

        public delegate void GetWorldsAllowPushNotificationDelegate(Result result, List<WorldAllowPushNotification> worldAllowPushNotificationList);

        /**
         * @brief Sends a push message to other users.
         *
         * @param message Push message.
         * @param playerIdList Player Id list.
         * @param callback Callback to deal with a response to the request.
         * @see SendPushNotificationDelegate
         */
        public static void SendPushNotification(string message, List<string> playerIdList, SendPushNotificationDelegate callback)
        {
            Log.Debug("[Push] SendPushNotification message:" + message);
            PushImpl.SendPushNotification(message, playerIdList, callback);
        }

        /**
         * @brief Sends a push message to other users.
         * @param message Push message.
         * @param notificationId bigger than 0.
         * @param playerIdList Player Id list.
         * @param callback Callback to deal with a response to the request.
         * @see SendPushNotificationDelegate
         */
        public static void SendPushNotification(string message, int notificationId, List<string> playerIdList, SendPushNotificationDelegate callback)
        {
            Log.Debug("[Push] SendPushNotification message:" + message + " , notificationId : " + notificationId);
            PushImpl.SendPushNotification(message, notificationId, playerIdList, callback);
        }

        public static void SetUseLocalPushNotification(bool use, int notificationId, SetUsePushNotificationDelegate callback)
        {
            Log.Debug("[Push] SetUseLocalPushNotification use:" + use + " , notificationId : " + notificationId);
            PushImpl.SetUseLocalPushNotification(use, notificationId, callback);
        }
        public static void GetUseLocalPushNotificationList(GetUsePushNotificationDelegate callback)
        {
            Log.Debug("[Push] GetUseLocalPushNotificationList");
            PushImpl.GetUseLocalPushNotificationList(callback);
        }

        /**
        * @brief Send a push message to me.
        * 
        * @param sec bigger than 0.
        * @param message Push message. ex) Hello NetmarbleS.
        * @param notificationId bigger than 0.
        * @param soundFileName Push sound file name. ex)netmarble.mp3
        * @param extras extras
        * @return localPushId
        */
        public static int SetLocalNotification(int sec, string message, int notificationId, string soundFileName, Dictionary<string, object> extras)
        {
            Log.Debug("[Push] SetLocalNotification");
            return PushImpl.SetLocalNotification(sec, message, notificationId, soundFileName, extras);
        }

        /**
         * @brief Cancels the local notification that already set to be deliverd.
         * 
         * @param localPushId Local push Id to be canceled.
         * @return If success to cancel the local notification returns true, else returns false.
         */
        public static bool CancelLocalNotification(int localPushId)
        {
            Log.Debug("[Push] CancelLocalNotification");
            return PushImpl.CancelLocalNotification(localPushId);
        }

        public static void DeleteAllNotification()
        {
            Log.Debug("[Push] DeleteAllNotification");
            PushImpl.DeleteAllNotification();
        }

        /**
         * @brief 공지, 게임, 야간공지의 푸시 ON/OFF를 할 수 있습니다.
         * 
         * @param notice AllowPushNotification
         * @param game AllowPushNotification
         * @param nightNotice AllowPushNotification
         * @param callback SetAllowPushNotificationListener to deal with a response to the request.
         * @see SetAllowPushNotificationDelegate
         */
        public static void SetAllowPushNotification(AllowPushNotification notice, AllowPushNotification game, AllowPushNotification nightNotice, SetAllowPushNotificationDelegate callback)
        {
            Log.Debug("[Push] SetAllowPushNotification " + " notice : " + notice + " game : " + game + " nightNotice : " + nightNotice);
            PushImpl.SetAllowPushNotification(notice, game, nightNotice, callback);
        }

        /**
         * @brief 공지, 게임, 야간공지의 푸시 ON/OFF 여부를 알 수 있습니다.
         * 
         * @param callback SetAllowPushNotificationListener to deal with a response to the request.
         * @see GetAllowPushNotificationDelegate
         */
        public static void GetAllowPushNotification(GetAllowPushNotificationDelegate callback)
        {
            Log.Debug("[Push] GetAllowPushNotification");
            PushImpl.GetAllowPushNotification(callback);
        }

        /**
         * @brief 월드별 공지, 게임, 야간공지의 푸시 ON/OFF 설정을 할 수 있습니다.
         *
         * @param worldAllowPushNotificationList WorldAllowPushNotification List.
         * @param callback SetWorldsAllowPushNotificationDelegate to deal with a response to the request.
         *
         * @see Result
         * @see WorldAllowPushNotification
         */
        public static void SetWorldsAllowPushNotification(List<WorldAllowPushNotification> worldAllowPushNotificationList, SetWorldsAllowPushNotificationDelegate callback)
        {
            Log.Debug("[Push] setWorldsAllowPushNotification");
            PushImpl.SetWorldsAllowPushNotification(worldAllowPushNotificationList, callback);
        }

        /**
         * @brief 월드별 공지, 게임, 야간공지의 푸시 ON/OFF 여부를 알 수 있습니다.
         *
         * @param callback GetWorldsAllowPushNotificationDelegate to deal with a response to the request.
         *
         * @see Result
         * @see WorldAllowPushNotification
         */
        public static void GetWorldsAllowPushNotification(GetWorldsAllowPushNotificationDelegate callback)
        {
            Log.Debug("[Push] getWorldsAllowPushNotification");
            PushImpl.GetWorldsAllowPushNotification(callback);
        }

        private static IPush push;
        private static IPush PushImpl
        {
            get
            {
                if(null == push)
                {
                    push = Internal.ClassLoader.GetTargetClass("Push") as IPush;
                }
                return push;
            }
        }
    }
}