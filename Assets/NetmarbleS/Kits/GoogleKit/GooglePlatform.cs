namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class GooglePlatform : IGoogle
    {

        public string VERSION
        {
            get { return "0.0.0.0000"; }
        }

        public void SetAddPlusScope(bool add)
        {
            
        }

        public bool GetAddPlusScope()
        {
            return false;
        }

        public void Authenticate(Google.AuthenticateDelegate callback)
        {

        }

        public void RequestMyProfile(Google.RequestMyProfileDelegate callback)
        {
            
        }

        public void RequestFriends(Google.RequestFriendsDelegate callback)
        {
            
        }
    }
}