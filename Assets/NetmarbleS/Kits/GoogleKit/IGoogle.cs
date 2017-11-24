namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface IGoogle
    {
        string VERSION { get; }
        void SetAddPlusScope(bool add);
        bool GetAddPlusScope();
        void Authenticate(Google.AuthenticateDelegate callback);
        void RequestMyProfile(Google.RequestMyProfileDelegate callback);
        void RequestFriends(Google.RequestFriendsDelegate callback);
    }
}