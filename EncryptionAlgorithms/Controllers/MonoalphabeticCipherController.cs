using EncryptionAlgorithms.ViewModels;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionAlgorithms.Controllers
{
    public class MonoalphabeticCipherController : Controller
    {
        private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string key = "QWERTYUIOPASDFGHJKLZXCVBNM";
        public IActionResult Encription()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Encription(ReturnViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Message == null)
            {
                ModelState.AddModelError("Message", "Message can't be null !");
                return View(model);

            }
            ReturnViewModel returnViewModel = new();
            returnViewModel.Message = model.Message;
            returnViewModel.Result = Encrypt(model.Message);
            return View(returnViewModel);
        }
        public IActionResult Decryption()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Decryption(ReturnViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Message == null)
            {
                ModelState.AddModelError("Message", "Message can't be null !");
                return View(model);

            }
            ReturnViewModel returnViewModel = new();
            returnViewModel.Message = model.Message;
            returnViewModel.Result = Decrypt(model.Message);
            return View(returnViewModel);
        }
        // Encrypts plaintext using a monoalphabetic cipher with the given key
        public static string Encrypt(string plaintext)
        {
            string ciphertext = "";

            foreach (char c in plaintext)
            {
                if (Char.IsLetter(c))
                {
                    // Determine the position of the character in the alphabet (0-25)
                    int position = Char.ToUpper(c) - 'A';

                    // Use the key to encrypt the character
                    char encryptedChar = key[position];

                    // Add the encrypted character to the ciphertext
                    ciphertext += encryptedChar;
                }
                else
                {
                    // Leave non-alphabetic characters unchanged
                    ciphertext += c;
                }
            }

            return ciphertext;
        }

        // Decrypts ciphertext using a monoalphabetic cipher with the given key
        public static string Decrypt(string ciphertext)
        {
            string plaintext = "";

            foreach (char c in ciphertext)
            {
                if (Char.IsLetter(c))
                {
                    // Determine the position of the encrypted character in the key (0-25)
                    int position = key.IndexOf(Char.ToUpper(c));

                    // Use the alphabet to decrypt the character
                    char decryptedChar = alphabet[position];

                    // Add the decrypted character to the plaintext
                    plaintext += decryptedChar;
                }
                else
                {
                    // Leave non-alphabetic characters unchanged
                    plaintext += c;
                }
            }

            return plaintext;
        }
    }
}
