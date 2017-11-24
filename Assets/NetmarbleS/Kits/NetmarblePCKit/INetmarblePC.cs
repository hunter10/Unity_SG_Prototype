namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface INetmarblePC
    {
        string VERSION { get; }
        void Authenticate(NetmarblePC.AuthenticateDelegate callback);
    }
}