namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface IEveryNetmarble
    {
        string VERSION { get; }
        void RequestMyProfile(EveryNetmarble.RequestMyProfileDelegate callback);
        void RequestFriends(EveryNetmarble.RequestFriendsDelegate callback);
        void SetEnableAuthenticationView(bool enable);
    }
}