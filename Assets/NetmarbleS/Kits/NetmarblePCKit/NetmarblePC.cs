namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

	public class NetmarblePC
    {
        public static int CHANNEL_CODE = 15;
        public const int DIFFERENT_CI = 0x9001;

		public delegate void AuthenticateDelegate(Result result, string playerID, string publicToken);

		public static void Authenticate(AuthenticateDelegate callback)
        {
			Log.Debug("[NetmarblePC] Authenticate");
			netmarblePCImpl.Authenticate(callback);
        }

        private static readonly string VERSION = "1.0.2.4000";


		private static INetmarblePC netmarblePC;
		private static INetmarblePC netmarblePCImpl
        {
            get
            {
				if (null == netmarblePC)
                {
					netmarblePC = NetmarbleS.Internal.ClassLoader.GetTargetClass("NetmarblePC") as INetmarblePC;
					Log.Debug("[NetmarblePC] NMGUnity Version : " + VERSION + "(" + netmarblePC.VERSION + ")");
                }
				return netmarblePC;
            }
        }
    }
}