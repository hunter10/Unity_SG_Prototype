namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using NetmarbleS.Internal;

    public class FacebookCallback
    {
        public int SetRequestMyProfileCallback(Facebook.RequestMyProfileDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[FacebookCallback] RequestMyProfileCallback: " + message);

                Result result = message.GetResult();
                FacebookProfile profile = null;
                IDictionary profileDic = message.GetDictionary("facebookProfile");
                if (null != profileDic)
                {
                    string playerId = profileDic.GetString("playerId");
                    string facebookId = profileDic.GetString("facebookId");
                    string name = profileDic.GetString("name");
                    profile = new FacebookProfile(playerId, facebookId, name);
                }

                if (null != callback)
                    callback(result, profile);
            });

            return handlerNum;
        }

        public int SetRequestFriendsCallback(Facebook.RequestFriendsDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[FacebookCallback] RequestFriendsCallback: " + message);

                Result result = message.GetResult();
                IList facebookProfileList = message.GetList("facebookProfileList");

                List<FacebookProfile> profileList = null;
                if (facebookProfileList != null)
                {
                    profileList = new List<FacebookProfile>();
                    foreach (IDictionary profileDic in facebookProfileList)
                    {
                        string playerId = profileDic.GetString("playerId");
                        string facebookId = profileDic.GetString("facebookId");
                        string name = profileDic.GetString("name");
                        profileList.Add(new FacebookProfile(playerId, facebookId, name));
                    }
                }

                if (null != callback)
                    callback(result, profileList);
            });

            return handlerNum;
        }

        public int SetInviteFriendsCallback(Facebook.InviteFriendsDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[FacebookCallback] InviteFriendsCallback: " + message);

                Result result = message.GetResult();
                List<string> idList = null;
                IList facebookIdList = message.GetList("facebookIdList");
                if (null != facebookIdList)
                {
                    idList = new List<string>();
                    foreach (object id in facebookIdList)
                        idList.Add(System.Convert.ToString(id));
                }

                if (null != callback)
                    callback(result, idList);
            });

            return handlerNum;
        }
        public int SetRequestInvitersCallback(Facebook.RequestInvitersDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[FacebookCallback] RequestInvitersCallback: " + message);

                Result result = message.GetResult();
                IList facebookProfileList = message.GetList("facebookProfileList");

                List<FacebookProfile> profileList = null;
                if (facebookProfileList != null)
                {
                    profileList = new List<FacebookProfile>();
                    foreach (IDictionary profileDic in facebookProfileList)
                    {
                        string playerId = profileDic.GetString("playerId");
                        string facebookId = profileDic.GetString("facebookId");
                        string name = profileDic.GetString("name");
                        profileList.Add(new FacebookProfile(playerId, facebookId, name));
                    }
                }

                if (null != callback)
                    callback(result, profileList);
            });

            return handlerNum;
        }

        public int SetDeleteInvitersCallback(Facebook.DeleteInvitersDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[FacebookCallback] DeleteInvitersCallback: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetPostPhotoCallback(Facebook.PostPhotoDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[FacebookCallback] PostPhotoCallback: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }

        public int SetPostStatusUpdateCallback(Facebook.PostStatusUpdateDelegate callback)
        {
            if (null == callback)
                return 0;

            int handlerNum = CallbackManager.AddHandler(delegate(CallbackMessage message)
            {
                Log.Debug("[FacebookCallback] PostStatusUpdateCallback: " + message);

                Result result = message.GetResult();

                if (null != callback)
                    callback(result);
            });

            return handlerNum;
        }
    }
}