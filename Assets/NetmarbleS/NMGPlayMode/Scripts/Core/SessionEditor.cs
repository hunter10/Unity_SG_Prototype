#if UNITY_EDITOR
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using NetmarbleS.NMGPlayMode;
    using NetmarbleS.Internal;

    public class SessionEditor : ISession
    {
        //private SessionCallback sessionCallback;

        public SessionEditor()
        {
            // sessionCallback = new SessionCallback();

        }
        public bool CreateSession()
        {
            string gameObjectName = CallbackManager.NetmarbleGameObject.name;
            return SessionManager.Instance.CreateSession(gameObjectName);
        }

        public void SetChannelSignIn(Session.ChannelSignInDelegate callback)
        {
            SessionManager.Instance.SetChannelSignIn(callback);
        }

        public void SignIn(Session.SignInDelegate callback)
        {
            SessionManager.Instance.SignIn(callback);
        }

        public void ConnectToChannel(int channelCode, Session.ConnectToChannelDelegate callback)
        {
            SessionManager.Instance.ConnectToChannel(channelCode, callback);
        }

        public void SelectChannelConnectOption(ChannelConnectOption option, Session.SelectChannelConnectOptionDelegate callback)
        {
            SessionManager.Instance.SelectChannelConnectOption(option, callback);
        }

        public void DisconnectFromChannel(int channelCode, Session.DisconnectFromChannelDelegate callback)
        {
            SessionManager.Instance.DisconnectFromChannel(channelCode, callback);
        }

        public void IssueOTP(Session.IssueOTPDelegate callback)
        {

        }

        public void RequestOTPInfo(string otp, Session.RequestOTPInfoDelegate callback)
        {

        }

        public void CopyPlayerIdWithOTP(string otp, Session.CopyPlayerIdWithOTPDelegate callback)
        {

        }

        public void ResetSession()
        {
            SessionManager.Instance.ResetSession();
        }

        public string GetRegion()
        {
            return SessionManager.Instance.region;
        }

        public string GetPlayerId()
        {
            return SessionManager.Instance.playerId;
        }

        public string GetGameToken()
        {
            return SessionManager.Instance.gameToken;
        }

        public Cipher GetCipherData(CipherType cipherType)
        {
            return SessionManager.Instance.GetCipherData(cipherType);
        }

        public string GetChannelId(int channelCode)
        {
            return SessionManager.Instance.GetChannelID(channelCode);
        }

        public string GetCountryCode()
        {
            return SessionManager.Instance.countryCode;
        }

        public string GetJoinedCountryCode()
        {
            return SessionManager.Instance.joinedCountryCode;
        }

        public string GetIPAddress()
        {
            return SessionManager.Instance.IPAddress;
        }

        public void SetWorld(string worldId)
        {

        }

        public string GetWorld()
        {
            return null;
        }

        public void RemoveWorld()
        {

        }

        public string GetConnectedChannelsByAuthServer()
        {
            return null;
        }
    }
}
#endif