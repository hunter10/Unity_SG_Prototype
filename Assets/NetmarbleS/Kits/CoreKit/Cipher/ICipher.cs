namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public interface ICipher
    {
        string Encrypt(string cleartext, CipherType type);
        string Decrypt(string encrypted, CipherType type);
    }
}