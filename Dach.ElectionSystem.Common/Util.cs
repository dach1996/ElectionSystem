using System;
using System.Security.Cryptography;
using System.Text;

namespace Dach.ElectionSystem.Common
{
    public static class Util
    {
        #region Encoding
        /// <summary>
        /// Aplica HasheoMD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetHashMD5(string input)
        {
            try
            {
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
            catch
            {
                return input;
            }
        }

        /// <summary>
        /// Aplica HasheoMD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSHA256(string input)
        {
            try
            {
                using (SHA256 sha256 = SHA256Managed.Create())
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] stream = null;
                    stream = sha256.ComputeHash(encoding.GetBytes(input));
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < stream.Length; i++)
                        sb.AppendFormat("{0:x2}", stream[i]);
                    return sb.ToString();
                }
            }
            catch
            {
                return input;
            }
        }

        /// <summary>
        /// Crea Hash 256 con Salt de seguridad
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string ComputeSHA256(string input, string salt)
        {
            using (SHA256 sha256 = SHA256Managed.Create())
            {
                byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                // Combine salt and input bytes
                byte[] saltedInput = new byte[saltBytes.Length + inputBytes.Length];
                saltBytes.CopyTo(saltedInput, 0);
                inputBytes.CopyTo(saltedInput, saltBytes.Length);
                byte[] hashedBytes = sha256.ComputeHash(saltedInput);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                    sb.AppendFormat("{0:x2}", hashedBytes[i]);
                return sb.ToString();
            }
        }

        /// <summary>
        /// Crea Hash 256 con Salt de seguridad
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static bool VerifyPasswordSHA256(string password, string input, string salt)
        {
            var hashInputSalt = String.Empty;
            using (SHA256 sha256 = SHA256Managed.Create())
            {
                byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                // Combine salt and input bytes
                byte[] saltedInput = new byte[saltBytes.Length + inputBytes.Length];
                saltBytes.CopyTo(saltedInput, 0);
                inputBytes.CopyTo(saltedInput, saltBytes.Length);
                byte[] hashedBytes = sha256.ComputeHash(saltedInput);
                hashInputSalt = BitConverter.ToString(hashedBytes);
            }
            return hashInputSalt == password;
        }
        #endregion
    }
}
