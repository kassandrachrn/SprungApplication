using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SprungGermanData.Models;

namespace SprungGermanData
{
    public class SprungDbContext : IdentityDbContext<Learner>
    { 
        public SprungDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<LearnerProgress> LearnerProgress { get; set; }
    }
}
