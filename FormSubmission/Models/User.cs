using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public abstract class BaseEntity{}
    public class User : BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string firstname { get; set; }

        [Required]
        [MinLength(5)]
        public string lastname { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int age{get;set;}

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}