#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS;


    public class FacebookManager
    {
        private static FacebookManager instance;
        public static FacebookManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FacebookManager();
                }
                return instance;
            }
        }

        private List<TestUserData> facebookUserList;
        private FacebookManager()
        {
            facebookUserList = TestData.Instance.FacebookUserList;
        }



        public void SignIn(SessionManager.ConnectToChannelDelegate callback, Session.ConnectToChannelDelegate handler)
        {
            string facebookKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.Facebook);
            if (!string.IsNullOrEmpty(facebookKey))
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                callback(result, NMGChannel.Facebook, facebookKey, handler);
            }
            else
            {
                ChannelLoginController.Show(NMGChannel.Facebook, facebookUserList, callback, handler);
            }
        }
    }
}
#endif