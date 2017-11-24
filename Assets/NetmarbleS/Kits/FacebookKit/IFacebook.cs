namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public interface IFacebook
    {
        string VERSION { get; }
        void RequestMyProfile(Facebook.RequestMyProfileDelegate callback);
        void RequestFriends(Facebook.RequestFriendsDelegate callback);
        void InviteFriends(string message, string title, Facebook.InviteFriendsDelegate callback);
        void RequestInviters(Facebook.RequestInvitersDelegate callback);
        void DeleteInviters(List<string> facebookIdList, Facebook.DeleteInvitersDelegate callback);
        void PostPhoto(string message, Texture2D texture, Facebook.PostPhotoDelegate callback);
        void PostStatusUpdate(string message, string name, string picture, string link, string caption, string description, Facebook.PostStatusUpdateDelegate callback);
        void PostStatusUpdate(string name, string picture, string link, string caption, string description, Dictionary<string, string> extras, Facebook.PostStatusUpdateDelegate callback);
        void AddPermissions(List<string> permissions);
    }
}