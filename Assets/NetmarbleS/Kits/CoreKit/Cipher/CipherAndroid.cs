#if UNITY_ANDROID
namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public class CipherAndroid : ICipher
    {
        private AndroidJavaClass cipherAndroidClass;

        public CipherAndroid()
        {
            cipherAndroidClass = new AndroidJavaClass("com.netmarble.unity.NMGCipherUnity");
        }

        public string Encrypt(string cleartext, CipherType type)
        {
            return cipherAndroidClass.CallStatic<string>("nmg_cipher_encrypt", cleartext, (int)type);
        }

        public string Decrypt(string encrypted, CipherType type)
        {
            return cipherAndroidClass.CallStatic<string>("nmg_cipher_decrypt", encrypted, (int)type);
        }
    }
}
#endif