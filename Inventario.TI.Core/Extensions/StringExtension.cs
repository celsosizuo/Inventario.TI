using System.Text;

namespace Inventario.TI.Core.Extensions
{
    public static class StringExtension
    {
        public static string Base64Decode(string keyEncoded)
        {
            if (string.IsNullOrEmpty(keyEncoded))
                return string.Empty;

            var base64EncodedBytes = Convert.FromBase64String(keyEncoded);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(string objeto)
        {
            if (string.IsNullOrEmpty(objeto))
                return string.Empty;

            var objetoBytes = Encoding.UTF8.GetBytes(objeto);
            return Convert.ToBase64String(objetoBytes);
        }
    }
}
