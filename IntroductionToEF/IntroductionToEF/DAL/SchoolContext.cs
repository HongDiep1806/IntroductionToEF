using Azure;
using IntroductionToEF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace IntroductionToEF.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<StudentCard> StudentCards { get; set; }
        public DbSet<AssignmentResult> AssignmentResults { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasOne(student => student.StudentCard)
                        .WithOne(card => card.Student)
                        .HasForeignKey<StudentCard>(card => card.StudentID);
        }


    }

}


