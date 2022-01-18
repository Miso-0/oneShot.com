using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Text;

namespace OneShot.com
{
    public class EncryptIDStrings
    {
        private static byte[] KEY;
        private static byte[] IV;

        public EncryptIDStrings()
        {
            var tripleDes = new TripleDESCryptoServiceProvider();
            KEY = tripleDes.Key;
            IV = tripleDes.IV;
        }

        public string Encrypt(string text)
        {
            var buffer = Encoding.UTF8.GetBytes(text);
            var tripleDas = new TripleDESCryptoServiceProvider()
            {
                IV = IV,
                Key = KEY,
            };
            ICryptoTransform transform = tripleDas.CreateEncryptor();
            var ciphertext = transform.TransformFinalBlock(buffer, 0, buffer.Length);
            return Convert.ToBase64String(ciphertext);
        }

        public string Decrypt(string encryptedText)
        {
            
            var buffer = Convert.FromBase64String(encryptedText.Trim());
            var tripleDes = new TripleDESCryptoServiceProvider()
            {
                IV = IV,
                Key = KEY,
            };
            ICryptoTransform transform = tripleDes.CreateDecryptor();
            var plainText = transform.TransformFinalBlock(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(plainText);
        }
    }
}