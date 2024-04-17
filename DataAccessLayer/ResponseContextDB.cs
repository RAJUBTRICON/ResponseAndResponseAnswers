using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ResponseContextDB : DbContext
    { 
        public DbSet<Response>? Responses { get; set; }
        public DbSet<ResponseAnswer>? ResponseAnswers { get; set; }

        public ResponseContextDB(DbContextOptions<ResponseContextDB> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       //     modelBuilder.Entity<ResponseAnswer>()
       //.HasKey(ra => ra.Id);

       //     modelBuilder.Entity<ResponseAnswer>()
       // .HasOne(ra => ra.Response) // Configure the navigation property to Response
       // .WithMany(r => r.Answers) // Response can have multiple ResponseAnswers
       // .HasForeignKey(ra => ra.ResponseId);

       //     base.OnModelCreating(modelBuilder);
        }
    }
}
