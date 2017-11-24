namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using NetmarbleS.Internal;

    public class AppEventsCallback
    {
        public int SetDeepLinkCallback(AppEvents.DeepLinkDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[AppEventsCallback] DeepLinkCallback: " + message.ToString());

                string uriString = message.GetString("uri");
                
                System.Uri uri = null;
                if (null != uriString && uriString.Length > 0)
                {
                    uri = new System.Uri(uriString);
                }

                if (null != callback)
                    callback(uri);
            });

            return handlerNum;
               
        }

        public int SetRewardCallback(AppEvents.RewardDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[AppEventsCallback] RewardCallback: " + message.ToString());

                if (null != callback)
                    callback();
            });

            return handlerNum;
        }
    }
}