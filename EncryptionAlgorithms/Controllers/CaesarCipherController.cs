using EncryptionAlgorithms.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionAlgorithms.Controllers
{
    public class CaesarCipherController : Controller
    {
        public IActionResult Encription()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Encription(ReturnViewModel model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            if(model.Message == null)
            {
                ModelState.AddModelError("Message", "Message can't be null !");
                return View( model);

            }
            ReturnViewModel returnViewModel = new ();
            returnViewModel.Message = model.Message;
            returnViewModel.Result = Encrypt(model.Message, 10);
            return View(returnViewModel);
        }
        public IActionResult Dencription()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dencription(ReturnViewModel model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            if(model.Message == null)
            {
                ModelState.AddModelError("Message", "Message can't be null !");
                return View("Result", model);

            }
            ReturnViewModel returnViewModel = new ();
            returnViewModel.Message = model.Message;
            returnViewModel.Result = Encrypt(model.Message, 10);
            return View("Result", returnViewModel);
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
