using Microsoft.EntityFrameworkCore;

namespace Mission06_Alley.Models
{
    public class formContext :DbContext
    {
        public formContext(DbContextOptions<formContext> options) : base (options) { }

        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}

