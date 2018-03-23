using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Events.Models
{
    public class User : BaseEntity
        {
        

            public int UserId {get; set;}

            public string firstname {get; set;}

            public string lastname {get; set;}

            public string email {get; set;}

            public string password {get; set;}

            public List<Like> Likes {get; set;}

            public User()
            {
                Likes = new List<Like>();
                CreatedAt = DateTime.Now;
                UpdatedAt = DateTime.Now;

            }


    }
}