#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS;

    public class TwitterManager
    {
        private static TwitterManager instance;
        public static TwitterManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TwitterManager();
                }
                return instance;
            }
        }

        private List<TestUserData> twitterUserList;
        private TwitterManager()
        {
            twitterUserList = TestData.Instance.TwitterUserList;
        }



        public void SignIn(SessionManager.ConnectToChannelDelegate callback, Session.ConnectToChannelDelegate handler)
        {
            string twitterKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.Twitter);
            if (!string.IsNullOrEmpty(twitterKey))
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                callback(result, NMGChannel.Twitter, twitterKey, handler);
            }
            else
            {
                ChannelLoginController.Show(NMGChannel.Twitter, twitterUserList, callback, handler);
            }
        }
    }
}
#endif