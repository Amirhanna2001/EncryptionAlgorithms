using System.ComponentModel.DataAnnotations;

namespace EncryptionAlgorithms.ViewModels
{
    public class ReturnViewModel
    {
        [Required]
        public string Message { get; set; }
        public string Result { get; set; }
    }
}
