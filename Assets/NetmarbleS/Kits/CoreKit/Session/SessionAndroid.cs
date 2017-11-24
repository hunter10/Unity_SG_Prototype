#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS.Internal;

    public class SessionAndroid : ISession
    {
        private AndroidJavaClass sessionAndroidClass;
        private SessionCallback sessionCallback;

        public SessionAndroid()
        {
            sessionAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGSessionUnity");
            sessionCallback = new SessionCallback();
        }

        public bool CreateSession()
        {
            string gameObjectName = CallbackManager.NetmarbleGameObject.name;
            return sessionAndroidClass.CallStatic<bool>("nmg_session_createSession", gameObjectName);
        }

        public void SetChannelSignIn(Session.ChannelSignInDelegate callback)
        {
            int handlerNum = sessionCallback.SetChannelSignInCallback(callback);
            sessionAndroidClass.CallStatic("nmg_session_setChannelSignIn", handlerNum);
        }

        public void SignIn(Session.SignInDelegate callback)
        {
            int handlerNum = sessionCallback.SetSignInCallback(callback);
            sessionAndroidClass.CallStatic("nmg_session_signIn", handlerNum);
        }

        public void ConnectToChannel(int channelCode, Session.ConnectToChannelDelegate callback)
        {
            int handlerNum = sessionCallback.SetConnectToChannelCallback(callback);
            sessionAndroidClass.CallStatic("nmg_session_connectToChannel", channelCode, handlerNum);
        }

        public void SelectChannelConnectOption(ChannelConnectOption option, Session.SelectChannelConnectOptionDelegate callback)
        {
            int handlerNum = sessionCallback.SetSelectChannelConnectOptionCallback(callback);
            sessionAndroidClass.CallStatic("nmg_session_selectChannelConnectOption", (int)option.Type, option.ChannelCode, option.PlayerID, option.ChannelID, option.Region, handlerNum);
        }

        public void DisconnectFromChannel(int channelCode, Session.DisconnectFromChannelDelegate callback)
        {
            int handlerNum = sessionCallback.SetDisconnectFromChannelCallback(callback);
            sessionAndroidClass.CallStatic("nmg_session_disconnectFromChannel", channelCode, handlerNum);
        }

        public void IssueOTP(Session.IssueOTPDelegate callback)
        {
            int handlerNum = sessionCallback.SetIssueOTPCallback(callback);
            sessionAndroidClass.CallStatic("nmg_session_issueOTP", handlerNum);
        }

        public void RequestOTPInfo(string otp, Session.RequestOTPInfoDelegate callback)
        {
            int handlerNum = sessionCallback.SetRequestOTPInfoCallback(callback);
            sessionAndroidClass.CallStatic("nmg_session_requestOTPInfo", otp, handlerNum);
        }

        public void CopyPlayerIdWithOTP(string otp, Session.CopyPlayerIdWithOTPDelegate callback)
        {
            int handlerNum = sessionCallback.SetCopyPlayerIdWithOTPCallback(callback);
            sessionAndroidClass.CallStatic("nmg_session_copyPlayerIdWithOTP", otp, handlerNum);
        }

        public void ResetSession()
        {
            sessionAndroidClass.CallStatic("nmg_session_resetSession");
        }

        public string GetRegion()
        {
            return sessionAndroidClass.CallStatic<string>("nmg_session_getRegion");
        }

        public string GetPlayerId()
        {
            return sessionAndroidClass.CallStatic<string>("nmg_session_getPlayerId");
        }

        public string GetGameToken()
        {
            return sessionAndroidClass.CallStatic<string>("nmg_session_getGameToken");
        }

        public Cipher GetCipherData(CipherType cipherType)
        {
            string returnString =  sessionAndroidClass.CallStatic<string>("nmg_session_getCipherData", (int)cipherType);
            CallbackMessage message = new CallbackMessage(returnString);
            int cipherTypeNum = message.GetInt("cipherTypeNum");
            string secretKey = message.GetString("secretKey");
            string aesInitialVector = message.GetString("aesInitialVector");

            Cipher cipher = new Cipher((CipherType)cipherTypeNum, secretKey, aesInitialVector);
            return cipher;
        }

        public string GetChannelId(int channelCode)
        {
            return sessionAndroidClass.CallStatic<string>("nmg_session_getChannelId", channelCode);
        }

        public string GetCountryCode()
        {
            return sessionAndroidClass.CallStatic<string>("nmg_session_getCountryCode");
        }

        public string GetJoinedCountryCode()
        {
            return sessionAndroidClass.CallStatic<string>("nmg_session_getJoinedCountryCode");
        }

        public string GetIPAddress()
        {
            return sessionAndroidClass.CallStatic<string>("nmg_session_getIPAddress");
        }

        public void SetWorld(string worldId)
        {
            sessionAndroidClass.CallStatic("nmg_session_setWorld", worldId);
        }

        public string GetWorld()
        {
            return sessionAndroidClass.CallStatic<string>("nmg_session_getWorld"); 
        }

        public void RemoveWorld()
        {
            sessionAndroidClass.CallStatic("nmg_session_removeWorld");
        }

        public string GetConnectedChannelsByAuthServer()
        {
            return sessionAndroidClass.CallStatic<string>("nmg_session_getConnectedChannelsByAuthServer"); 
        }
    }
}
#endif