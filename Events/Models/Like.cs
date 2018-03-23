using System;

namespace Events.Models
{
    public class Like : BaseEntity
    {
        public int LikeId {get;set;}
        public int UserId {get; set;}

        public User User {get; set;}

        public int EventId {get; set;}

        public Event Event {get; set;}

        public Like()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
   }
}

//All integers and strings will be passed in, 
//Objects and Lists that we call (User User, Like list) will not go into the table