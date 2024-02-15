using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Belgique.Models
{
    public class MovieSubmissionContext : DbContext
    {
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options) // Comstructor
        {
        }

        public DbSet<MovieSubmit> MovieSubmits { get; set; }
    }
}
