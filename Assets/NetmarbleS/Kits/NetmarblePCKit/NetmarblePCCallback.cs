namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS.Internal;

	public class NetmarblePCCallback
    {

        public int SetAuthenticateCallback(NetmarblePC.AuthenticateDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
				Log.Debug("[NetmarblePCCallback] AuthenticateCalblack: " + message.ToString());

                Result result = message.GetResult();
				string playerID = message.GetString("playerID");
				string publicToken = message.GetString("publicToken");

                if (null != callback)
                    callback(result, playerID, publicToken);

            });

            return handlerNum;
        }

    }
}