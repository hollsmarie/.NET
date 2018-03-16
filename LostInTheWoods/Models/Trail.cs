using System.ComponentModel.DataAnnotations;
namespace LostInTheWoods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        [Required]
        public string Name{get;set;}

        [Required]
        [MinLength(10, ErrorMessage="Description must be at least 10 characters")]
        public string Description{get;set;}

        [Required(ErrorMessage = "Length field is required")]
        public float? Length {get;set;}
        
        [Required(ErrorMessage = "Elevation change field is required")]
        public float? Elevation{get;set;}

        [Required(ErrorMessage = "Latitude field is required")]
        public float? Latitude{get;set;}

        [Required(ErrorMessage = "Longitude field is required")]
        public float? Longitude{get;set;}
        
        [Key]
        public int id{get;set;}
 
    }
}