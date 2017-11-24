#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class EveryNetmarbleAndroid : IEveryNetmarble
    {
        private AndroidJavaClass everyNetmarbleClass;
        private EveryNetmarbleCallback everyNetmarbleCallback;
        private string version;

        public EveryNetmarbleAndroid()
        {
            everyNetmarbleClass = new AndroidJavaClass("com.netmarble.unity.NMGEveryNetmarbleUnity");
            everyNetmarbleCallback = new EveryNetmarbleCallback();
            version = everyNetmarbleClass.GetStatic<string>("VERSION");
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public void RequestMyProfile(EveryNetmarble.RequestMyProfileDelegate callback)
        {
            int handlerNum = everyNetmarbleCallback.SetRequestMyProfileCalblack(callback);
            everyNetmarbleClass.CallStatic("nmg_everyNetmarble_requestMyProfile", handlerNum);
        }

        public void RequestFriends(EveryNetmarble.RequestFriendsDelegate callback)
        {
            int handlerNum = everyNetmarbleCallback.SetRequestFriendsCallback(callback);
            everyNetmarbleClass.CallStatic("nmg_everyNetmarble_requestFriends", handlerNum);
        }

        public void SetEnableAuthenticationView(bool enable)
        {
            Log.Debug("[EveryNetmarbleAndroid] not supported API");
        }
    }
}
#endif