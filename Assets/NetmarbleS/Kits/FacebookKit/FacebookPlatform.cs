namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class FacebookPlatform : IFacebook
    {
        public string VERSION
        {
            get { return "0.0.0.0000"; }
        }

        public void RequestMyProfile(Facebook.RequestMyProfileDelegate callback)
        {
            
        }

        public void RequestFriends(Facebook.RequestFriendsDelegate callback)
        {
            
        }

        public void InviteFriends(string message, string title, Facebook.InviteFriendsDelegate callback)
        {
            
        }

        public void RequestInviters(Facebook.RequestInvitersDelegate callback)
        {
            
        }

        public void DeleteInviters(System.Collections.Generic.List<string> facebookIdList, Facebook.DeleteInvitersDelegate callback)
        {
            
        }

        public void PostPhoto(string message, Texture2D texture, Facebook.PostPhotoDelegate callback)
        {
            
        }

        public void PostStatusUpdate(string message, string name, string picture, string link, string caption, string description, Facebook.PostStatusUpdateDelegate callback)
        {
            
        }

        public void PostStatusUpdate(string name, string picture, string link, string caption, string description, System.Collections.Generic.Dictionary<string, string> extras, Facebook.PostStatusUpdateDelegate callback)
        {
            
        }

        public void AddPermissions(System.Collections.Generic.List<string> permissions)
        {
            
        }
    }
}