using System.ComponentModel.DataAnnotations;

namespace WishList.Models.AccountViewModels
{
    public class LoginViewModel
    {   
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

}
}
