namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class GoogleProfile
    {
        private string playerId;
        private string googleId;
        private string nickname;
        private string profileImageUrl;

        public GoogleProfile(string playerId, string googleId, string nickname, string profileImageUrl)
        {
            this.playerId = playerId;
            this.googleId = googleId;
            this.nickname = nickname;
            this.profileImageUrl = profileImageUrl;
        }

        public override string ToString()
        {
            return "[GoogleProfile] PlayerId(" + playerId + "), GoogleId(" + googleId + "), Nickname(" + nickname + "), "
                                                        + "ProfileImageUrl(" + profileImageUrl + ")";
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
         * @brief Gets Google+ Id.
         * 
         * @return Google+ Id.
         */
        public string GoogleID
        {
            get
            {
                return googleId;
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

    }
    public class Google
    {
        public static int CHANNEL_CODE = 5;

        public delegate void AuthenticateDelegate(Result reault);

        /**
        * @brief RequestMyProfile callback delegate.
        * 
        * @param result Reuslt.
        * @param googleProfile Google+ profile.
        * @see Result
        * @see GoogleProfile 
        */
        public delegate void RequestMyProfileDelegate(Result result, GoogleProfile googleProfile);

        /**
         * @brief RequestFriends callback delegate.
         * 
         * @param result Reuslt.
         * @param appFriendProfileList The list of Google+ profile of played user.
         * @param nonAppFriendProfileList The list of Google+ profile of unplayed user.
         * @see Result
         * @see GoogleProfile 
         */
        public delegate void RequestFriendsDelegate(Result result, List<GoogleProfile> appFriendProfileList, List<GoogleProfile> nonAppFriendProfileList);

        /**
         * @brief GooglePlus scope 사용 여부 설정하기. signIn 전에 호출되어야 함.
         * 
         * @param add 사용 여부 true / false
         */
        public static void SetAddPlusScope(bool add)
        {
            Log.Debug("[Google] SetAddPlusScope");
            GoogleImpl.SetAddPlusScope(add);
        }

        /**
         * @brief GooglePlus scope 사용 여부 가져오기
         * 
         * @return 사용 여부 true / false
         */
        public static bool GetAddPlusScope()
        {
            Log.Debug("[Google] GetAddPlusScope");
            return GoogleImpl.GetAddPlusScope();
        }

        public static void Authenticate(AuthenticateDelegate callback)
        {
            Log.Debug("[Google] Authenticate");
            GoogleImpl.Authenticate(callback);
        }

        /**
         * @brief Request my profile.
         * 
         * @param callback Callback to deal with a reponse to the request.
         * @see RequestMyProfileDelegate
         */
        public static void RequestMyProfile(RequestMyProfileDelegate callback)
        {
            Log.Debug("[Google] RequestMyProfile");
            GoogleImpl.RequestMyProfile(callback);
        }

        /**
         * @brief Request Google+ frineds.
         * 
         * @param callback Callback to deal with a reponse to the request.
         * @see RequestFriendsDelegate
         */
        public static void RequestFriends(RequestFriendsDelegate callback)
        {
            Log.Debug("[Google] RequestFriends");
            GoogleImpl.RequestFriends(callback);
        }

        private static readonly string VERSION = "1.1.0.4000";
        private static IGoogle google;
        private static IGoogle GoogleImpl
        {
            get
            {
                if (null == google)
                {
                    google = NetmarbleS.Internal.ClassLoader.GetTargetClass("Google") as IGoogle;
                    Log.Debug("[Google] NMGUnity Version : " + VERSION + "(" + google.VERSION + ")");
                }
                return google;
            }
            

        }
       
    }
}