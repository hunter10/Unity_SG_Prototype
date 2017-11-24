#if UNITY_EDITOR
namespace NetmarbleS.NMGPlayMode
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS;

    public class GameCenterManager
    {
        private static GameCenterManager instance;
        public static GameCenterManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameCenterManager();
                }
                return instance;
            }
        }

        private List<TestUserData> appleGameCenterUserList;
        private GameCenterManager()
        {
            appleGameCenterUserList = TestData.Instance.GameCenterUserList;
        }

        public void SignIn(SessionManager.ConnectToChannelDelegate callback, Session.ConnectToChannelDelegate handler)
        {
            string appleGameCenterKey = NMGPlayerPrefs.GetChannelKey(NMGChannel.GameCenter);
            if (!string.IsNullOrEmpty(appleGameCenterKey))
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.SUCCESS, "Success");
                callback(result, NMGChannel.GameCenter, appleGameCenterKey, handler);
            }
            else
            {
                ChannelLoginController.Show(NMGChannel.GameCenter, appleGameCenterUserList, callback, handler);
            }
        }
    }
}
#endif