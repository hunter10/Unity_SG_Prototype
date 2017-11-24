#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;

    [InitializeOnLoad]
    public class TestData : ScriptableObject
    {

        #region ChannelUserDataList

        [SerializeField]
        private List<TestUserData> everyNetmarbleUserList = new List<TestUserData>()
        {
            new EveryNetmarbleUserData("ema01"),
            new EveryNetmarbleUserData("ema02"),
            new EveryNetmarbleUserData("ema03")
        };
        [SerializeField]
        private List<TestUserData> facebookUserList = new List<TestUserData>()
        {
            new FacebookUserData("fb01"),
            new FacebookUserData("fb02"),
            new FacebookUserData("fb03")
        };
        [SerializeField]
        private List<TestUserData> kakaoUserList = new List<TestUserData>()
        {
            new KakaoUserData("kakao01"),
            new KakaoUserData("kakao02"),
            new KakaoUserData("kakao03")
        };
        [SerializeField]
        private List<TestUserData> googleUserList = new List<TestUserData>()
        {
           new GoogleUserData("google01"),
            new GoogleUserData("google02"),
            new GoogleUserData("google03")
        };
        [SerializeField]
        private List<TestUserData> gameCenterUserList = new List<TestUserData>()
        {
           new GameCenterUserData("apple01"),
            new GameCenterUserData("apple02"),
            new GameCenterUserData("apple03")
        };
        [SerializeField]
        private List<TestUserData> naverUserList = new List<TestUserData>()
        {
            new NaverUserData("naver01"),
            new NaverUserData("naver02"),
            new NaverUserData("naver03")
        };
        [SerializeField]
        private List<TestUserData> twitterUserList = new List<TestUserData>()
        {
            new TwitterUserData("twitter01"),
            new TwitterUserData("twitter02"),
            new TwitterUserData("twitter03")
        };




        public List<TestUserData> EveryNetmarbleUserList
        {
            get
            {
                return everyNetmarbleUserList;
            }
        }
        public List<TestUserData> FacebookUserList
        {
            get
            {
                return facebookUserList;
            }
        }
        public List<TestUserData> KakaoUserList
        {
            get
            {
                return kakaoUserList;
            }
        }
        public List<TestUserData> GoogleUserList
        {
            get
            {
                return googleUserList;
            }
        }
        public List<TestUserData> GameCenterUserList
        {
            get
            {
                return gameCenterUserList;
            }
        }
        public List<TestUserData> NaverUserList
        {
            get
            {
                return naverUserList;
            }
        }
        public List<TestUserData> TwitterUserList
        {
            get
            {
                return twitterUserList;
            }
        }


        public TestUserData GetUserData(List<TestUserData> testUserList, string id)
        {
            foreach (TestUserData userData in testUserList)
            {
                if (userData.ChannelID.Equals(id))
                {
                    return userData;
                }
            }
            return null;
        }

        public bool Exist(List<TestUserData> testUserList, string id)
        {
            foreach (TestUserData userData in testUserList)
            {
                if (userData.ChannelID.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(List<TestUserData> testUserList, TestUserData userData)
        {
            if (!Exist(testUserList, userData.ChannelID))
            {
                testUserList.Add(userData);
            }
            else
            {
                Debug.Log("aleady exist");
            }
            EditorUtility.SetDirty(Instance);
        }

        public void Add(List<TestUserData> testUserList, NMGChannel channel, string newId)
        {
            TestUserData userData = null;

            if (channel == NMGChannel.EveryNetmarble)
            {
                userData = new EveryNetmarbleUserData(newId);
                userData.ChannelKey = ((EveryNetmarbleUserData)userData).GenerateKey();
            }
            else if (channel == NMGChannel.Facebook)
            {
                userData = new FacebookUserData(newId);
                userData.ChannelKey = ((FacebookUserData)userData).GenerateKey();
            }
            else if (channel == NMGChannel.Kakao)
            {
                userData = new KakaoUserData(newId);
                userData.ChannelKey = ((KakaoUserData)userData).GenerateKey();
            }
            else if (channel == NMGChannel.Google)
            {
                userData = new GoogleUserData(newId);
                userData.ChannelKey = ((GoogleUserData)userData).GenerateKey();
            }
            else if (channel == NMGChannel.GameCenter)
            {
                userData = new GameCenterUserData(newId);
                userData.ChannelKey = ((GameCenterUserData)userData).GenerateKey();

            }

            else if (channel == NMGChannel.Naver)
            {
                userData = new NaverUserData(newId);
                userData.ChannelKey = ((NaverUserData)userData).GenerateKey();

            }

            else if (channel == NMGChannel.Twitter)
            {
                userData = new TwitterUserData(newId);
                userData.ChannelKey = ((TwitterUserData)userData).GenerateKey();

            }


            Add(testUserList, userData);
        }

        public void RemoveAt(List<TestUserData> testUserList, int index)
        {
            testUserList.RemoveAt(index);

            EditorUtility.SetDirty(Instance);
        }

        #endregion

        #region ChannelConnectionDataList

        //[HideInInspector]
        [SerializeField]
        private List<ChannelConnectionData> channelConnectionDataList = new List<ChannelConnectionData>();

        public List<ChannelConnectionData> ChannelConnectionDataList
        {
            get
            {
                return channelConnectionDataList;
            }
        }

        public ChannelConnectionData GetChannelConnectionData(NMGChannel channel, string channelKey)
        {
            switch (channel)
            {
                case NMGChannel.EveryNetmarble:
                    foreach (ChannelConnectionData channelConnectionData in channelConnectionDataList)
                    {
                        if (channelKey.Equals(channelConnectionData.EmailKey))
                        {
                            return channelConnectionData;
                        }
                    }
                    break;
                case NMGChannel.Facebook:
                    foreach (ChannelConnectionData channelConnectionData in channelConnectionDataList)
                    {
                        if (channelKey.Equals(channelConnectionData.FacebookKey))
                        {
                            return channelConnectionData;
                        }
                    }
                    break;
                case NMGChannel.Kakao:
                    foreach (ChannelConnectionData channelConnectionData in channelConnectionDataList)
                    {
                        if (channelKey.Equals(channelConnectionData.KakaoTalkKey))
                        {
                            return channelConnectionData;
                        }
                    }
                    break;
                case NMGChannel.Google:
                    foreach (ChannelConnectionData channelConnectionData in channelConnectionDataList)
                    {
                        if (channelKey.Equals(channelConnectionData.GoogleKey))
                        {
                            return channelConnectionData;
                        }
                    }
                    break;
                case NMGChannel.GameCenter:
                    foreach (ChannelConnectionData channelConnectionData in channelConnectionDataList)
                    {
                        if (channelKey.Equals(channelConnectionData.GameCenterKey))
                        {
                            return channelConnectionData;
                        }
                    }
                    break;
                case NMGChannel.Naver:
                    foreach (ChannelConnectionData channelConnectionData in channelConnectionDataList)
                    {
                        if (channelKey.Equals(channelConnectionData.NaverKey))
                        {
                            return channelConnectionData;
                        }
                    }
                    break;
                case NMGChannel.Twitter:
                    foreach (ChannelConnectionData channelConnectionData in channelConnectionDataList)
                    {
                        if (channelKey.Equals(channelConnectionData.TwitterKey))
                        {
                            return channelConnectionData;
                        }
                    }
                    break;
            }
            return null;
        }
        public ChannelConnectionData GetChannelConnectionData(string playerId)
        {
            foreach (ChannelConnectionData channelConnectionData in channelConnectionDataList)
            {
                if (channelConnectionData.PlayerId.Equals(playerId))
                {
                    return channelConnectionData;
                }
            }
            return null;
        }

        public void SetChannelConnectionData(string playerId, string deviceKey)
        {
            foreach (ChannelConnectionData channelConnectionData in channelConnectionDataList)
            {
                if (channelConnectionData.PlayerId.Equals(playerId))
                {
                    return;
                }
            }

            channelConnectionDataList.Add(new ChannelConnectionData(playerId, deviceKey));
        }

        #endregion

        private static TestData instance;
        public static TestData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (TestData)AssetDatabase.LoadAssetAtPath(NMGConstants.TEST_DATA_PATH, typeof(TestData));
                    if (instance == null)
                    {
                        instance = ScriptableObject.CreateInstance<TestData>();
                        AssetDatabase.CreateAsset(instance, NMGConstants.TEST_DATA_PATH);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                    }
                }
                return instance;
            }
        }

        [MenuItem("Netmarble/PlayMode/Reset PlayMode")]
        public static void ShowDummyData()
        {
            AssetDatabase.DeleteAsset(NMGConstants.TEST_DATA_PATH);
            Debug.Log("Reset OK");
        }

        [MenuItem("Netmarble/PlayMode/Delete App Data")]
        public static void DeleteData()
        {
            NMGPlayerPrefs.DeleteAll();
            Debug.Log("Delete OK");
        }
    }

    #region ChannelUserData

    [System.Serializable]
    public class TestUserData
    {
        [SerializeField]
        private string channelId;
        [SerializeField]
        protected string channelKey;

        public TestUserData(string channelId)
        {
            this.channelId = channelId;
        }

        public string ChannelID
        {
            get
            {
                return channelId;
            }
            set
            {
                channelId = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string ChannelKey
        {
            get
            {
                return channelKey;
            }
            set
            {
                channelKey = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }
    }

    public class EveryNetmarbleUserData : TestUserData
    {
        public EveryNetmarbleUserData(string channelId)
            : base(channelId)
        {
        }

        public string GenerateKey()
        {
            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string channelKey = "";

            for (int i = 0; i < 3; i++)
            {
                channelKey = channelKey + chars[Random.Range(0, chars.Length)];
            }
            return "DUMMY_KRNM00000" + channelKey;
        }
    }

    public class FacebookUserData : TestUserData
    {
        public FacebookUserData(string channelId)
            : base(channelId)
        {
        }

        public string GenerateKey()
        {
            string channelKey = "";

            for (int i = 0; i < 3; i++)
            {
                channelKey = channelKey + Random.Range(0, 99999).ToString("00000");
            }
            return "DUMMY_" + channelKey;
        }
    }

    public class KakaoUserData : TestUserData
    {
        public KakaoUserData(string channelId)
            : base(channelId)
        {
        }

        public string GenerateKey()
        {
            string channelKey = "";

            for (int i = 0; i < 3; i++)
            {
                channelKey = channelKey + Random.Range(0, 99999).ToString("00000");
            }
            channelKey = channelKey + Random.Range(0, 99).ToString("00");
            return "DUMMY_" + channelKey;
        }
    }

    public class GoogleUserData : TestUserData
    {
        public GoogleUserData(string channelId)
            : base(channelId)
        {
        }

        public string GenerateKey()
        {
            string channelKey = "";

            for (int i = 0; i < 3; i++)
            {
                channelKey = channelKey + Random.Range(0, 9999999).ToString("0000000");
            }
            return "DUMMY_" + channelKey;
        }
    }

    public class GameCenterUserData : TestUserData
    {
        public GameCenterUserData(string channelId)
            : base(channelId)
        {
        }

        public string GenerateKey()
        {
            string channelKey = "";

            for (int i = 0; i < 2; i++)
            {
                channelKey = channelKey + Random.Range(0, 99999).ToString("00000");
            }
            return "DUMMY_G:" + channelKey;
        }
    }

    public class NaverUserData : TestUserData
    {
        public NaverUserData(string channelId)
            : base(channelId)
        {
        }

        public string GenerateKey()
        {
            string channelKey = "";

            for (int i = 0; i < 2; i++)
            {
                channelKey = channelKey + Random.Range(0, 9999).ToString("0000");
            }
            return "DUMMY_" + channelKey;
        }
    }

    public class TwitterUserData : TestUserData
    {
        public TwitterUserData(string channelId)
            : base(channelId)
        {
        }

        public string GenerateKey()
        {
            string channelKey = "";

            for (int i = 0; i < 2; i++)
            {
                channelKey = channelKey + Random.Range(0, 9999).ToString("0000");
            }
            return "DUMMY_" + channelKey;
        }
    }

    //UNDONE QQ, Wechat

    #endregion

    #region ChannelConnectionData

    [System.Serializable]
    public class ChannelConnectionData
    {
        [SerializeField]
        private string playerId;
        [SerializeField]
        private string emailKey;
        [SerializeField]
        private string facebookKey;
        [SerializeField]
        private string kakaoTalkKey;
        [SerializeField]
        private string googleKey;
        [SerializeField]
        private string gameCenterKey;
        [SerializeField]
        private string naverKey;
        [SerializeField]
        private string twitterKey;
        [SerializeField]
        private string gameRegion;
        [SerializeField]
        private string deviceKey;

        //UNDONE QQ, Wechat, cosdk

        public ChannelConnectionData(string playerId, string deviceKey)
        {
            this.playerId = playerId;
            this.deviceKey = deviceKey;
        }

        public string PlayerId
        {
            get
            {
                return playerId;
            }
            set
            {
                playerId = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string EmailKey
        {
            get
            {
                return emailKey;
            }
            set
            {
                emailKey = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string FacebookKey
        {
            get
            {
                return facebookKey;
            }
            set
            {
                facebookKey = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string KakaoTalkKey
        {
            get
            {
                return kakaoTalkKey;
            }
            set
            {
                kakaoTalkKey = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string GoogleKey
        {
            get
            {
                return googleKey;
            }
            set
            {
                googleKey = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string GameCenterKey
        {
            get
            {
                return gameCenterKey;
            }
            set
            {
                gameCenterKey = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string NaverKey
        {
            get
            {
                return naverKey;
            }
            set
            {
                naverKey = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string TwitterKey
        {
            get
            {
                return twitterKey;
            }
            set
            {
                twitterKey = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string GameRegion
        {
            get
            {
                return gameRegion;
            }
            set
            {
                gameRegion = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string DeviceKey
        {
            get
            {
                return deviceKey;
            }
            set
            {
                deviceKey = value;
                EditorUtility.SetDirty(TestData.Instance);
            }
        }

        public string GetChannelKeyByChannel(NMGChannel channel)
        {
            switch (channel)
            {
                case NMGChannel.EveryNetmarble:
                    return emailKey;
                case NMGChannel.Facebook:
                    return facebookKey;
                case NMGChannel.Kakao:
                    return kakaoTalkKey;
                case NMGChannel.Google:
                    return googleKey;
                case NMGChannel.GameCenter:
                    return gameCenterKey;
                case NMGChannel.Naver:
                    return naverKey;
                case NMGChannel.Twitter:
                    return twitterKey;
                default:
                    return null;
            }

        }

        public void SetChannelKeyByChannel(NMGChannel channel, string channelKey)
        {
            switch (channel)
            {
                case NMGChannel.EveryNetmarble:
                    emailKey = channelKey;
                    break;
                case NMGChannel.Facebook:
                    facebookKey = channelKey;
                    break;
                case NMGChannel.Kakao:
                    kakaoTalkKey = channelKey;
                    break;
                case NMGChannel.Google:
                    googleKey = channelKey;
                    break;
                case NMGChannel.GameCenter:
                    gameCenterKey = channelKey;
                    break;
                case NMGChannel.Naver:
                    naverKey = channelKey;
                    break;
                case NMGChannel.Twitter:
                    twitterKey = channelKey;
                    break;
            }
        }
    }
    #endregion
}
#endif