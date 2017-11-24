namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public interface ISession
    {
        bool CreateSession();
        void SetChannelSignIn(Session.ChannelSignInDelegate callback);
        void SignIn(Session.SignInDelegate callback);
        void ConnectToChannel(int channelCode, Session.ConnectToChannelDelegate callback);
        void SelectChannelConnectOption(ChannelConnectOption option, Session.SelectChannelConnectOptionDelegate callback);
        void DisconnectFromChannel(int channelCode, Session.DisconnectFromChannelDelegate callback);
        void IssueOTP(Session.IssueOTPDelegate callback);
        void RequestOTPInfo(string otp, Session.RequestOTPInfoDelegate callback);
        void CopyPlayerIdWithOTP(string otp, Session.CopyPlayerIdWithOTPDelegate callback);
        void ResetSession();
        string GetRegion();
        string GetPlayerId();
        string GetGameToken();
        Cipher GetCipherData(CipherType cipherType);
        string GetChannelId(int channelCode);
        string GetCountryCode();
        string GetJoinedCountryCode();
        string GetIPAddress();
        void SetWorld(string worldId);
        string GetWorld();
        void RemoveWorld();
        string GetConnectedChannelsByAuthServer();
    
    }
}
