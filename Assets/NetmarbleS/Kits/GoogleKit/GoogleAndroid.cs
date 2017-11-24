#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class GoogleAndroid : IGoogle
    {
        private AndroidJavaClass googleAndroidClass;
        private GoogleCallback googleCallback;
        private string version;

        public GoogleAndroid()
        {
            googleAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGGoogleUnity");
            googleCallback = new GoogleCallback();
            version = googleAndroidClass.GetStatic<string>("VERSION");
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

        public void SetAddPlusScope(bool add)
        {
            googleAndroidClass.CallStatic("nmg_google_setAddPlusScope", add);
        }

        public bool GetAddPlusScope()
        {
            return googleAndroidClass.CallStatic<bool>("nmg_google_getAddPlusScope");
        }

        public void Authenticate(Google.AuthenticateDelegate callback)
        {
            int handlerNum = googleCallback.SetAuthenticateCalblack(callback);
            googleAndroidClass.CallStatic("nmg_google_authenticate", handlerNum);
        }

        public void RequestMyProfile(Google.RequestMyProfileDelegate callback)
        {
            int handlerNum = googleCallback.SetRequestMyProfileCalblack(callback);
            googleAndroidClass.CallStatic("nmg_google_requestMyProfile", handlerNum);
        }

        public void RequestFriends(Google.RequestFriendsDelegate callback)
        {
            int handlerNum = googleCallback.SetRequestFriendsCallback(callback);
            googleAndroidClass.CallStatic("nmg_google_requestFriends", handlerNum);
        }
    }
}
#endif