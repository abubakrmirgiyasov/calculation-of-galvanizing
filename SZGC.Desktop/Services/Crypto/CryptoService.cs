using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using SZGC.Desktop.Services.Interfaces;

namespace SZGC.Desktop.Services.Crypto
{
    public class CryptoService : ICryptoService
    {
        private string[] _strCharacters =
        {
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
            "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
            "1","2","3","4","5","6","7","8","9","0",
        };

        public string Encrypt(string text, string salt)
        {
            byte[] cleatBytes = Encoding.Unicode.GetBytes(text);
            byte[] buffer = { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(salt, buffer);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cleatBytes, 0, cleatBytes.Length);
                        cs.Close();
                    }

                    text = Convert.ToBase64String(ms.ToArray());
                }
            }

            return text;
        }

        public string GetSalt(int count)
        {
            var random = new Random();

            int p = 0;
            string strPass = "";

            for (int i = 0; i <= count; i++)
            {
                p = random.Next(0, 35);
                strPass += _strCharacters[p];
            }

            return strPass.ToLower();
        }
    }
}
