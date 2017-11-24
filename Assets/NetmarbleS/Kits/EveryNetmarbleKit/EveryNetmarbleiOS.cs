#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    public class EveryNetmarbleiOS : IEveryNetmarble
    {
        [DllImport("__Internal")]
        public static extern IntPtr nmg_everyNetmarble_version();
        [DllImport("__Internal")]
        public static extern void nmg_everyNetmarble_requestMyProfile(int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_everyNetmarble_requestFriends(int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_everyNetmarble_setEnableAuthenticationView(bool enable);

        private EveryNetmarbleCallback everyNetmarbleCallback;
        private string version;
        public EveryNetmarbleiOS()
        {
            everyNetmarbleCallback = new EveryNetmarbleCallback();
            version = Marshal.PtrToStringAuto(nmg_everyNetmarble_version());
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
            nmg_everyNetmarble_requestMyProfile(handlerNum);
        }

        public void RequestFriends(EveryNetmarble.RequestFriendsDelegate callback)
        {
            int handlerNum = everyNetmarbleCallback.SetRequestFriendsCallback(callback);
            nmg_everyNetmarble_requestFriends(handlerNum);
        }

        public void SetEnableAuthenticationView(bool enable)
        {
            nmg_everyNetmarble_setEnableAuthenticationView(enable);
        }
    }
}
#endif