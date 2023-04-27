using Microsoft.AspNetCore.Mvc;

namespace EncryptionAlgorithms.Controllers
{
    public class CaesarCipherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public static string Encrypt(string plaintext, int shift)
        {
            string ciphertext = "";

            foreach (char c in plaintext)
            {
                if (Char.IsLetter(c))
                {
                    // Determine the position of the character in the alphabet (0-25)
                    int position = Char.ToUpper(c) - 'A';

                    // Apply the shift and wrap around if necessary
                    int shiftedPosition = (position + shift) % 26;

                    // Convert the shifted position back to a character
                    char shiftedChar = (char)('A' + shiftedPosition);

                    // Add the shifted character to the ciphertext
                    ciphertext += shiftedChar;
                }
                else
                {
                    // Leave non-alphabetic characters unchanged
                    ciphertext += c;
                }
            }

            return ciphertext;
        }

        // Decrypts ciphertext using a Caesar cipher with the given shift value
        public static string Decrypt(string ciphertext, int shift)
        {
            // To decrypt, simply shift in the opposite direction
            return Encrypt(ciphertext, 26 - shift);
        }
    }
}
