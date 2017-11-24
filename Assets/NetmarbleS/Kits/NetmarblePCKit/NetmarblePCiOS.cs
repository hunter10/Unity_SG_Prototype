#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

	public class NetmarblePCiOS : INetmarblePC
    {
        [DllImport("__Internal")]
        public static extern IntPtr nmg_netmarblePC_version();
        [DllImport("__Internal")]
        public static extern void nmg_netmarblePC_authenticate(int handlerNum);

		private NetmarblePCCallback netmarblePCCallback;
        private string version;
		public NetmarblePCiOS()
        {
			netmarblePCCallback = new NetmarblePCCallback();
			version = Marshal.PtrToStringAuto(nmg_netmarblePC_version());
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
			nmg_netmarblePC_authenticate(handlerNum);
        }
		
    }
}
#endif