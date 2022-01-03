﻿using System.ComponentModel.DataAnnotations;

namespace WishList.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]

        [StringLength(100, ErrorMessage = "HEJ")]
        [MinLength(8)]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Email and Confirm Email fields do not match.")]
        public string ConfirmPassword { get; set; }
    }
}