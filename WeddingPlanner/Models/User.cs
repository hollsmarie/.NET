using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace WeddingPlanner.Models
{
    public class User : BaseEntity
        {
        

            public int UserId {get; set;}

            public string firstname {get; set;}

            public string lastname {get; set;}

            public string email {get; set;}

            public string password {get; set;}

            public List<RSVP> RSVPS {get; set;}

        public User()
        {
            RSVPS = new List<RSVP>();
        }
    

    }
}