﻿using EncryptionAlgorithms.AlgorithmsCode;
using EncryptionAlgorithms.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionAlgorithms.Controllers
{
    public class PlayFairCipherController : Controller
    {
        private string KEY = "EXAMPLEKEY";

        public IActionResult Index()
        {
            return View();//Go to index HTML Page
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
            ReturnViewModel returnViewModel = new ReturnViewModel();
            returnViewModel.Message = model.Message;
            returnViewModel.Result =PlayFair.Encrypt(model.Message, KEY);
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
            returnViewModel.Result =PlayFair.Decrypt(model.Message, KEY);
            return View(returnViewModel);
        }


       

    }
}
