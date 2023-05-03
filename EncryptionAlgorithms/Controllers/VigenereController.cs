using EncryptionAlgorithms.AlgorithmsCode;
using EncryptionAlgorithms.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionAlgorithms.Controllers
{
    public class VigenereController : Controller
    {
        private static string key = "QWERTYUIOPASDFGHJKLZXCVBNM";

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Encryption()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Encryption(ReturnViewModel model)
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
            returnViewModel.Result = Vigenere.Encrypt(model.Message,key);
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
            returnViewModel.Result = Vigenere.Decrypt(model.Message, key);
            return View(returnViewModel);
        }
    }
}
