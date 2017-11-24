using UnityEngine;
using System.Collections;
using NetmarbleS.Internal;

namespace NetmarbleS
{
    public class CommonLogCallback
    {
        public int SetCommonLogUpdateEventCallback(CommonLog.UpdateEventDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[CommonLogCallback] CommonLogUpdateEventCallback : " + message);

                if (null != callback)
                    callback();
            });

            return handlerNum;
        }

        public int SetElementsCallback(CommonLog.ElementsDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[CommonLogCallback] ElementsCallback : " + message);

                string elements = message.GetString("elements");

                if (null != callback)
                    callback(elements);
            });

            return handlerNum;
        }
    }
}