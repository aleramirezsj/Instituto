using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace InstitutoWeb.ExtensionMethod
{


    public static class ObjectExtensions
    {
        public static string GetHashSha256(this string textoAEncriptar)
        {
            // Create a SHA256   
            using SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textoAEncriptar));
            // Convert byte array to a string   
            StringBuilder hashObtenido = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                hashObtenido.Append(bytes[i].ToString("x2"));
            }
            return hashObtenido.ToString();
        }
        public static void CopyPropertiesTo<T>(this T source, T destination)
        {
            if (source == null || destination == null)
            {
                throw new ArgumentNullException("Objeto de origen o destino son nulos");
            }

            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(source, null);
                    property.SetValue(destination, value, null);
                }
            }
        }
        public static string PropertiesToString<T>(this T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Type type = typeof(T);

            string stringReturn=string.Empty;

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanRead && property.CanWrite)
                {
                    object? value = property.GetValue(source, null);
                    stringReturn += $"{property.Name}={value?.ToString()??"null"}{Environment.NewLine}";
                }
            }
            return stringReturn;
        }
    }
}
