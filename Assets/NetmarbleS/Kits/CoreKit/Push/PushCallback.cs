namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS.Internal;

    public class PushCallback
    {
        public int SetSendPushNotificationCallback(Push.SendPushNotificationDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[PushCallback] SendPushNotificationCallback: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetSetUsePushNotificationCallback(Push.SetUsePushNotificationDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[PushCallback] SetUsePushNotificationCallback: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetGetUsePushNotificationCallback(Push.GetUsePushNotificationDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[PushCallback] GetUsePushNotificationCallback: " + message);

                Result result = message.GetResult();
                bool use = message.GetBool("use");

                if (null != callback)
                    callback(result, use);
            });

            return handlerNum;
        }

        public int SetSetAllowPushNotificationCallback(Push.SetAllowPushNotificationDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[PushCallback] SetAllowPushNotificationCallback: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetGetAllowPushNotificationCallback(Push.GetAllowPushNotificationDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[PushCallback] GetAllowPushNotificationCallback: " + message);

                Result result = message.GetResult();
                int notice = message.GetInt("notice");
                int game = message.GetInt("game");
                int nightNotice = message.GetInt("nightNotice");

                if (null != callback)
                    callback(result, (AllowPushNotification)notice, (AllowPushNotification)game, (AllowPushNotification)nightNotice);
            });

            return handlerNum;
        }

        public int SetSetWorldsAllowPushNotificationCallback (Push.SetWorldsAllowPushNotificationDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[PushCallback] SetWorldsAllowPushNotificationCallback: " + message);

                Result result =  message.GetResult();

                if (null != callback)
                    callback(result);
            });
            
            return handlerNum;

        }

        public int SetGetWorldsAllowPushNotificationCallback(Push.GetWorldsAllowPushNotificationDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[PushCallback] GetWorldsAllowPushNotificationCallback: " + message);

                Result result = message.GetResult();

                List<WorldAllowPushNotification> worldAllowPushNotificationList = null;
                IList worldAllowList = message.GetList("worldAllowPushNotificationList");
                 if (null != worldAllowList)
                 {
                      worldAllowPushNotificationList = new List<WorldAllowPushNotification>();
                       foreach (IDictionary worldAllow in worldAllowList)
                       {
                           string worldId = worldAllow.GetString("worldId");
                           int notice = worldAllow.GetInt("notice");
                           int game = worldAllow.GetInt("game");
                           int nightNotice = worldAllow.GetInt("nightNotice");

                           WorldAllowPushNotification worldAllowPushNotification = new WorldAllowPushNotification(worldId, (AllowPushNotification)notice, (AllowPushNotification)game, (AllowPushNotification)nightNotice);
                           worldAllowPushNotificationList.Add(worldAllowPushNotification);
                       }
                 }
                //List<object> worldAllowList = message.GetList("worldAllowPushNotificationList");
                //if (null != worldAllowList)
                //{
                //    worldAllowPushNotificationList = new List<WorldAllowPushNotification>();
                //    foreach (Dictionary<string, object> worldAllow in worldAllowList)
                //    {
                //        string worldId = System.Convert.ToString(worldAllow.GetValue("worldId"));
                //        int notice = System.Convert.ToInt32(worldAllow.GetValue("notice"));
                //        int game = System.Convert.ToInt32(worldAllow.GetValue("game"));
                //        int nightNotice = System.Convert.ToInt32(worldAllow.GetValue("nightNotice"));

                //        WorldAllowPushNotification worldAllowPushNotification = new WorldAllowPushNotification(worldId, (AllowPushNotification)notice, (AllowPushNotification)game, (AllowPushNotification)nightNotice);
                //        worldAllowPushNotificationList.Add(worldAllowPushNotification);
                //    }
                //}


                if (null != callback)
                    callback(result, worldAllowPushNotificationList);
            });

            return handlerNum;
        }
    }
}