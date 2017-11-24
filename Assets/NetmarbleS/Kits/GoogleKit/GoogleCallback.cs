namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS.Internal;


    public class GoogleCallback
    {
        public int SetAuthenticateCalblack(Google.AuthenticateDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[GoogleCallback] AuthenticateCalblack: " + message.ToString());

                Result result = message.GetResult();
                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetRequestMyProfileCalblack(Google.RequestMyProfileDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[GoogleCallback] RequestMyProfileCalblack: " + message.ToString());

                Result result = message.GetResult();
                GoogleProfile profile = null;
                IDictionary profileDic = message.GetDictionary("googleProfile");
                if (null != profileDic)
                {
                    string playerId = profileDic.GetString("playerId");
                    string googleId = profileDic.GetString("googleId");
                    string nickname = profileDic.GetString("nickname");
                    string profileImageUrl = profileDic.GetString("profileImageUrl");
                    profile = new GoogleProfile(playerId, googleId, nickname, profileImageUrl);
                }

                if (null != callback)
                    callback(result, profile);

            });

            return handlerNum;
        }

        public int SetRequestFriendsCallback(Google.RequestFriendsDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[GoogleCallback] RequestFriendsCallback: " + message.ToString());

                Result result = message.GetResult();

                IList appFriendProfileList = message.GetList("appFriendProfileList");
                List<GoogleProfile> appList = null;
                if (null != appFriendProfileList)
                {
                    appList = new List<GoogleProfile>();
                    foreach (IDictionary profileDic in appFriendProfileList)
                    {
                        string playerId = profileDic.GetString("playerId");
                        string googleId = profileDic.GetString("googleId");
                        string nickname = profileDic.GetString("nickname");
                        string profileImageUrl = profileDic.GetString("profileImageUrl");
                        appList.Add(new GoogleProfile(playerId, googleId, nickname, profileImageUrl));
                    }
                }

                IList nonAppFriendProfileList = message.GetList("nonAppFriendProfileList");
                List<GoogleProfile> nonappList = null;
                if (null != nonAppFriendProfileList)
                {
                    nonappList = new List<GoogleProfile>();
                    foreach (IDictionary profileDic in nonAppFriendProfileList)
                    {
                        string playerId = profileDic.GetString("playerId");
                        string googleId = profileDic.GetString("googleId");
                        string nickname = profileDic.GetString("nickname");
                        string profileImageUrl = profileDic.GetString("profileImageUrl");
                        nonappList.Add(new GoogleProfile(playerId, googleId, nickname, profileImageUrl));
                    }
                }

                if (null != callback)
                    callback(result, appList, nonappList);
            });

            return handlerNum;
        }

    }
}