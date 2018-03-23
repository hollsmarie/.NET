using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System;

namespace Events.Models
{
    public class Event : BaseEntity
    {
        public int EventId {get; set;}

        public int UserId {get; set;}
        
        [Required (ErrorMessage = "Someone must Host the event.")]
        public string Host {get; set;}

        [Required (ErrorMessage = "Don't forget to tell us what this party is for!.")]
        public string Reason {get; set;}

        [Required (ErrorMessage = "Please tell us where so we can come too!.")]
        public string Location {get; set;}

        [Required (ErrorMessage = "When is your shindig happening?")]
        public DateTime? Date {get; set;}

        public List<Like> Likes {get; set;}
        public Event()
            {
                Likes = new List<Like>();
                CreatedAt = DateTime.Now;
                UpdatedAt = DateTime.Now;
            }
        public IEnumerable<ValidationResult> ValidationResult(ValidationContext validationContext)
        {
            if (Date <DateTime.Now)
            {
                yield return new ValidationResult ("Sorry, no time travelers allowed.");
            }
        }
    }
}