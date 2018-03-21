using System.ComponentModel.DataAnnotations;
using System;

namespace WeddingPlanner.Models
{
    public abstract class BaseEntity{}
    public class Register : BaseEntity
        {
        [Required]
        [MinLength(2)]
        public string firstname { get; set; }

        [Required]
        [MinLength(2)]
        public string lastname { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Passwords must match.")]
        public string confirm {get; set;}

        }
    

    public class Login : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }


    }
}