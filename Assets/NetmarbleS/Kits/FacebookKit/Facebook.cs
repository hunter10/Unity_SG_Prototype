namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class FacebookProfile
    {
        private string playerId;
        private string facebookId;
        private string name;

        public FacebookProfile(string playerId, string facebookId, string name)
        {
            this.playerId = playerId;
            this.facebookId = facebookId;
            this.name = name;
        }

        public override string ToString()
        {
            return "[FacebookProfile] PlayerId(" + playerId + "), FacebookId(" + facebookId + "), Name(" + name + ")";
        }

        /**
         * @brief Gets player Id.
         * 
         * @return Player Id.
         */
        public string PlayerID
        {
            get
            {
                return playerId;
            }
        }

        /**
         * @brief Gets Facebook Id.
         * 
         * @return Facebook Id.
         */
        public string FacebookID
        {
            get
            {
                return facebookId;
            }
        }

        /**
         * @brief Gets name.
         * 
         * @return Name.
         */
        public string Name
        {
            get
            {
                return name;
            }
        }

        /**
         * @brief Gets profile image URL.
         * 
         * @return Profile image URL.
         */
        public string ProfileImageURL
        {
            get
            {
                if (facebookId == null)
                    return null;

                return "http://graph.facebook.com/" + facebookId + "/picture?type=large";
            }
        }

        /**
         * @brief Gets profile thumbnail image URL.
         * 
         * @return Profile thumbnail image URL.
         */
        public string ProfileThumbnailImageURL
        {
            get
            {
                if (facebookId == null)
                    return null;

                return "http://graph.facebook.com/" + facebookId + "/picture?type=small";
            }
        }

        /**
         * @brief Gets profiile image URL.
         * 
         * @param isThumbnail thumbnail image.
         * 
         * @return Profiile image URL.
         */
        public string GetProfileImageURL(bool isThumbnail)
        {
            if (facebookId == null)
                return null;

            if (isThumbnail)
                return "http://graph.facebook.com/" + facebookId + "/picture?type=small";

            return "http://graph.facebook.com/" + facebookId + "/picture?type=large";
        }
    }
    public class Facebook
    {
        public static int CHANNEL_CODE = 1;
        
        /**
         * @brief RequestMyProfile callback delegate.
         * 
         * @param result Reuslt.
         * @param facebookProfile Facebook profile.
         * @see Result
         * @see FacebookProfile 
         */
        public delegate void RequestMyProfileDelegate(Result result, FacebookProfile facebookProfile);

        /**
         * @brief RequestFriends callback delegate.
         * 
         * @param result Reuslt.
         * @param facebookProfileList The list of Facebook profile.
         * @see Result
         */
        public delegate void RequestFriendsDelegate(Result result, List<FacebookProfile> facebookProfileList);

        /**
         * @brief InviteFriends callback delegate.
         * 
         * @param result Reuslt.
         * @param facebookIdList The list of Facebook Id whom send invite request to.
         * @see Result
         */
        public delegate void InviteFriendsDelegate(Result result, List<string> facebookIdList);

        /**
         * @brief RequestInviters callback delegate.
         * 
         * @param result Reuslt.
         * @param facebookProfileList The list of Facebook profile.
         * @see Result
         */
        public delegate void RequestInvitersDelegate(Result result, List<FacebookProfile> facebookProfileList);

        /**
         * @brief DeleteInviters callback delegate.
         * 
         * @param result Reuslt.
         * @see Result
         */
        public delegate void DeleteInvitersDelegate(Result result);

        /**
         * @brief PostPhoto callback delegate.
         * 
         * @param result Reuslt.
         * @see Result
         */
        public delegate void PostPhotoDelegate(Result result);

        /**
         * @brief PostStatusUpdate callback delegate.
         * 
         * @param result Reuslt.
         * @see Result
         */
        public delegate void PostStatusUpdateDelegate(Result result);

        /**
         * @brief Request my profile.
         * 
         * @param callback Callback to deal with a reponse to the request.
         * @see RequestMyProfileDelegate
         */
        public static void RequestMyProfile(RequestMyProfileDelegate callback)
        {
            Log.Debug("[Facebook] RequestMyProfile");
            FacebookImpl.RequestMyProfile(callback);
        }

        /**
         * @brief Request Facebook frineds.
         * 
         * @param callback Callback to deal with a reponse to the request.
         * @see RequestFriendsDelegate
         */
        public static void RequestFriends(RequestFriendsDelegate callback)
        {
            Log.Debug("[Facebook] RequestFriends");
            FacebookImpl.RequestFriends(callback);
        }

        /**
         * @brief Invite Facebook friends who doesn't play this application.
         * 
         * @param message Invite message.
         * @param title Facebook Invite dialog title.
         * @param callback Callback to deal with a reponse to the request.
         * @see InviteFriendsDelegate
         */
        public static void InviteFriends(string message, string title, InviteFriendsDelegate callback)
        {
            Log.Debug("[Facebook] InviteFriends message:" + message + ", title:" + title);
            FacebookImpl.InviteFriends(message, title, callback);
        }

        /**
         * @brief request the list of inviter who send invite request to me. 
         * 
         * @param callback Callback to deal with a reponse to the request.
         * @see InviteFBFriendsDelegate
         */
        public static void RequestInviters(RequestInvitersDelegate callback)
        {
            Log.Debug("[Facebook] RequestInviters");
            FacebookImpl.RequestInviters(callback);
        }

        /**
         * @brief Delete inviters in Facebook service.
         * 
         * @param playerIdList The list of player Id.
         * @param callback Callback to deal with a reponse to the request.
         * @see DeleteInvitersDelegate
         */
        public static void DeleteInviters(List<string> facebookIdList, DeleteInvitersDelegate callback)
        {
            Log.Debug("[Facebook] DeleteInviters");
            FacebookImpl.DeleteInviters(facebookIdList, callback);
        }

        /**
         * @brief Post photo.
         * 
         * @param message Message.
         * @param texture Image.
         * @param callback Callback to deal with a reponse to the request.
         * @see PostPhotoDelegate
         */
        public static void PostPhoto(string message, Texture2D texture, PostPhotoDelegate callback)
        {
            Log.Debug("[Facebook] PostPhoto [message:" + message + "]");
            FacebookImpl.PostPhoto(message, texture, callback);
        }

        /**
         * @brief Post status update.
         * 
         * @param message Message.
         * @param name Name.
         * @param picture Image URL.
         * @param link Link.
         * @param caption Caption.
         * @param description Description.
         * @param callback Callback to deal with a reponse to the request.
         * @see PostStatusUpdateDelegate
         */
        public static void PostStatusUpdate(string message, string name, string picture, string link, string caption, string description, PostStatusUpdateDelegate callback)
        {
            Log.Debug("[Facebook] PostStatusUpdate");
            FacebookImpl.PostStatusUpdate(message, name, picture, link, caption, description, callback);
        }
        /**
         * @brief Post status update.
         * 
         * @param name Name.
         * @param picture Image URL.
         * @param link Link.
         * @param caption Caption.
         * @param description Description.
         * @param extras Extras.
         * @param callback Callback to deal with a reponse to the request.
         * @see PostStatusUpdateDelegate
         */
        public static void PostStatusUpdate(string name, string picture, string link, string caption, string description, Dictionary<string, string> extras, PostStatusUpdateDelegate callback)
        {
            Log.Debug("[Facebook] PostStatusUpdate");
            FacebookImpl.PostStatusUpdate(name, picture, link, caption, description, extras, callback);
        }

        /**
         * @brief Add Permisions
         * 
         * @param permissions Permissions.
         */
        public static void AddPermissions(List<string> permissions)
        {
            Log.Debug("[Facebook] AddPermissions");
            FacebookImpl.AddPermissions(permissions);
        }

        private static readonly string VERSION = "1.0.0.4000";
        private static IFacebook facebook;
        private static IFacebook FacebookImpl
        {
            get
            {
                if(null == facebook)
                {
                    facebook = Internal.ClassLoader.GetTargetClass("Facebook") as IFacebook;
                    Log.Debug("[Facebook] NMGUnity Version : " + VERSION + "(" + facebook.VERSION + ")");
                }
                return facebook;
            }
        }
    }
}