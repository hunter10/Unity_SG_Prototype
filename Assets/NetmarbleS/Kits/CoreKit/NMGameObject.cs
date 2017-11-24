 using UnityEngine;
using System.Collections;
using NetmarbleS.Internal;

public class NMGameObject : MonoBehaviour
{
    void Awake()
    {
        if (CallbackManager.NetmarbleGameObject != this)
            CallbackManager.NetmarbleGameObject = this;

        DontDestroyOnLoad(gameObject);
    }

    void OnDestroy()
    {
        if (CallbackManager.NetmarbleGameObject == this)
            CallbackManager.NetmarbleGameObject = null;
    }

    public void Callback(string res)
    {
        int handlerNum = -1;
        CallbackMessage message = new CallbackMessage(res);
        handlerNum = message.GetHandlerNum();
        CallbackManager.OnResponse handler = CallbackManager.GetHandler(handlerNum);
        if (null != handler)
            handler(message);
    }
}
