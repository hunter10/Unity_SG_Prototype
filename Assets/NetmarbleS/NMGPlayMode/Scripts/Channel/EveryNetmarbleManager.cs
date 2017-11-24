#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS;

    public class EveryNetmarbleManager
    {
        private static EveryNetmarbleManager instance;
        public static EveryNetmarbleManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EveryNetmarbleManager();
                }
                return instance;
            }
        }

        private List<TestUserData> everyNetmarbleUserList;
        private EveryNetmarbleManager()
        {
            everyNetmarbleUserList = TestData.Instance.EveryNetmarbleUserList;
        }


        public void SignIn(SessionManager.ConnectToChannelDelegate callback, Session.ConnectToChannelDelegate handler)
        {
            string everyNetmarbleKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.EveryNetmarble);
            if (!string.IsNullOrEmpty(everyNetmarbleKey))
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                callback(result, NMGChannel.EveryNetmarble, everyNetmarbleKey, handler);
            }
            else
            {
                ChannelLoginController.Show(NMGChannel.EveryNetmarble, everyNetmarbleUserList, callback, handler);
            }
        }
    }
}
#endif