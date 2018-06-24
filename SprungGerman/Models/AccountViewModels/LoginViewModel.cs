using System.ComponentModel.DataAnnotations;

namespace SprungGerman.Models.AccountViewModels
{
    public class LoginViewModel

    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me next time")]
        public bool RememberMe { get; set; }
    }
}
