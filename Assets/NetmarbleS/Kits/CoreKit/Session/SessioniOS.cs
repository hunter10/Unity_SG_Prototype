#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

	using NetmarbleS.Internal;

    public class SessioniOS : ISession
    {

		[DllImport("__Internal")] 
		public static extern bool nmg_session_createSession(string cbGameObject);
		[DllImport("__Internal")] 
		public static extern void nmg_session_signIn(int handlerNum);
		[DllImport("__Internal")]
		public static extern void nmg_session_setChannelSignIn(int handlerNum);
		[DllImport("__Internal")] 
		public static extern void nmg_session_connectToChannel(int channel, int handlerNum);
		[DllImport("__Internal")] 
		public static extern void nmg_session_selectChannelConnectOption(int type, int channel, string playerId, string channelId, string region, int handlerNum);
		[DllImport("__Internal")] 
		public static extern void nmg_session_disconnectFromChannel(int channel, int handlerNum);
		[DllImport("__Internal")] 
		public static extern void nmg_session_issueOTP(int handlerNum);
		[DllImport("__Internal")] 
		public static extern void nmg_session_requestOTPInfo(string otp, int handlerNum);
		[DllImport("__Internal")] 
		public static extern void nmg_session_copyPlayerIdWithOTP(string otp, int handlerNum);
		[DllImport("__Internal")] 
		public static extern void nmg_session_resetSession();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getRegion();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getPlayerId();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getGameToken();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getCipherData(int cipherType);
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getChannelId(int channel);
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getCountryCode();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getJoinedCountryCode();
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getIPAddress();
		[DllImport("__Internal")] 
		public static extern void nmg_session_setWorld(string worldId);
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getWorld();
		[DllImport("__Internal")] 
		public static extern void nmg_session_removeWorld();
        [DllImport("__Internal")] 
		public static extern IntPtr nmg_session_getConnectedChannelsByAuthServer();

		private SessionCallback sessionCallback;

		public SessioniOS()
		{
			sessionCallback = new SessionCallback();
		}

		public bool CreateSession()
		{
			string gameObjectName = CallbackManager.NetmarbleGameObject.name;
			return nmg_session_createSession(gameObjectName);
		}

		public void SetChannelSignIn(Session.ChannelSignInDelegate callback)
		{
			int handlerNum = sessionCallback.SetChannelSignInCallback(callback);
			nmg_session_setChannelSignIn(handlerNum);
		}

		public void SignIn(Session.SignInDelegate callback)
		{
			int handlerNum = sessionCallback.SetSignInCallback(callback);
			nmg_session_signIn(handlerNum);
		}

		public void ConnectToChannel(int channelCode, Session.ConnectToChannelDelegate callback)
		{
			int handlerNum = sessionCallback.SetConnectToChannelCallback(callback);
			nmg_session_connectToChannel(channelCode, handlerNum);
		}

		public void SelectChannelConnectOption(ChannelConnectOption option, Session.SelectChannelConnectOptionDelegate callback)
		{
			int handlerNum = sessionCallback.SetSelectChannelConnectOptionCallback(callback);
			nmg_session_selectChannelConnectOption((int)option.Type, option.ChannelCode, option.PlayerID, option.ChannelID, option.Region, handlerNum);
		}

		public void DisconnectFromChannel(int channelCode, Session.DisconnectFromChannelDelegate callback)
		{
			int handlerNum = sessionCallback.SetDisconnectFromChannelCallback(callback);
			nmg_session_disconnectFromChannel(channelCode, handlerNum);
		}

		public void IssueOTP(Session.IssueOTPDelegate callback)
		{
			int handlerNum = sessionCallback.SetIssueOTPCallback(callback);
			nmg_session_issueOTP(handlerNum);
		}

		public void RequestOTPInfo(string otp, Session.RequestOTPInfoDelegate callback)
		{
			int handlerNum = sessionCallback.SetRequestOTPInfoCallback(callback);
			nmg_session_requestOTPInfo(otp, handlerNum);
		}

		public void CopyPlayerIdWithOTP(string otp, Session.CopyPlayerIdWithOTPDelegate callback)
		{
			int handlerNum = sessionCallback.SetCopyPlayerIdWithOTPCallback(callback);
			nmg_session_copyPlayerIdWithOTP(otp, handlerNum);
		}

		public void ResetSession()
		{
			nmg_session_resetSession();
		}

		public string GetRegion()
		{
			return Marshal.PtrToStringAuto(nmg_session_getRegion());
		}

		public string GetPlayerId()
		{
			return Marshal.PtrToStringAuto(nmg_session_getPlayerId());
		}

		public string GetGameToken()
		{
			return Marshal.PtrToStringAuto(nmg_session_getGameToken());
		}

		public Cipher GetCipherData(CipherType cipherType)
		{
			string returnString =  Marshal.PtrToStringAuto(nmg_session_getCipherData((int)cipherType));
			CallbackMessage message = new CallbackMessage(returnString);
			int cipherTypeNum = message.GetInt("cipherTypeNum");
			string secretKey = message.GetString("secretKey");
			string aesInitialVector = message.GetString("aesInitialVector");

			Cipher cipher = new Cipher((CipherType)cipherTypeNum, secretKey, aesInitialVector);
			return cipher;
		}

		public string GetChannelId(int channelCode)
		{
			return Marshal.PtrToStringAuto(nmg_session_getChannelId(channelCode));
		}

		public string GetCountryCode()
		{
			return Marshal.PtrToStringAuto(nmg_session_getCountryCode());
		}

		public string GetJoinedCountryCode()
		{
			return Marshal.PtrToStringAuto(nmg_session_getJoinedCountryCode());
		}

		public string GetIPAddress()
		{
			return Marshal.PtrToStringAuto(nmg_session_getIPAddress());
		}

		public void SetWorld(string worldId)
		{
			nmg_session_setWorld (worldId);
		}

		public string GetWorld()
		{
			return Marshal.PtrToStringAuto(nmg_session_getWorld());
		}

		public void RemoveWorld()
		{
			nmg_session_removeWorld();
		}

        public string GetConnectedChannelsByAuthServer()
        {
            return Marshal.PtrToStringAuto(nmg_session_getConnectedChannelsByAuthServer());
        }
    }
}
#endif