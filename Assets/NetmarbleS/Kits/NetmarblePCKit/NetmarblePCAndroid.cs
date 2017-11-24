#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

	public class NetmarblePCAndroid : INetmarblePC
    {
        private AndroidJavaClass netmarblePCClass;
		private NetmarblePCCallback netmarblePCCallback;
        private string version;

		public NetmarblePCAndroid()
        {
			netmarblePCClass = new AndroidJavaClass("com.netmarble.unity.NMGNetmarblePCUnity");
			netmarblePCCallback = new NetmarblePCCallback();
            version = netmarblePCClass.GetStatic<string>("VERSION");
        }

        public string VERSION
        {
            get
            {
                return version;
            }
        }

		public void Authenticate(NetmarblePC.AuthenticateDelegate callback)
		{
			int handlerNum = netmarblePCCallback.SetAuthenticateCallback(callback);
			netmarblePCClass.CallStatic("nmg_netmarblePC_authenticate", handlerNum);
		}
    }
}
#endif