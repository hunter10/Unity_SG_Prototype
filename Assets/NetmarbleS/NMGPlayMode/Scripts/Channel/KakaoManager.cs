#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS;


    public class KakaoManager
    {
        private static KakaoManager instance;
        public static KakaoManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KakaoManager();
                }
                return instance;
            }
        }

        private List<TestUserData> kakaoUserList;
        private KakaoManager()
        {
            kakaoUserList = TestData.Instance.KakaoUserList;
        }



        public void SignIn(SessionManager.ConnectToChannelDelegate callback, Session.ConnectToChannelDelegate handler)
        {
            string kakaoKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.Kakao);
            if (!string.IsNullOrEmpty(kakaoKey))
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                callback(result, NMGChannel.Kakao, kakaoKey, handler);
            }
            else
            {
                ChannelLoginController.Show(NMGChannel.Kakao, kakaoUserList, callback, handler);
            }
        }
    }
}
#endif