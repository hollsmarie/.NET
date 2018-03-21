using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
        {
        
            public int WeddingId {get; set;}

            [Required]
            [MinLength(2)]
            public string WedderOne {get; set;}

            [Required]
            [MinLength(2)]
            public string WedderTwo {get; set;}

            public int UserId {get; set;}
            public User User {get; set;}
            
            [Required]
            [DataType(DataType.Date)]
            [PastDate(ErrorMessage="Date cannot be in the past")]
            public DateTime Date {get; set;}

            [Required]
            [MinLength(3)]
            public string Address {get; set;}

            public List<RSVP> RSVPS {get; set;}

        public Wedding()
        {
            RSVPS = new List<RSVP>();
        }
    

        }
}