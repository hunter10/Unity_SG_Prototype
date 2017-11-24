namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS.Internal;

    public class EveryNetmarbleCallback
    {
        public int SetRequestMyProfileCalblack(EveryNetmarble.RequestMyProfileDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[EveryNetmarbleCallback] RequestMyProfileCalblack: " + message.ToString());

                Result result = message.GetResult();
                EveryNetmarbleProfile profile = null;
                IDictionary profileDic = message.GetDictionary("everyNetmarbleProfile");
                if (null != profileDic)
                {
                    string playerId = profileDic.GetString("playerId");
                    string everyNetmarbleId = profileDic.GetString("everyNetmarbleId");
                    string nickname = profileDic.GetString("nickname");
                    string profileImageUrl = profileDic.GetString("profileImageUrl");
                    string profileThumbnailImageUrl = profileDic.GetString("profileThumbnailImageUrl");
                    string statusMessage = profileDic.GetString("statusMessage");
                    profile = new EveryNetmarbleProfile(playerId, everyNetmarbleId, nickname, profileImageUrl, profileThumbnailImageUrl, statusMessage);
                }

                if (null != callback)
                    callback(result, profile);

            });

            return handlerNum;
        }

        public int SetRequestFriendsCallback(EveryNetmarble.RequestFriendsDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[EveryNetmarbleCallback] RequestFriendsCallback: " + message.ToString());

                Result result = message.GetResult();

                IList appFriendProfileList = message.GetList("appFriendProfileList");
                List<EveryNetmarbleProfile> appList = null;
                if (null != appFriendProfileList)
                {
                    appList = new List<EveryNetmarbleProfile>();
                    foreach (IDictionary profileDic in appFriendProfileList)
                    {
                        string playerId = profileDic.GetString("playerId");
                        string everyNetmarbleId = profileDic.GetString("everyNetmarbleId");
                        string nickname = profileDic.GetString("nickname");
                        string profileImageUrl = profileDic.GetString("profileImageUrl");
                        string profileThumbnailImageUrl = profileDic.GetString("profileThumbnailImageUrl");
                        string statusMessage = profileDic.GetString("statusMessage");
                        appList.Add(new EveryNetmarbleProfile(playerId, everyNetmarbleId, nickname, profileImageUrl, profileThumbnailImageUrl, statusMessage));
                    }
                }

                IList nonAppFriendProfileList = message.GetList("nonAppFriendProfileList");
                List<EveryNetmarbleProfile> nonappList = null;
                if (null != nonAppFriendProfileList)
                {
                    nonappList = new List<EveryNetmarbleProfile>();
                    foreach (IDictionary profileDic in nonAppFriendProfileList)
                    {
                        string playerId = profileDic.GetString("playerId");
                        string everyNetmarbleId = profileDic.GetString("everyNetmarbleId");
                        string nickname = profileDic.GetString("nickname");
                        string profileImageUrl = profileDic.GetString("profileImageUrl");
                        string profileThumbnailImageUrl = profileDic.GetString("profileThumbnailImageUrl");
                        string statusMessage = profileDic.GetString("statusMessage");
                        nonappList.Add(new EveryNetmarbleProfile(playerId, everyNetmarbleId, nickname, profileImageUrl, profileThumbnailImageUrl, statusMessage));
                    }
                }

                if (null != callback)
                    callback(result, appList, nonappList);
            });

            return handlerNum;
        }
    }
}