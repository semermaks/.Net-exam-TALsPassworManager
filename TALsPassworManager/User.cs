using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TALsPassworManager
{
    internal static class User
    {
        private const int Keysize = 256;

        private const int DerivationIterations = 1000;
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }

        public static string Encrypt(string plainText, string passPhrase = "TALs The Best Programm")
        {
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }
        public static string  Name { get; set; }
        public static string  Surname { get; set; }
        public static string  FatherName { get; set; }
        public static string  Login { get; set; }
        public static string  Password { get; set; }
        public static DateTime  DateOFBirthday { get; set; }

        public static Dictionary<string, string> Passwords = new Dictionary<string, string>();
        public static void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(User.Login))
            {
                sw.WriteLine((Encrypt($"{User.Name} {User.Surname} {User.FatherName} {User.DateOFBirthday.ToShortDateString()} {User.Password}")));
                foreach (var item in User.Passwords)
                {
                    sw.WriteLine(Encrypt($"{item.Key} {item.Value}"));
                }
            }
        }

    }
}
