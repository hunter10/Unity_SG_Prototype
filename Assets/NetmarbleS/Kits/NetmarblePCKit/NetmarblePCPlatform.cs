namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

	public class NetmarblePCPlatform : INetmarblePC
    {

        public string VERSION
        {
            get { return "0.0.0.0000"; }
        }

		public void Authenticate(NetmarblePC.AuthenticateDelegate callback)
        {
            
        }
    }
}