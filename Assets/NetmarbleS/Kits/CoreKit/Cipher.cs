namespace NetmarbleS
{
    using UnityEngine;
    using System.Collections;

    public enum CipherType
    {
        /**
         * RC4_40.
         */
        RC4_40 = 0,
        /**
         * AES_128_CBC.
         */
        AES_128_CBC
    }

    public class Cipher
    {
        private CipherType cipherType;
        private string secretKey;
        private string aesInitialVector;

        public Cipher(CipherType cipherType, string secretKey, string aesInitialVector)
        {
            this.cipherType = cipherType;
            this.secretKey = secretKey;
            this.aesInitialVector = aesInitialVector;
        }

        public override string ToString()
        {
            return "[Cipher] CipherType(" + cipherType + "), SecretKey(" + secretKey + "), AESInitialVector(" + aesInitialVector + ")";
        }

        /**
         * @brief Gets the cipher type.
         * 
         * @return Cipher type.
         * @see CipherType
         */
        public CipherType CipherType
        {
            get
            {
                return cipherType;
            }
        }

        /**
         * @brief Gets the secret key.
         * 
         * @return Secret key.
         */
        public string SecretKey
        {
            get
            {
                return secretKey;
            }
        }

        /**
         * @brief Gets the AES IV(Initial vector).
         * 
         * @return AES IV(Initial vector).
         */
        public string AESInitialVector
        {
            get
            {
                return aesInitialVector;
            }
        }

        /**
         * @brief Encrypts the data string.
         *
         * @param cleartext Raw data string.
         * @return Encrypted string.
         */
        public string Encrypt(string cleartext)
        {
            Log.Debug("[Cipher] Encrypt");
            return CipherImpl.Encrypt(cleartext, cipherType);
        }

        /**
         * @brief Decrypts the data string.
         *
         * @param encrypted Encrypted data string.
         * @return Decrypted string.
         */
        public string Decrypt(string encrypted)
        {
            Log.Debug("[Cipher] Decrypt");
        
            return CipherImpl.Decrypt(encrypted, cipherType);
        }

        private ICipher cipher;
        private ICipher CipherImpl
        {
            get
            {
                if (null == cipher)
                {
                    cipher = Internal.ClassLoader.GetTargetClass("Cipher") as ICipher;
                }

                return cipher;
            }
        }
    }
}
