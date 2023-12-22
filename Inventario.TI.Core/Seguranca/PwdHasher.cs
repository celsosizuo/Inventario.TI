using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Inventario.TI.Core.Seguranca
{
    public class PwdHasher : IPwdHasher
    {
        private readonly Encoding encoding = Encoding.Unicode;
        private readonly HashAlgorithmProvider hashProvider;

        public PwdHasher()
        {
            hashProvider = new HashAlgorithmProvider(typeof(SHA1Managed), true);
        }

        public bool CompareHash(byte[] plaintext, byte[] hashedtext)
        {
            return hashProvider.CompareHash(plaintext, hashedtext);
        }
        public byte[] CreateHash(byte[] plaintext)
        {
            return hashProvider.CreateHash(plaintext);
        }
        public Task<bool> VerifyHashAsync(string password, string passwordHash)
        {
            return Task<bool>.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(password) && string.IsNullOrEmpty(passwordHash))
                    return true;

                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordHash))
                    return false;

                var pwdBytes = encoding.GetBytes(password);
                var pwdHashBytes = Convert.FromBase64String(passwordHash);

                return CompareHash(pwdBytes, pwdHashBytes);
            });
        }
        public Task<string> CreateHashAsync(string password)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                var pwdBytes = encoding.GetBytes(password);
                var result = Convert.ToBase64String(CreateHash(pwdBytes));
                return result;
            });
        }
    }
}
