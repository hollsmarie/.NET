using System;
using System.ComponentModel.DataAnnotations;
namespace RESTauranter.Models
{
    public abstract class BaseEntity{}
    
    public class Review : BaseEntity
    {
        public int ReviewID {get;set;}

        [Required]
        [MinLength(3, ErrorMessage="Must include Name of Reviewer")]
        public string ReviewName {get;set;}

        [Required]
        [MinLength(3, ErrorMessage="Must include Restaurant Name")]
        public string RestName {get;set;}

        [Required]
        [MinLength(10, ErrorMessage="Your review cannot be blank")]
        public string Comment {get;set;}

        [Required]
        [DataType(DataType.Date)]
        [PastDate(ErrorMessage="Date cannot be in the past")]
        public DateTime VisitDate {get;set;}

        [Required]
        [Range(0,5)]
        public int Stars {get;set;}

    }
}