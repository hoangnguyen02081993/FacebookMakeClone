using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MakeCloneFacebookApp.Helpers
{
    public static class StringHelper
    {
        public static string Encrypt3DES(this string source, string key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Encoding.UTF8.GetBytes(source);

            string encoded =
                Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return encoded;
        }
        public static string Decrypt3DES(this string encodedText, string key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Convert.FromBase64String(encodedText);

            string plaintext = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return plaintext;
        }
        public static string StringEndcoder(this string input)
        {
            string result = string.Empty;

            result += "ps";

            for (int i = 0; i < input.Length; i++)
            {
                char tmp = input.Substring(i, 1).ToCharArray()[0];
                result += (char)((tmp * 3 - 50) / 2 + 128);
                result += (char)((tmp * 4 - 50) / 3 + 64);
                result += (char)((tmp >= 128) ? tmp - 128 : tmp + 128);
            }
            return result;
        }
        public static string StringDecoder(this string input)
        {
            string result = string.Empty;

            for (int i = 0; i < (input.Length - 2) / 3; i++)
            {
                char tmp = input.Substring(2 + i * 3, 3).ToCharArray()[2];
                result += (char)((tmp >= 128) ? tmp - 128 : tmp + 128);
            }
            return result;
        }
    }
}
