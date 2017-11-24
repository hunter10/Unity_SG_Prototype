namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class EveryNetmarblePlatform : IEveryNetmarble
    {

        public string VERSION
        {
            get { return "0.0.0.0000"; }
        }

        public void RequestMyProfile(EveryNetmarble.RequestMyProfileDelegate callback)
        {
            
        }

        public void RequestFriends(EveryNetmarble.RequestFriendsDelegate callback)
        {
            
        }

        public void SetEnableAuthenticationView(bool enable)
        {
            
        }
    }
}