#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS;

    public class GoogleManager
    {
        private static GoogleManager instance;
        public static GoogleManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GoogleManager();
                }
                return instance;
            }
        }

        private List<TestUserData> googlePlusUserList;
        private GoogleManager()
        {
            googlePlusUserList = TestData.Instance.GoogleUserList;
        }



        public void SignIn(SessionManager.ConnectToChannelDelegate callback, Session.ConnectToChannelDelegate handler)
        {
            string googlePlusKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.Google);
            if (!string.IsNullOrEmpty(googlePlusKey))
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                callback(result, NMGChannel.Google, googlePlusKey, handler);
            }
            else
            {
                ChannelLoginController.Show(NMGChannel.Google, googlePlusUserList, callback, handler);
            }
        }
    }
}
#endif