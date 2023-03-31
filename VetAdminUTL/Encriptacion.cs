using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VetAdminUTL
{

    public static class Encriptacion
    {

        public static string EncriptarContrasenia(string sTexto)
        {
            return BCrypt.Net.BCrypt.HashPassword(sTexto);
        }

        public static bool VerificarContrasenia(string sTexto, string sHash)
        {
            return BCrypt.Net.BCrypt.Verify(sTexto, sHash);
        }
        public static string Encriptar(string sTexto)
        {
            using (var rsa = RSA.Create())
            {
                var encrypted = EncryptBytes(Encoding.UTF8.GetBytes(sTexto), rsa.ExportParameters(false));
                var plainBytes = DecryptBytes(encrypted, rsa.ExportParameters(true));
                var roundtrip = Encoding.UTF8.GetString(plainBytes);
                return Convert.ToBase64String(encrypted);
            }
        }

        public static string Desencriptar(string sTexto)
        {
            using (var rsa = RSA.Create())
            {
                var encrypted = Convert.FromBase64String(sTexto);
                var plainBytes = DecryptBytes(encrypted, rsa.ExportParameters(true));
                return Encoding.UTF8.GetString(plainBytes);
            }
        }
        static byte[] EncryptBytes(byte[] DataToEncrypt, RSAParameters RSAKeyInfo)
        {
            try
            {
                byte[] encryptedData;
                using (var rsa = RSA.Create())
                {

                    rsa.ImportParameters(RSAKeyInfo);

                    encryptedData = rsa.Encrypt(DataToEncrypt, RSAEncryptionPadding.OaepSHA512);
                }
                return encryptedData;
            }

            catch (CryptographicException e)
            {
                return null;
            }
        }

        static byte[] DecryptBytes(byte[] DataToDecrypt, RSAParameters RSAKeyInfo)
        {
            try
            {
                byte[] decryptedData;

                using (var rsa = RSA.Create())
                {

                    rsa.ImportParameters(RSAKeyInfo);

                    decryptedData = rsa.Decrypt(DataToDecrypt, RSAEncryptionPadding.OaepSHA512);
                }
                return decryptedData;
            }

            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
    }
}
