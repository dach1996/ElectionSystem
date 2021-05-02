using System;
using System.Linq;
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
        public static string GetSHA256(string input)
        {
            try
            {
                using SHA256 sha256 = SHA256Managed.Create();
                ASCIIEncoding encoding = new();
                byte[] stream = null;
                stream = sha256.ComputeHash(encoding.GetBytes(input));
                StringBuilder sb = new();
                for (int i = 0; i < stream.Length; i++)
                    sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
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
            using SHA256 sha256 = SHA256Managed.Create();
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            // Combine salt and input bytes
            byte[] saltedInput = new byte[saltBytes.Length + inputBytes.Length];
            saltBytes.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, saltBytes.Length);
            byte[] hashedBytes = sha256.ComputeHash(saltedInput);
            StringBuilder sb = new();
            for (int i = 0; i < hashedBytes.Length; i++)
                sb.AppendFormat("{0:x2}", hashedBytes[i]);
            return sb.ToString();
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


        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();
            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    { // check if the property can be set or no.
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }

            }

        }

        /// <summary>
        /// Genera un código combinado en base a letras y números
        /// </summary>
        /// <param name="numberCharacters"></param>
        /// <returns></returns>
        public static string GenerateCode(int numberCharacters)
        {
            var allowableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var random = new byte[numberCharacters];
            //Genera los números random
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(random);
            //Transforma caracteres permitidos a lista.
            var characteresArray = allowableChars.ToCharArray();
            //Obtiene número de caracteres soportados
            var characteresArraylength = characteresArray.Length;
            var chars = new char[numberCharacters];
            for (var i = 0; i < numberCharacters; i++)
                chars[i] = characteresArray[random[i] % characteresArraylength];
            return new string(chars);
        }
        #endregion

    }
}
