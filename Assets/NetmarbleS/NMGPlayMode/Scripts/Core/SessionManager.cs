#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using UnityEditor;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS;
    using NetmarbleS.Internal;
    using LitJson;

    public enum NMGChannel
    {
        EveryNetmarble = 0,
        Facebook = 1,
        Kakao = 2,
        Google = 5,
        GameCenter = 6,
        Naver = 7,
        QQ = 9,
        WeChat = 10,
        CO = 11,
        Twitter = 12
    }

    public class SessionManager
    {
        public enum SessionStatus
        {
            NONE,
            INITIALIZING,
            INITIALIZED,
            SIGNING,
            SIGNED
        };

        public SessionStatus status;
        private bool waitForSignin;
        public bool waitForTermsOfService;

        private Session.ChannelSignInDelegate channelSignInHandler;
        private Session.SignInDelegate signInHandler;
        private Session.ConnectToChannelDelegate connectToChannelHandler;
        private Session.SelectChannelConnectOptionDelegate selectChannelConnectOptionHandler;
        public UIView.UIViewDelegate termsOfServiceHandler;
 

        private TestData testData;
        public string playerId;
        public string gameToken;
        public string deviceKey;
        private Dictionary<CipherType, Cipher> cipherDataDic;
        private Dictionary<string, string> hmacDataDic;

        public delegate void SignInDelegate(Result result, Session.SignInDelegate handler);
        public delegate void ConnectToChannelDelegate(Result result, NMGChannel channel, string channelKey, Session.ConnectToChannelDelegate handler);
        public delegate void SelectChannelConnectOptionDelegate(Result result, List<ChannelConnectOption> channelConnectOptionList, Session.SelectChannelConnectOptionDelegate handler);



        private static SessionManager instance;
        public static SessionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionManager();
                }
                return instance;
            }
        }
        private SessionManager()
        {
            status = SessionStatus.NONE;
            waitForSignin = false;
            cipherDataDic = new Dictionary<CipherType, Cipher>();
            hmacDataDic = new Dictionary<string, string>();
            waitForTermsOfService = false;
        }

        public string countryCode
        {
            get
            {
                return NMGPlayerPrefs.GetCountryCode();
            }
        }

        public string region
        {
            get
            {
                return NMGPlayerPrefs.GetRegion();
            }

        }

        public string joinedCountryCode
        {
            get
            {
                return NMGPlayerPrefs.GetJoinedCountryCode();
            }
        }

        public string IPAddress
        {
            get
            {
                return NMGPlayerPrefs.GetIPAddress();
            }
        }

        public Cipher GetCipherData(CipherType cipherType)
        {
            return cipherDataDic[cipherType];
        }

        public string GetChannelID(int channel)
        {
            if (string.IsNullOrEmpty(gameToken))
            {
                Log.Debug("[NMGPlayMode.SessionManager] Not SignIned return null");
                return null;
            }
            return NMGPlayerPrefs.GetChannelKey((NMGChannel)channel);
        }

        #region CreateSession
        private void OnCreateSession(Result result)
        {
            status = SessionStatus.INITIALIZED;

            if (result.IsSuccess())
            {
                Log.Debug("[NMGPlayMode.SessionManager] CreateSession Success");

                // TODO update locale, language
                // UNDONE push update

                if (waitForTermsOfService)
                {
                    UIViewManager.Instance.ShowTermsOfServiceView(termsOfServiceHandler);
                }

                if (waitForSignin)
                {
                    status = SessionStatus.SIGNING;
                    SignIn(OnSignIn, signInHandler);
                    
                }

            }
            else
            {
                Log.Debug("[NMGPlayMode.SessionManager] CreateSession Fail");

                if (waitForTermsOfService)
                {
                    if (termsOfServiceHandler !=  null)
                    {
                        Log.Debug("[NMGPlayMode.SessionManager] Fail to get netmarbleS constants");
                        UIViewManager.Instance.OnShowView(UIViewState.FAILED, termsOfServiceHandler);
                    }
                }
                if (waitForSignin)
                {
                    if (signInHandler != null)
                    {
                        waitForSignin = false;
                        status = SessionStatus.NONE;

                        Result signinResult = new Result(Result.NETMARBLES_DOMAIN, Result.SERVICE, "Fail to get netmarbleS constants");
                        signInHandler(signinResult);
                        signInHandler = null;
                    }

                }
            }
        }
        public bool CreateSession(string cbGameObject)
        {
            if (!ConfigurationManager.CheckConfiguration())
            {
                Log.Debug("[NMGPlayMode.SessionManager] CreateSession Fail ");
                return false;
            }

            testData = TestData.Instance;

            if (status == SessionStatus.NONE)
            {
                status = SessionStatus.INITIALIZING;

                playerId = NMGPlayerPrefs.GetPlayerId();

                if (string.IsNullOrEmpty(playerId))
                {
                    playerId = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                    NMGPlayerPrefs.SetPlayerId(playerId);
                    Log.Debug("[NMGPlayMode.SessionManager] Save new PlayerID : " + playerId);
                }

                GMC2ServiceManager.Instance.Initialize(OnCreateSession);

                CheckTermsOfServiceKit();
                return true;
            }
            else
            {
                Log.Debug("[NMGPlayMode.SessionManager] CreateSession Fail");
                return false;
            }
        }
        #endregion

        #region SignIn
        public void SetChannelSignIn(Session.ChannelSignInDelegate handler)
        {
            channelSignInHandler = handler;
        }
        private void OnSignIn(Result result, Session.SignInDelegate handler)
        {
            status = SessionStatus.SIGNED;
            waitForSignin = false;

            if (handler != null)
                handler(result);

            signInHandler = null;

        }

        public void SignIn(Session.SignInDelegate handler)
        {
            if (status == SessionStatus.NONE)
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SERVICE, "Not initialized");

                if (handler != null)
                    handler(result);
            }
            else if (status == SessionStatus.INITIALIZING)
            {
                waitForSignin = true;
                signInHandler = handler;

            }
            else if (status == SessionStatus.SIGNING)
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.IN_PROGRESS, "It is currently in progress.");

                if (handler != null)
                    handler(result);
            }
            else
            {
                status = SessionStatus.SIGNING;
                SignIn(OnSignIn, handler);
            }
        }

        private WWW SignIn(SignInDelegate callback, Session.SignInDelegate handler)
        {
            if (GMC2ServiceManager.Instance.GetConstantCount() == 0)
            {
                if (callback != null && callback is SignInDelegate)
                {
                    Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SERVICE, "GMC2 is fail");
                    Log.Debug("[NMGPlayMode.SessionManager] SignIn Fail (" + result + ")");
                    callback(result, handler);
                }
                return null;
            }

            deviceKey = NMGPlayerPrefs.GetDeviceKey();

            if (string.IsNullOrEmpty(deviceKey))
            {
                deviceKey = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                NMGPlayerPrefs.SetDeviceKey(deviceKey);
                Log.Debug("[NMGPlayMode.SessionManager] Save new deviceKey : " + deviceKey);
            }


            // UNDONE nmDeviceKey
            // string nmDeviceKey = null;
            // androidid, uuid

            WWWForm wwwForm = new WWWForm();
            wwwForm.AddField("gameCode", ConfigurationManager.Instance.GameCode);
            wwwForm.AddField("deviceKey", deviceKey);
            wwwForm.AddField("playerId", playerId);
            wwwForm.AddField("countryCode", countryCode);

            Dictionary<string, string> headerDic = new Dictionary<string, string>();
            headerDic["Content-Type"] = "application/x-www-form-urlencoded";
            headerDic["Accept"] = "application/json";

            string authUrl = GMC2ServiceManager.Instance.GetConstantValue("authUrl");
           
            if (authUrl != null)
                authUrl = authUrl.Replace("http://", "https://");
            authUrl += NMGConstants.SIGN_IN;

            WWW www = new WWW(authUrl, wwwForm.data, headerDic);

            CallbackManager.NetmarbleGameObject.StartCoroutine(WaitForSignIn(www, callback, handler));
            return www;
        }

        private IEnumerator WaitForSignIn(WWW www, SignInDelegate callback, Session.SignInDelegate handler)
        {
            yield return www;

            Log.Debug("[NMGPlayMode.SessionManager] SignIn Callback : " + www.text + ", error : " + www.error);

            if (www.error == null)
            {
                ProcessData(www.text, callback, handler);

            }
            else
            {
                if (callback != null && callback is SignInDelegate)
                {
                    Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SERVICE, www.error);
                    Log.Debug("[NMGPlayMode.SessionManager] SignIn Fail (" + result + ")");
                    callback(result, handler);
                }
            }
        }

        private void ProcessData(string jsonString, SignInDelegate callback, Session.SignInDelegate handler)
        {
            JsonData jsonData = JsonMapper.ToObject(jsonString);

            int resultCode = (int)jsonData["resultCode"];
            string resultMessage = jsonData["resultMessage"].ToString();

            if (resultCode == 200)
            {
                JsonData playerData = jsonData["player"];
                IDictionary playerDic = playerData as IDictionary;

                playerId = playerDic["playerId"].ToString();

                string region = null;
                if (playerDic.Contains("gameRegion"))
                {
                    region = playerDic["gameRegion"].ToString();
                }
                NMGPlayerPrefs.SetRegion(region);
                Log.Debug("[NMGPlayMode.SessionManager] Save new region : " + region);

                string joinedCountryCode = null;

                if (playerDic.Contains("joinedCountryCode"))
                {
                    joinedCountryCode = playerDic["joinedCountryCode"].ToString();
                }
                NMGPlayerPrefs.SetJoinedCountryCode(joinedCountryCode);
                Log.Debug("[NMGPlayMode.SessionManager] Save new JoinedCountryCode : " + joinedCountryCode);

                JsonData resultData = jsonData["resultData"];
                gameToken = resultData["gameToken"].ToString();

                JsonData keyInfoData = resultData["cipherKeyList"]["keyInfos"];

                for (int i = 0; i < keyInfoData.Count; i++)
                {
                    string cipherType = keyInfoData[i]["cipherType"].ToString();
                    string secretKey = keyInfoData[i]["secretKey"].ToString();

                    Cipher cipher = null;
                    if (cipherType == "CIPHER_RC4_40")
                    {
                        cipher = new Cipher(CipherType.RC4_40, secretKey, null);

                    }
                    else if (cipherType == "CIPHER_AES_128_CBC")
                    {
                        string aesInitVec = keyInfoData[i]["aesInitVec"].ToString();
                        cipher = new Cipher(CipherType.AES_128_CBC, secretKey, aesInitVec);
                    }

                    if (cipher != null)
                        cipherDataDic[cipher.CipherType] = cipher;
                }

                JsonData hmacInfoData = resultData["hmacInfoList"]["hmacInfos"];

                for (int i = 0; i < hmacInfoData.Count; i++)
                {
                    string hmacType = hmacInfoData[i]["hmacType"].ToString();
                    string hmacKey = hmacInfoData[i]["hmacKey"].ToString();
                    hmacDataDic[hmacType] = hmacKey;
                }

                if (callback != null && callback is SignInDelegate)
                {
                    testData.SetChannelConnectionData(playerId, deviceKey);
                    CheckConnectedChannelAndAutoSignin(playerId);

                    // Talk
                    SignedTalkKit();

                    Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                    Log.Debug("[NMGPlayMode.SessionManager] SignIn OK (" + result + ")");

                    callback(result, handler);
                }
            }
            else
            {
                if (callback != null && callback is SignInDelegate)
                {
                    Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SERVICE, "ErrorCode(" + resultCode + "), ErrorMessage(" + resultMessage + ")");
                    Log.Debug("[NMGPlayMode.SessionManager] SignIn Fail (" + result + ")");
                    callback(result, handler);
                }
            }
        }

        private void CheckConnectedChannelAndAutoSignin(string playerId)
        {
            ChannelConnectionData savedData = testData.GetChannelConnectionData(playerId);

            if (string.IsNullOrEmpty(savedData.EmailKey))
            {
                NMGPlayerPrefs.SetChannelKey(NMGChannel.EveryNetmarble, null);
            }
            else
            {
                if (!string.IsNullOrEmpty(NMGPlayerPrefs.GetChannelKey(NMGChannel.EveryNetmarble)))
                {
                    string emailIdKey = savedData.EmailKey;
                    string localSavedKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.EveryNetmarble);

                    if (emailIdKey.Equals(localSavedKey))
                    {
                        AutoChannelSignin(NMGChannel.EveryNetmarble, emailIdKey);
                    }
                }
            }

            if (string.IsNullOrEmpty(savedData.FacebookKey))
            {
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Facebook, null);
            }
            else
            {
                if (!string.IsNullOrEmpty(NMGPlayerPrefs.GetChannelKey(NMGChannel.Facebook)))
                {
                    string facebookKey = savedData.FacebookKey;
                    string localSavedKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.Facebook);

                    if (facebookKey.Equals(localSavedKey))
                    {
                        AutoChannelSignin(NMGChannel.Facebook, facebookKey);
                    }
                }
            }

            if (string.IsNullOrEmpty(savedData.GoogleKey))
            {
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Google, null);
            }
            else
            {
                if (!string.IsNullOrEmpty(NMGPlayerPrefs.GetChannelKey(NMGChannel.Google)))
                {
                    string googleKey = savedData.GoogleKey;
                    string localSavedKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.Google);

                    if (googleKey.Equals(localSavedKey))
                    {
                        AutoChannelSignin(NMGChannel.Google, googleKey);
                    }
                }
            }


            if (string.IsNullOrEmpty(savedData.NaverKey))
            {
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Naver, null);
            }
            else
            {
                if (!string.IsNullOrEmpty(NMGPlayerPrefs.GetChannelKey(NMGChannel.Naver)))
                {
                    string naverKey = savedData.NaverKey;
                    string localSavedKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.Naver);

                    if (naverKey.Equals(localSavedKey))
                    {
                        AutoChannelSignin(NMGChannel.Naver, naverKey);
                    }
                }
            }

            if (string.IsNullOrEmpty(savedData.TwitterKey))
            {
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Twitter, null);
            }
            else
            {
                if (!string.IsNullOrEmpty(NMGPlayerPrefs.GetChannelKey(NMGChannel.Twitter)))
                {
                    string twitterKey = savedData.TwitterKey;
                    string localSavedKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.Twitter);

                    if (twitterKey.Equals(localSavedKey))
                    {
                        AutoChannelSignin(NMGChannel.Twitter, twitterKey);
                    }
                }
            }
        }

        private void AutoChannelSignin(NMGChannel channel, string channelKey)
        {
            if (!string.IsNullOrEmpty(channelKey))
            {
                if (channelSignInHandler != null)
                {
                    Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                    channelSignInHandler(result, (int)channel);
                }
            }
        }
        #endregion

        #region Connect / Disconnect Channel

        void OnConnectToChannel(Result result, NMGChannel channel, string channelKey, Session.ConnectToChannelDelegate handler)
        {
            if (result.IsSuccess())
            {
                ChannelConnectionData savedData = testData.GetChannelConnectionData(playerId);
                string channelKeyAtPlayerID = savedData.GetChannelKeyByChannel(channel);

                ChannelConnectionData savedChannelData = testData.GetChannelConnectionData(channel, channelKey);

                if (string.IsNullOrEmpty(channelKeyAtPlayerID))
                {
                    if (savedChannelData == null)
                    {
                        // ok 연결
                        savedData.SetChannelKeyByChannel(channel, channelKey);
                        NMGPlayerPrefs.SetChannelKey(channel, channelKey);

                        Result channelResult = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                        Log.Debug("[NMGPlayMode.SessionManager] ConnectToChannel OK (" + channelResult + ")");

                        if (handler != null)
                            handler(channelResult, null);
                    }
                    else
                    {
                        // 다른pid에 연결 되어있음
                        if (channel == NMGChannel.Kakao)
                        {
                            SelectOptionInConnectToChannel(new ChannelConnectOption(ChannelConnectOptionType.LoadChannelConnection, savedChannelData.PlayerId, (int)channel, channelKey, savedChannelData.GameRegion), handler);
                            return;
                        }

                        List<ChannelConnectOption> channelConnectOptionList = new List<ChannelConnectOption>();
                        if (channel != NMGChannel.GameCenter)
                            channelConnectOptionList.Add(new ChannelConnectOption(ChannelConnectOptionType.Cancel, savedData.PlayerId, (int)channel, null, savedData.GameRegion));
                        //channelConnectOptionList.Add(new ChannelConnectOption(ChannelConnectOptionType.UpdateChannelConnection, savedData.PlayerId, channel, channelKey, savedData.GameRegion));
                        channelConnectOptionList.Add(new ChannelConnectOption(ChannelConnectOptionType.LoadChannelConnection, savedChannelData.PlayerId, (int)channel, channelKey, savedChannelData.GameRegion));

                        Result channelResult = new Result(Result.NETMARBLES_DOMAIN, Result.CONNECT_CHANNEL_OPTION_USED_CHANNELID, "Please select channel connect option.");
                        Log.Debug("[NMGPlayMode.SessionManager] ConnectToChannel Fail(" + channelResult + ")");

                        if (handler != null)
                            handler(channelResult, channelConnectOptionList);
                    }
                }
                else
                {
                    if (savedChannelData == null)
                    {
                        if (channelKeyAtPlayerID.Equals(channelKey))
                        {
                            // 나올 수 없음 
                        }
                        else
                        {
                            // 채널 변경하려고 함
                            if (channel == NMGChannel.Kakao)
                            {
                                SelectOptionInConnectToChannel(new ChannelConnectOption(ChannelConnectOptionType.CreateChannelConnection, null, (int)channel, channelKey, NMGPlayerPrefs.GetRegion()), handler);
                                return;
                            }

                            List<ChannelConnectOption> channelConnectOptionList = new List<ChannelConnectOption>();
                            if (channel != NMGChannel.GameCenter)
                                channelConnectOptionList.Add(new ChannelConnectOption(ChannelConnectOptionType.Cancel, savedData.PlayerId, (int)channel, channelKeyAtPlayerID, savedData.GameRegion));
                            channelConnectOptionList.Add(new ChannelConnectOption(ChannelConnectOptionType.CreateChannelConnection, null, (int)channel, channelKey, NMGPlayerPrefs.GetRegion()));

                            Result channelResult = new Result(Result.NETMARBLES_DOMAIN, Result.CONNECT_CHANNEL_OPTION_NEW_CHANNELID, "Please select channel connect option.");
                            Log.Debug("[NMGPlayMode.SessionManager] ConnectToChannel Fail(" + channelResult + ")");

                            if (handler != null)
                                handler(channelResult, channelConnectOptionList);
                        }
                    }
                    else
                    {
                        if (channelKeyAtPlayerID.Equals(channelKey))
                        {
                            // 같은 거 ok
                            NMGPlayerPrefs.SetChannelKey(channel, channelKey);

                            Result channelResult = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                            Log.Debug("[NMGPlayMode.SessionManager] ConnectToChannel OK (" + channelResult + ")");

                            if (handler != null)
                                handler(channelResult, null);
                        }
                        else
                        {
                            //bothChannelIDsMappedPlayerIDs 각각 연결되어있음
                            if (channel == NMGChannel.Kakao)
                            {
                                SelectOptionInConnectToChannel(new ChannelConnectOption(ChannelConnectOptionType.LoadChannelConnection, savedChannelData.PlayerId, (int)channel, channelKey, savedChannelData.GameRegion), handler);
                                return;
                            }

                            List<ChannelConnectOption> channelConnectOptionList = new List<ChannelConnectOption>();
                            if (channel != NMGChannel.GameCenter)
                                channelConnectOptionList.Add(new ChannelConnectOption(ChannelConnectOptionType.Cancel, savedData.PlayerId, (int)channel, channelKeyAtPlayerID, savedData.GameRegion));
                            channelConnectOptionList.Add(new ChannelConnectOption(ChannelConnectOptionType.LoadChannelConnection, savedChannelData.PlayerId, (int)channel, channelKey, savedChannelData.GameRegion));

                            Result channelResult = new Result(Result.NETMARBLES_DOMAIN, Result.CONNECT_CHANNEL_OPTION_USED_CHANNELID, "Please select channel connect option.");
                            Log.Debug("[NMGPlayMode.SessionManager] ConnectToChannel Fail(" + channelResult + ")");

                            if (handler != null)
                                handler(channelResult, channelConnectOptionList);
                        }
                    }
                }
            }
            else
            {
                if (handler != null)
                    handler(result, null);
            }
        }

        private void SelectOptionInConnectToChannel(ChannelConnectOption option, Session.ConnectToChannelDelegate handler)
        {
            connectToChannelHandler = handler;
            SelectChannelConnectOption(option, null);
        }

        private void OnChannelOptionSignIn(Result result, Session.SignInDelegate handler)
        {
            if (connectToChannelHandler != null)
                connectToChannelHandler(result, null);
            else if (selectChannelConnectOptionHandler != null)
                selectChannelConnectOptionHandler(result);

            connectToChannelHandler = null;
            selectChannelConnectOptionHandler = null;
        }

        public void SelectChannelConnectOption(ChannelConnectOption option, Session.SelectChannelConnectOptionDelegate handler)
        {
            ChannelConnectOptionType type = option.Type;
            NMGChannel channel = (NMGChannel)option.ChannelCode;
            string playerID = option.PlayerID;
            string channelID = option.ChannelID;
            string region = option.Region;

            if (type == ChannelConnectOptionType.Cancel)
            {
                NMGPlayerPrefs.SetChannelKey(channel, null);

                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                Log.Debug("[NMGPlayMode.SessionManager] SelectChannelConnectOption OK (" + result + ")");

                if (handler != null)
                    handler(result);
            }
            else if (type == ChannelConnectOptionType.CreateChannelConnection)
            {
                playerId = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                NMGPlayerPrefs.SetPlayerId(playerId);
                Log.Debug("[NMGPlayMode.SessionManager] Save new PlayerID : " + playerId);

                deviceKey = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                NMGPlayerPrefs.SetDeviceKey(deviceKey);
                Log.Debug("[NMGPlayMode.SessionManager] Save new deviceKey : " + deviceKey);

                testData.SetChannelConnectionData(playerId, deviceKey);

                ChannelConnectionData savedData = testData.GetChannelConnectionData(playerId);
                savedData.SetChannelKeyByChannel(channel, channelID);

                NMGPlayerPrefs.SetChannelKey(NMGChannel.EveryNetmarble, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Facebook, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Kakao, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Google, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.GameCenter, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Naver, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Twitter, null);
                NMGPlayerPrefs.SetChannelKey(channel, channelID);

                NMGPlayerPrefs.SetRegion(region);

                selectChannelConnectOptionHandler = handler;
                SignIn(OnChannelOptionSignIn, null);
                UpdateTalkKit();

            }
            else if (type == ChannelConnectOptionType.LoadChannelConnection)
            {
                ChannelConnectionData savedData = testData.GetChannelConnectionData(playerID);

                NMGPlayerPrefs.SetPlayerId(playerID);
                NMGPlayerPrefs.SetDeviceKey(savedData.DeviceKey);
                NMGPlayerPrefs.SetRegion(region);

                NMGPlayerPrefs.SetChannelKey(NMGChannel.EveryNetmarble, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Facebook, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Kakao, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Google, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.GameCenter, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Naver, null);
                NMGPlayerPrefs.SetChannelKey(NMGChannel.Twitter, null);
                NMGPlayerPrefs.SetChannelKey(channel, channelID);

                playerId = playerID;

                selectChannelConnectOptionHandler = handler;
                SignIn(OnChannelOptionSignIn, null);
                UpdateTalkKit();

            }
           /* else if (type == ChannelConnectOptionType.UpdateChannelConnection)
            {
                NMPlayModeChannelConnectionData savedData = testData.GetChannelConnectionData(playerID);
                NMPlayModeChannelConnectionData savedChannelData = testData.GetChannelConnectionData(channel, channelID);

                if (savedChannelData != null)
                {
                    savedChannelData.SetChannelKeyByChannel(channel, null);
                }

                savedData.SetChannelKeyByChannel(channel, channelID);
                NMPlayModePlayerPrefs.SetChannelKey(channel, channelID);

                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                Log.Debug("[NMGPlayMode.SessionManager] SelectChannelConnectOption OK (" + result + ")");

                if (handler != null)
                    handler(result);
            }*/
        }


        public void ConnectToChannel(int channel, Session.ConnectToChannelDelegate handler)
        {
            if (String.IsNullOrEmpty(gameToken))
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.NOT_AUTHENTICATED, "Not signed");
                if (handler != null)
                    handler(result, null);
            }
            else
            {
                switch ((NMGChannel)channel)
                {
                    case NMGChannel.EveryNetmarble:
                        EveryNetmarbleManager.Instance.SignIn(OnConnectToChannel, handler);
                        break;
                    case NMGChannel.Facebook:
                        FacebookManager.Instance.SignIn(OnConnectToChannel, handler);
                        break;
                    case NMGChannel.Kakao:
                        KakaoManager.Instance.SignIn(OnConnectToChannel, handler);
                        break;
                    case NMGChannel.Google:
                        GoogleManager.Instance.SignIn(OnConnectToChannel, handler);
                        break;
                    case NMGChannel.GameCenter:
                        GameCenterManager.Instance.SignIn(OnConnectToChannel, handler);
                        break;
                    case NMGChannel.Twitter:
                        TwitterManager.Instance.SignIn(OnConnectToChannel, handler);
                        break;
                    //case NMGChannel.Naver:
                    //    NMPlayModeNaverManager.Instance.SignIn(OnConnectToChannel, handler);
                    //    break;
                }
            }
        }

        public void DisconnectFromChannel(int channelCode, Session.DisconnectFromChannelDelegate handler)
        {
            NMGPlayerPrefs.SetChannelKey((NMGChannel)channelCode, null);

            Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
            if (handler != null)
                handler(result);

        }
        #endregion

        #region ResetSession
        public void ResetSession()
        {
            gameToken = null;
            cipherDataDic = new Dictionary<CipherType, Cipher>();
            hmacDataDic = new Dictionary<string, string>();

            NMGPlayerPrefs.SetChannelKey(NMGChannel.EveryNetmarble, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Facebook, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Kakao, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Google, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.GameCenter, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Naver, null);
            NMGPlayerPrefs.SetChannelKey(NMGChannel.Twitter, null);
            NMGPlayerPrefs.SetRegion(null);

            if (Configuration.GetUseFixedPlayerID())
            {
                // TODO FixedPlayerID
            }
            else
            {
                playerId = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                NMGPlayerPrefs.SetPlayerId(playerId);
                Log.Debug("[NMGPlayMode.SessionManager] Save new PlayerID : " + playerId);

                deviceKey = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                NMGPlayerPrefs.SetDeviceKey(deviceKey);
                Log.Debug("[NMGPlayMode.SessionManager] Save new deviceKey : " + deviceKey);

                InitTalkKit();
            }
        }
        #endregion

        private void CheckTermsOfServiceKit()
        {
            Type type = Type.GetType("NetmarbleS.TermsOfService");

            if (null != type)
            {
                object tos = Activator.CreateInstance(Type.GetType("NetmarbleS.TermsOfServicePlatform"));
                Type tosType = tos.GetType();
                System.Reflection.FieldInfo tosFieldInfo = tosType.GetField("TERMS_OF_SERVICE", System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Instance  | System.Reflection.BindingFlags.Public);
                tosFieldInfo.SetValue(tos, 11001);

                System.Reflection.FieldInfo fieldInfo = type.GetField("termsOfService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
                fieldInfo.SetValue(type, tos);
            }
        }

        private void InitTalkKit()
        {
            if (null != Type.GetType("NetmarbleS.TalkSession"))
            {
                Type talkManagerType = Type.GetType("NetmarbleS.NMGPlayMode.TalkManager");
                System.Reflection.PropertyInfo propertyInfo = talkManagerType.GetProperty("Instance", talkManagerType);
                object talkManager = propertyInfo.GetValue(propertyInfo, null);

                System.Reflection.MethodInfo init = talkManager.GetType().GetMethod("Init", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                init.Invoke(talkManager, null);


                Type tcpSessionManagerType = Type.GetType("NetmarbleS.NMGPlayMode.TCPSessionManager");
                System.Reflection.PropertyInfo tcpSessionManagerPropertyInfo = tcpSessionManagerType.GetProperty("Instance", tcpSessionManagerType);
                object tcpSessionManager = tcpSessionManagerPropertyInfo.GetValue(tcpSessionManagerPropertyInfo, null);

                System.Reflection.MethodInfo onInitializedSession = tcpSessionManager.GetType().GetMethod("OnInitializedSession", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                onInitializedSession.Invoke(tcpSessionManager, null);
            }
        }

        private void SignedTalkKit()
        {
            if (null != Type.GetType("NetmarbleS.TalkSession"))
            {
                Type talkManagerType = Type.GetType("NetmarbleS.NMGPlayMode.TalkManager");
                System.Reflection.PropertyInfo propertyInfo = talkManagerType.GetProperty("Instance", talkManagerType);
                object talkManager = propertyInfo.GetValue(propertyInfo, null);

                System.Reflection.MethodInfo initTalkDelegate = talkManager.GetType().GetMethod("InitTalkDelegate", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                initTalkDelegate.Invoke(talkManager, null);


                Type tcpSessionManagerType = Type.GetType("NetmarbleS.NMGPlayMode.TCPSessionManager");
                System.Reflection.PropertyInfo tcpSessionManagerPropertyInfo = tcpSessionManagerType.GetProperty("Instance", tcpSessionManagerType);
                object tcpSessionManager = tcpSessionManagerPropertyInfo.GetValue(tcpSessionManagerPropertyInfo, null);

                System.Reflection.MethodInfo onSignedSession = tcpSessionManager.GetType().GetMethod("OnSignedSession", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                onSignedSession.Invoke(tcpSessionManager, null);
            }
        }

        private void UpdateTalkKit()
        {
            if (null != Type.GetType("NetmarbleS.TalkSession"))
            {
                Type talkManagerType = Type.GetType("NetmarbleS.NMGPlayMode.TalkManager");
                System.Reflection.PropertyInfo propertyInfo = talkManagerType.GetProperty("Instance", talkManagerType);
                object talkManager = propertyInfo.GetValue(propertyInfo, null);

                System.Reflection.MethodInfo init = talkManager.GetType().GetMethod("Init", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                init.Invoke(talkManager, null);


                Type tcpSessionManagerType = Type.GetType("NetmarbleS.NMGPlayMode.TCPSessionManager");
                System.Reflection.PropertyInfo tcpSessionManagerPropertyInfo = tcpSessionManagerType.GetProperty("Instance", tcpSessionManagerType);
                object tcpSessionManager = tcpSessionManagerPropertyInfo.GetValue(tcpSessionManagerPropertyInfo, null);

                System.Reflection.MethodInfo onUpdatedSession = tcpSessionManager.GetType().GetMethod("OnUpdatedSession", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                onUpdatedSession.Invoke(tcpSessionManager, null);
            }
        }
    }
}
#endif