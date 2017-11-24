#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class GoogleiOS : IGoogle
    {
        public string VERSION
        {
            get
            {
                return "-";
            }
        }

        public void SetAddPlusScope(bool add)
        {
            Log.Debug("[GoogleiOS] not supported API");
        }

        public bool GetAddPlusScope()
        {
            Log.Debug("[GoogleiOS] not supported API");
            return false;
        }

        public void Authenticate(Google.AuthenticateDelegate callback)
        {
            Log.Debug("[GoogleiOS] not supported API");
            if (null != callback)
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.NOT_SUPPORTED, "Not supported channel");
                callback(result);
            }
        }

        public void RequestMyProfile(Google.RequestMyProfileDelegate callback)
        {
            Log.Debug("[GoogleiOS] not supported API");
            if (null != callback)
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.NOT_SUPPORTED, "Not supported channel");
                callback(result, null);
            }
        }

        public void RequestFriends(Google.RequestFriendsDelegate callback)
        {
            Log.Debug("[GoogleiOS] not supported API");
            if (null != callback)
            {
                Result result = new Result(Result.NETMARBLES_DOMAIN, Result.NOT_SUPPORTED, "Not supported channel");
                callback(result, null, null);
            }
        }
    }
}
#endif