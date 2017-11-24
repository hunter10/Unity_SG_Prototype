namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class SessionPlatform : ISession
    {
        public bool CreateSession()
        {
            return true;
        }

        public void SetChannelSignIn(Session.ChannelSignInDelegate callback)
        {
        }

        public void SignIn(Session.SignInDelegate callback)
        {
        }

        public void ConnectToChannel(int channelCode, Session.ConnectToChannelDelegate callback)
        {
        }

        public void SelectChannelConnectOption(ChannelConnectOption option, Session.SelectChannelConnectOptionDelegate callback)
        {
            
        }

        public void DisconnectFromChannel(int channelCode, Session.DisconnectFromChannelDelegate callback)
        {
            
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
            
        }

        public string GetRegion()
        {
            return null;
        }

        public string GetPlayerId()
        {
            return null;
        }

        public string GetGameToken()
        {
            return null;
        }

        public Cipher GetCipherData(CipherType cipherType)
        {
            return null;   
        }

        public string GetChannelId(int channelCode)
        {
            return null;   
        }

        public string GetCountryCode()
        {
            return null;   
        }

        public string GetJoinedCountryCode()
        {
            return null;   
        }

        public string GetIPAddress()
        {
            return null;   
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