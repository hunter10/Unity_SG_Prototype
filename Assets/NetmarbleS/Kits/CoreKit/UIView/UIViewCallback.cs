namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using NetmarbleS.Internal;

    public class UIViewCallback
    {
        public int SetUIViewCallback(UIView.UIViewDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[UIViewCallback] UIViewCallback: " + message.ToString());

                int uiviewState = message.GetInt("uiviewState");

                if (null != callback)
                    callback((UIViewState)uiviewState);
            });

            return handlerNum;
        }

        public int SetUIViewCallback(int location, UIView.UIViewDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[UIViewCallback] UIViewCallback: " + message.ToString());

                int uiviewState = message.GetInt("uiviewState");

                if (uiviewState == 0)
                {
                    UIViewRotation.Instance.SetAutoRotation(location);
                }
                else if (uiviewState == 1)
                {
                    UIViewRotation.Instance.SetGameRotation(location);
                }

                if (null != callback)
                    callback((UIViewState)uiviewState);
            });

            return handlerNum;
        }
    }
}