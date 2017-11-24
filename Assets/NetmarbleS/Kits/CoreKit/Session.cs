namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    /**
     * @brief Enum for the channel connection option type.<br>
     */
    public enum ChannelConnectOptionType
    {
        /**
         * Cancel.
         */
        Cancel = 0,
        /**
         * Update channel connection.
         */
        UpdateChannelConnection,
        /**
         * Load channel connection.
         */
        LoadChannelConnection,
        /**
         * Create channel connection.
         */
        CreateChannelConnection
    }

    public class ChannelConnectOption
    {
        private string playerId;
        private int channelCode;
        private string channelId;
        private ChannelConnectOptionType type;
        private string region;

        public ChannelConnectOption(ChannelConnectOptionType type, string playerId, int channelCode, string channelId, string region)
        {
            this.playerId = playerId;
            this.channelCode = channelCode;
            this.channelId = channelId;
            this.type = type;
            this.region = region;
        }

        public override string ToString()
        {
            return "[ChannelConnectOption] Type(" + type + "), PlayerId(" + playerId + "), ChannelCode(" + channelCode + "), ChannelId(" + channelId + "), Region(" + region + ")";
        }

        /**
         * @brief Gets the type.
         * 
         * @return type.
         * @see ChannelConnectOptionType
         */
        public ChannelConnectOptionType Type
        {
            get
            {
                return type;
            }
        }

        /**
         * @brief Gets the playerId.
         * 
         * @return PlayerId.
         */
        public string PlayerID
        {
            get
            {
                return playerId;
            }
        }

        /**
         * @brief Gets the channel.
         * 
         * @return ChannelName.
         */
        public int ChannelCode
        {
            get
            {
                return channelCode;
            }
        }

        /**
         * @brief Gets the channelId.
         * 
         * @return ChannelId.
         */
        public string ChannelID
        {
            get
            {
                return channelId;
            }
        }

        public string Region
        {
            get
            {
                return region;
            }
        }
    }
    public class OTPInfo
    {
        private string otp;
        private string playerId;
        private string region;
        private List<OTPAuthenticationHistory> otpAuthenticationHistoryList;

        public OTPInfo(string otp, string playerId, string region, List<OTPAuthenticationHistory> otpAuthenticationHistoryList)
        {
            this.otp = otp;
            this.playerId = playerId;
            this.region = region;
            this.otpAuthenticationHistoryList = otpAuthenticationHistoryList;
        }

        public override string ToString()
        {
            return "[OTPInfo] otp(" + otp + "), PlayerId(" + playerId + "), Region(" + region + "), " + "otpAuthenticationHistoryList(" + otpAuthenticationHistoryList + ")";
        }

        public string OTP
        {
            get
            {
                return otp;
            }
            set
            {
                otp = value;
            }
        }

        public string PlayerID
        {
            get
            {
                return playerId;
            }
            set
            {
                playerId = value;
            }
        }

        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                region = value;
            }
        }

        public List<OTPAuthenticationHistory> OTPAuthenticationHistoryList
        {
            get
            {
                return otpAuthenticationHistoryList;
            }
            set
            {
                otpAuthenticationHistoryList = value;
            }
        }
    }

    public class OTPAuthenticationHistory
    {
        private string gameCode;
        private string playerId;
        private string creationDate;

        public OTPAuthenticationHistory(string gameCode, string playerId, string creationDate)
        {
            this.gameCode = gameCode;
            this.playerId = playerId;
            this.creationDate = creationDate;
        }

        public override string ToString()
        {
            return "[OTPAuthenticationHistory] GameCode(" + gameCode + "), PlayerId(" + playerId + "), CreationDate(" + creationDate + ")";
        }

        public string GameCode
        {
            get
            {
                return gameCode;
            }
            set
            {
                gameCode = value;
            }
        }
        public string PlayerID
        {
            get
            {
                return playerId;
            }
            set
            {
                playerId = value;
            }
        }
        public string CreationData
        {
            get
            {
                return creationDate;
            }
            set
            {
                creationDate = value;
            }
        }
    }

    public class RestrictOTPInput
    {
        private int failCount;
        private string retryDateTime;

        public RestrictOTPInput(int failCount, string retryDateTime)
        {
            this.failCount = failCount;
            this.retryDateTime = retryDateTime;
        }

        public override string ToString()
        {
            return "[RestrictOTPInput] FailCount(" + failCount + "), RetryDateTime(" + retryDateTime + ")";
        }

        public int FailCount
        {
            get
            {
                return failCount;
            }
            set
            {
                failCount = value;
            }
        }

        public string RetryDateTime
        {
            get
            {
                return retryDateTime;
            }
            set
            {
                retryDateTime = value;
            }
        }

    }
    public class Session
    {
        /**
         * @brief SignIn callback delegate.
         * 
         * @param result Reuslt.
         * @param ChannelConnectOptionList The list of channel connect option.
         * @see Result
         */
        public delegate void SignInDelegate(Result result);

        /**
         * @brief ChannelSignIn callback delegate.
         * 
         * @param result Reuslt.
         * @param channel Channel.
         * @see Result
         */
        public delegate void ChannelSignInDelegate(Result result, int channelCode);

        /**
         * @brief ConnectToChannel callback delegate.
         * 
         * @param result Reuslt.
         * @param ChannelConnectOptionList The list of channel connect option.
         * @see Result
         */
        public delegate void ConnectToChannelDelegate(Result result, List<ChannelConnectOption> channelConnectOptionList);

        /**
         * @brief SelectChannelConnectOption callback delegate.
         * 
         * @param result Reuslt.
         * @see Result
         */
        public delegate void SelectChannelConnectOptionDelegate(Result result);

        /**
         * @brief DisconnectFromChannel callback delegate.
         * 
         * @param result Reuslt.
         * @see Result
         */
        public delegate void DisconnectFromChannelDelegate(Result result);

        /**
         * @brief IssueOTPDelegate callback delegate.
         * 
         * @param result Reuslt.
         * @param otp OTP.
         * @param otpAuthenticationHistoryList OTPAuthentication history
         * @see Result
         */
        public delegate void IssueOTPDelegate(Result result, string otp, List<OTPAuthenticationHistory> otpAuthenticationHistoryList);

        /**
         * @brief RequestOTPInfoDelegate callback delegate.
         * 
         * @param result Reuslt.
         * @param otpInfo OTP Info.
         * @param restrictOTPInput OTP 입력 제한 정보
         * @see Result
         */
        public delegate void RequestOTPInfoDelegate(Result result, OTPInfo otpInfo, RestrictOTPInput restrictOTPInput);

        /**
         * @brief CopyPlayerIdWithOTPDelegate callback delegate.
         * 
         * @param result Reuslt.
         * @param restrictOTPInput OTP 입력 제한 정보
         * @see Result
         */
        public delegate void CopyPlayerIdWithOTPDelegate(Result result, RestrictOTPInput restrictOTPInput);

        private static Session instance;
        /**
         * @brief Creates Session instance. This method needs to be called first to use NetamrbleS SDK. If you call this method after Session
         * instance is created, it returns false.<br>
         * You can use {@link Session#GetInstance()} to get the created Session object.<br>
         * After creating session, playerId can be used.
         * 
         * @return If success to create Session instance returns true, else returns false.
         */
        public static bool CreateSession()
        {
            Debug.Log("[Session] CreateSession");
            if (instance == null)
            {
                instance = new Session();
                return true;
            }

            return false;
        }

        /**
         * @brief Gets an Session instance.<br>
         * If the Session instance is not created by using {@link Session#CreateSession()},
         * this method returns null.
         * 
         * @return Session instance.<br>If the Session instance is not created, it returns null.
         * @see Session
         */
        public static Session GetInstance()
        {
            return instance;
        }

        /**
         * @brief Sign In to NetmarbleS service.<br>
         * After signing in, game token can be used to authenticate the player in game server.
         * 
         * @param callback Callback to deal with a reponse to the request.
         * @see SignInDelegate
         */
        public void SignIn(SignInDelegate callback)
        {
            Log.Debug("[Session] SignIn");
            SessionImpl.SignIn(callback);
        }

        /**
         * @brief Sets signed a channel.<br>
         * If channel is already connected, it returns result and auto signed channel.
         * 
         * @param callback Callback to deal with a reponse to the request.
         * @see SetChannelSignInDelegate
         */
        public void SetChannelSignInDelegate(ChannelSignInDelegate callback)
        {
            Log.Debug("[Session] SetChannelSignIn");
            SessionImpl.SetChannelSignIn(callback);
        }

        /**
         * @brief Connect to channel.<br>
         * After signing in, player who has playerId connect with channelId.<br>
         * If channel id is already connected other playerId or current channelId is not connected with current playerId, NM_RESULT_CODE_SELECT_CHANNEL_CONNECT_OPTION result and option list that you can choose will be delivered.
         * You can use SelectChannelConnectOption API to select option in option list.
         * 
         * @param channel Channel.
         * @param callback Callback to deal with a reponse to the request.
         * @see ConnectToChannelDelegate
         * @see Channel
         */
        public void ConnectToChannel(int channelCode, ConnectToChannelDelegate callback)
        {
            Log.Debug("[Session] ConnectToChannel");
            SessionImpl.ConnectToChannel(channelCode, callback);
        }

        /**
         * @brief Connect to channel by force.<br>
         * After signing in, player who has playerId connect with channelId.
         * if you get option list, use this API function to select option.
         * 
         * @param option Option.
         * @param callback Callback to deal with a reponse to the request.
         * @see SelectChannelConnectOptionDelegate
         * @see ChannelConnectOption
         */
        public void SelectChannelConnectOption(ChannelConnectOption option, SelectChannelConnectOptionDelegate callback)
        {
            Log.Debug("[Session] SelectChannelConnectOption");
            SessionImpl.SelectChannelConnectOption(option, callback);
        }

        /**
         * @brief Disconnect from channel.
         * 
         * @param channel Channel.
         * @param callback Callback to deal with a reponse to the request.
         * @see DisconnectFromChannelDelegate
         * @see Channel
         */
        public void DisconnectFromChannel(int channelCode, DisconnectFromChannelDelegate callback)
        {
            Log.Debug("[Session] DisconnectFromChannel");
            SessionImpl.DisconnectFromChannel(channelCode, callback);
        }

        /**
        * @brief IssueOTP
        * 
        * @param callback Callback to deal with a reponse to the request.
        * @see IssueOTPDelegate
        */
        public void IssueOTP(IssueOTPDelegate callback)
        {
            Log.Debug("[Session] IssueOTP");
            SessionImpl.IssueOTP(callback);
        }

        /**
        * @brief RequestOTPInfo
        * 
        * @param otp 1회성 인증 토큰
        * @param callback Callback to deal with a reponse to the request.
        * @see RequestOTPInfoDelegate
        */
        public void RequestOTPInfo(string otp, RequestOTPInfoDelegate callback)
        {
            Log.Debug("[Session] RequestOTPInfo");
            SessionImpl.RequestOTPInfo(otp, callback);
        }

        /**
        * @brief CopyPlayerIdWithOTP
        * 
        * @param otp 1회성 인증 토큰
        * @param callback Callback to deal with a reponse to the request.
        * @see RequestOTPInfoDelegate
        */
        public void CopyPlayerIDWithOTP(string otp, CopyPlayerIdWithOTPDelegate callback)
        {
            Log.Debug("[Session] CopyPlayerIdWithOTP");
            SessionImpl.CopyPlayerIdWithOTP(otp, callback);
        }

        /**
         * @brief Resets session.
         * 
         * PlayerId will be changed.
         */
        public void ResetSession()
        {
            Log.Debug("[Session] ResetSession");
            SessionImpl.ResetSession();
        }

        /**
         * @brief Get a region.
         * 
         * return region.
         */
        public string GetRegion()
        {
            Log.Debug("[Session] GetRegion");
            return SessionImpl.GetRegion();
        }

        /**
         * @brief Gets a playerId.
         * 
         * This method always returns playerId<br>
         * If not logged in, playerId can be used for playing game and save game data.
         * 
         * @return PlayerId.
         */
        public string GetPlayerID()
        {
            Log.Debug("[Session] GetPlayerID");
            return SessionImpl.GetPlayerId();
        }

        /**
         * @brief Gets a game token.
         * 
         * This method returns a game token when signed in successfully.
         * 
         * @return Game token.
         */
        public string GetGameToken()
        {
            Log.Debug("[Session] GetGameToken");
            return SessionImpl.GetGameToken();
        }

        /**
         * @brief Gets a cipher data.<br>
         * This method returns a cipher data when signed in successfully.
         * 
         * @return Cipher data.
         * @see Cipher
         */
        public Cipher GetCipherData(CipherType cipherType)
        {
            Log.Debug("[Session] GetCipherData cipherType:" + cipherType);
            return SessionImpl.GetCipherData(cipherType);
        }

        /**
         * @brief Gets a channelId.<br>
         * This method returns a channelId when this player connected to this channel.
         * 
         * @param channel Channel.
         * @see Channel
         * @return ChannelId.
         */
        public string GetChannelID(int channelCode)
        {
            Log.Debug("[Session] GetChannelID. channel:" + channelCode);
            return SessionImpl.GetChannelId(channelCode);
        }

        /**
         * @brief Gets a country code.<br>
         * This method returns a country code(get by IP address) when signed in successfully.
         * 
         * @return Country code.
         */
        public string GetCountryCode()
        {
            Log.Debug("[Session] GetCountryCode");
            return SessionImpl.GetCountryCode();
        }

        /**
         * @brief Gets a joined countryCode.<br>
         * This method returns a joined country code when signed in successfully.
         * 
         * @return Joined country code.
         */
        public string GetJoinedCountryCode()
        {
            Log.Debug("[Session] GetJoinedCountryCode");
            return SessionImpl.GetJoinedCountryCode();
        }

        /**
         * @brief Gets a IP address.<br>
         * This method returns a IP address when signed in successfully.
         * 
         * @return IP address.
         */
        public string GetIPAddress()
        {
            Log.Debug("[Session] GetIPAddress");
            return SessionImpl.GetIPAddress();
        }

        /**
         * @brief 현재 WorldId를 저장합니다.
         * @param worldId worldId.
         */
        public void SetWorld(string worldId)
        {
            Log.Debug("[Session] SetWorld worldId:" + worldId);
            SessionImpl.SetWorld(worldId);
        }

        /**
         * @brief 현재 WorldId를 가져옵니다.
         * @return worldId.
         */
        public string GetWorld()
        {
            Log.Debug("[Session] GetWorld");
            return SessionImpl.GetWorld();
        }

        /**
         * @brief 현재 WorldId를 삭제합니다
         */
        public void RemoveWorld()
        {
            Log.Debug("[Session] RemoveWorld");
            SessionImpl.RemoveWorld();
        }

        /**
         * @brief SignIn 응답이 성공 한 이후에 호출 할 수 있습니다.<br>
         * 인증 서버로 부터 응답 받은 값이며, 현재 PlayerID에 연결된 채널 정보를 알 수 있습니다.
         * @since 4.1.0
         */
        public string GetConnectedChannelsByAuthServer()
        {
             Log.Debug("[Session] GetConnectedChannelsByAuthServer");
             return SessionImpl.GetConnectedChannelsByAuthServer();
        }

        private Session()
        {
            SessionImpl.CreateSession();
        }
        private ISession session;
        private ISession SessionImpl
        {
            get
            {
                if (null == session)
                {
                    session = Internal.ClassLoader.GetTargetClass("Session") as ISession;
                    Debug.Log("[Core] NMGUnity Version : " + Configuration.GetUnityPluginVersion() + "(" + Configuration.GetNativePluginVersion() + ")");
                }
                return session;
            }
        }
    }
}
