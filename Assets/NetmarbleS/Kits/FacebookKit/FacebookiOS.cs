#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class FacebookiOS : IFacebook
    {
        [DllImport("__Internal")]
        public static extern IntPtr nmg_facebook_version();
        [DllImport("__Internal")]
        public static extern void nmg_facebook_requestMyProfile(int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_facebook_requestFriends(int handlerNum);
        [DllImport("__Internal")] 
        public static extern void nmg_facebook_inviteFriends(string message, string title, int handlerNum);
        [DllImport("__Internal")] 
        public static extern void nmg_facebook_requestInviters(int handlerNum);
        [DllImport("__Internal")] 
        public static extern void nmg_facebook_deleteInviters(string jsonFacebookIdArray, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_facebook_postPhoto(string message, string imagePath, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_facebook_postStatusUpdateWithMessage(string message, string name, string picture, string link, string caption, string description, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_facebook_postStatusUpdate(string name, string picture, string link, string caption, string description, string jsonExtras, int handlerNum);
        [DllImport("__Internal")]
        public static extern void nmg_facebook_addPermissions(string jsonPermissions);

        private FacebookCallback facebookCallback;
        private string version;
        public FacebookiOS()
        {
            facebookCallback = new FacebookCallback();
            version = Marshal.PtrToStringAuto(nmg_facebook_version());
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public void RequestMyProfile(Facebook.RequestMyProfileDelegate callback)
        {
            int handlerNum = facebookCallback.SetRequestMyProfileCallback(callback);
            nmg_facebook_requestMyProfile(handlerNum);

        }

        public void RequestFriends(Facebook.RequestFriendsDelegate callback)
        {
            int handlerNum = facebookCallback.SetRequestFriendsCallback(callback);
            nmg_facebook_requestFriends(handlerNum);
        }
            
        public void InviteFriends(string message, string title, Facebook.InviteFriendsDelegate callback)
        {
            int handlerNum = facebookCallback.SetInviteFriendsCallback(callback);
            nmg_facebook_inviteFriends(message, title, handlerNum);
        }

        public void RequestInviters(Facebook.RequestInvitersDelegate callback)
        {
            int handlerNum = facebookCallback.SetRequestInvitersCallback(callback);
            nmg_facebook_requestInviters(handlerNum);
        }

        public void DeleteInviters(List<string> facebookIdList, Facebook.DeleteInvitersDelegate callback)
        {
            string facebookIdJson = Internal.Utils.ToJson(facebookIdList);
            int handlerNum = facebookCallback.SetDeleteInvitersCallback(callback);
            nmg_facebook_deleteInviters(facebookIdJson, handlerNum);
        }

        public void PostPhoto(string message, Texture2D texture, Facebook.PostPhotoDelegate callback)
        {
            byte[] bytes = texture.EncodeToPNG();
            string imagePath = null;
            imagePath = Application.temporaryCachePath + "/PostPhoto.png";
            File.WriteAllBytes(imagePath, bytes);
            int handlerNum = facebookCallback.SetPostPhotoCallback(callback);
            nmg_facebook_postPhoto(message, imagePath, handlerNum);
        }

        public void PostStatusUpdate(string message, string name, string picture, string link, string caption, string description, Facebook.PostStatusUpdateDelegate callback)
        {
            int handlerNum = facebookCallback.SetPostStatusUpdateCallback(callback);
            nmg_facebook_postStatusUpdateWithMessage(message, name, picture, link, caption, description, handlerNum);
        }

        public void PostStatusUpdate(string name, string picture, string link, string caption, string description, Dictionary<string, string> extras, Facebook.PostStatusUpdateDelegate callback)
        {
            string extrasJson = Internal.Utils.ToJson(extras);
            int handlerNum = facebookCallback.SetPostStatusUpdateCallback(callback);
            nmg_facebook_postStatusUpdate(name, picture, link, caption, description, extrasJson, handlerNum);
        }

        public void AddPermissions(List<string> permissions)
        {
            string permissionsJson = Internal.Utils.ToJson(permissions);
            nmg_facebook_addPermissions(permissionsJson);
        }
    }
}
#endif