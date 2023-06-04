using System.Security.Cryptography;
using System.Text;

namespace Problem_2
{
    internal class SerialNumberGenerator
    {
        public interface ISerialNumberGenerator
        {
            // Method to generate a serial number
            string GenerateSerialNumber(string title, string author, string placePublication, string publisher, string publicationDate);
        }

        public class HashBasedSerialNumberGenerator : ISerialNumberGenerator
        {
            // Implementation of the serial number generator
            public string GenerateSerialNumber(string title, string author, string placePublication, string publisher, string publicationDate)
            {
                string bookInfo = $"{title}{author}{placePublication}{publisher}{publicationDate}";

                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(bookInfo));

                    StringBuilder builder = new StringBuilder();

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }

                    // Return the first 10 characters of the generated serial number
                    return builder.ToString().Substring(0, 10);
                }
            }
        }
    }
}
