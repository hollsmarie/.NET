using Microsoft.EntityFrameworkCore;

namespace Events.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}   
        public DbSet<Event> Events {get; set;}   
        public DbSet<Like> Likes {get; set;}   //DbSets make the tables and pass in to the table what we define in the model*
        }
}