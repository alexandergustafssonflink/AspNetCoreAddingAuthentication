using System.ComponentModel.DataAnnotations;

namespace WishList.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]

        [StringLength(100, MinimumLength = 8, ErrorMessage = "HEJ")]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Email and Confirm Email fields do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
