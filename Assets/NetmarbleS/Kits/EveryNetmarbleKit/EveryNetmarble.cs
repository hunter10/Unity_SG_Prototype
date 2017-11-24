namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class EveryNetmarbleProfile
    {

        private string playerId;
        private string everyNetmarbleId;
        private string nickname;
        private string profileImageUrl;
        private string profileThumbnailImageUrl;
        private string statusMessage;

        public EveryNetmarbleProfile(string playerId, string everyNetmarbleId, string nickname, string profileImageUrl, string profileThumbnailImageUrl, string statusMessage)
        {
            this.playerId = playerId;
            this.everyNetmarbleId = everyNetmarbleId;
            this.nickname = nickname;
            this.profileImageUrl = profileImageUrl;
            this.profileThumbnailImageUrl = profileThumbnailImageUrl;
            this.statusMessage = statusMessage;
        }

        public override string ToString()
        {
            return "[EveryNetmarbleProfile] PlayerId(" + playerId + "), EveryNetmarbleId(" + everyNetmarbleId + "), Nickname("
                            + nickname + "), ProfileImageUrl(" + profileImageUrl + "), profileThumbnailImageUrl(" + profileThumbnailImageUrl + ") StatusMessage(" + statusMessage + ")";
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
         * @brief Gets EveryNetmarble Id.
         * 
         * @return EveryNetmarble Id.
         */
        public string EveryNetmarbleID
        {
            get
            {
                return everyNetmarbleId;
            }
        }

        /**
         * @brief Gets nickname.
         * 
         * @return Nickname.
         */
        public string Nickname
        {
            get
            {
                return nickname;
            }
        }

        /**
         * @brief Gets profile image Url.
         * 
         * @return profile image Url.
         */
        public string ProfileImageUrl
        {
            get
            {
                return profileImageUrl;
            }
        }
        /**
         * @brief Gets profile thumbnail image Url.
         * 
         * @return profile thumbnail image Url.
         */
        public string ProfileThumbnailImageUrl
        {
            get
            {
                return profileThumbnailImageUrl;
            }
        }

        /**
         * @brief Gets status message.
         * 
         * @return Status message.
         */
        public string StatusMessage
        {
            get
            {
                return statusMessage;
            }
        }

    }
    public class EveryNetmarble
    {
        public static int CHANNEL_CODE = 0;

        /**
        * @brief RequestMyProfile callback delegate.
        * 
        * @param result Reuslt.
        * @param everyNetmarbleProfile EveryNetmarble profile.
        * @see Result
        * @see EveryNetmarbleProfile 
        */
        public delegate void RequestMyProfileDelegate(Result result, EveryNetmarbleProfile everyNetmarbleProfile);

        /**
         * @brief RequestFriends callback delegate.
         * 
         * @param result Reuslt.
         * @param appFriendProfileList The list of EveryNetmarble profile of played user.
         * @param nonAppFriendProfileList The list of EveryNetmarble profile of unplayed user.
         * @see Result
         * @see EveryNetmarbleProfile 
         */
        public delegate void RequestFriendsDelegate(Result result, List<EveryNetmarbleProfile> appFriendProfileList, List<EveryNetmarbleProfile> nonAppFriendProfileList);

        /**
         * @brief Request my profile.
         * 
         * @param callback Callback to deal with a reponse to the request.
         * @see RequestMyProfileDelegate
         */
        public static void RequestMyProfile(RequestMyProfileDelegate callback)
        {
            Log.Debug("[EveryNetmarble] RequestMyProfile");
            EveryNetmarbleImpl.RequestMyProfile(callback);
        }

        /**
         * @brief Request EveryNetmarble frineds.
         * 
         * @param callback Callback to deal with a reponse to the request.
         * @see RequestFriendsDelegate
         */
        public static void RequestFriends(RequestFriendsDelegate callback)
        {
            Log.Debug("[EveryNetmarble] RequestFriends");
            EveryNetmarbleImpl.RequestFriends(callback);
        }

        public static void SetEnableAuthenticationView(bool enable)
        {
            Log.Debug("[EveryNetmarble] SetEnableAuthenticationView");
            EveryNetmarbleImpl.SetEnableAuthenticationView(enable);
        }

        private static readonly string VERSION = "1.1.0.4000";

        private static IEveryNetmarble everyNetmarble;
        private static IEveryNetmarble EveryNetmarbleImpl
        {
            get
            {
                if (null == everyNetmarble)
                {
                    everyNetmarble = NetmarbleS.Internal.ClassLoader.GetTargetClass("EveryNetmarble") as IEveryNetmarble;
                    Log.Debug("[EveryNetmarble] NMGUnity Version : " + VERSION + "(" + everyNetmarble.VERSION + ")");
                }
                return everyNetmarble;
            }
        }
    }
}