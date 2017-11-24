#if UNITY_IPHONE || UNITY_IOS
namespace NetmarbleS
{
    using UnityEngine;
	using System;
    using System.Collections;
	using System.Runtime.InteropServices;

    public class CipheriOS : ICipher
    {

		[DllImport("__Internal")] 
		public static extern IntPtr nmg_cipher_encrypt(string cleartext, int cipherTypeNum);
		[DllImport("__Internal")] 
		public static extern IntPtr nmg_cipher_decrypt(string encrypted, int cipherTypeNum);

		public string Encrypt(string cleartext, CipherType type)
		{
			return Marshal.PtrToStringAuto(nmg_cipher_encrypt(cleartext, (int)type));
		}

		public string Decrypt(string encrypted, CipherType type)
		{
			return Marshal.PtrToStringAuto(nmg_cipher_decrypt(encrypted, (int)type));
		}
    }
}
#endif