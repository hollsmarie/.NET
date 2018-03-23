using System.ComponentModel.DataAnnotations;
using System;
namespace Events.Models

{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(2)]
        public string firstname { get; set; }

        [Required]
        [MinLength(2)]
        public string lastname { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage="Please enter a valid email address")]
        public string email { get; set; }

        [Required]
        [MinLength(8,ErrorMessage = "Passwords must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Passwords must match.")]
        public string confirm {get; set;}

    }
    

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage="Please enter a valid email address")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }


    }
    public class UserViewModels
    {
        public RegisterViewModel Reg {get; set;}
        public LoginViewModel Login {get;set;}
    }
}