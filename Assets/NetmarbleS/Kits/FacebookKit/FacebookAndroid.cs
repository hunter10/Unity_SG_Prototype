#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;

    public class FacebookAndroid : IFacebook
    {
        private AndroidJavaClass facebookAndroidClass;
        private FacebookCallback facebookCallback;
        private string version;

        public FacebookAndroid()
        {
            facebookAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGFacebookUnity");
            facebookCallback = new FacebookCallback();
            version = facebookAndroidClass.GetStatic<string>("VERSION");
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
            facebookAndroidClass.CallStatic("nmg_facebook_requestMyProfile", handlerNum);
        }

        public void RequestFriends(Facebook.RequestFriendsDelegate callback)
        {
            int handlerNum = facebookCallback.SetRequestFriendsCallback(callback);
            facebookAndroidClass.CallStatic("nmg_facebook_requestFriends", handlerNum);
        }

        public void InviteFriends(string message, string title, Facebook.InviteFriendsDelegate callback)
        {
            int handlerNum = facebookCallback.SetInviteFriendsCallback(callback);
            facebookAndroidClass.CallStatic("nmg_facebook_inviteFriends", message, title, handlerNum);
        }

        public void RequestInviters(Facebook.RequestInvitersDelegate callback)
        {
            int handlerNum = facebookCallback.SetRequestInvitersCallback(callback);
            facebookAndroidClass.CallStatic("nmg_facebook_requestInviters", handlerNum);
        }

        public void DeleteInviters(List<string> facebookIdList, Facebook.DeleteInvitersDelegate callback)
        {
            int handlerNum = facebookCallback.SetDeleteInvitersCallback(callback);
            string facebookIdJson = Internal.Utils.ToJson(facebookIdList);
            facebookAndroidClass.CallStatic("nmg_facebook_deleteInviters", facebookIdJson, handlerNum);
        }

        public void PostPhoto(string message, Texture2D texture, Facebook.PostPhotoDelegate callback)
        {
            byte[] bytes = texture.EncodeToPNG();
            string imagePath = null;
            imagePath = Application.persistentDataPath + "/PostPhoto.png";
            File.WriteAllBytes(imagePath, bytes);

            int handlerNum = facebookCallback.SetPostPhotoCallback(callback);
            facebookAndroidClass.CallStatic("nmg_facebook_postPhoto", message, imagePath, handlerNum);

        }

        public void PostStatusUpdate(string message, string name, string picture, string link, string caption, string description, Facebook.PostStatusUpdateDelegate callback)
        {
            int handlerNum = facebookCallback.SetPostStatusUpdateCallback(callback);
            facebookAndroidClass.CallStatic("nmg_facebook_postStatusUpdateWithMessage", message, name, picture, link, caption, description, handlerNum);
        }

        public void PostStatusUpdate(string name, string picture, string link, string caption, string description, Dictionary<string, string> extras, Facebook.PostStatusUpdateDelegate callback)
        {
            string extrasJson = Internal.Utils.ToJson(extras);

            int handlerNum = facebookCallback.SetPostStatusUpdateCallback(callback);
            facebookAndroidClass.CallStatic("nmg_facebook_postStatusUpdate", name, picture, link, caption, description, extrasJson, handlerNum);
        }

        public void AddPermissions(List<string> permissions)
        {
            string permissionsJson = Internal.Utils.ToJson(permissions);

            facebookAndroidClass.CallStatic("nmg_facebook_addPermissions", permissionsJson);
        }
    }
}
#endif