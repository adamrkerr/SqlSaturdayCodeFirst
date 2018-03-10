using Microsoft.EntityFrameworkCore;

namespace SqlSaturdayCodeFirst.Context
{
    internal partial class UniversityDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(m => m.Instructor) //set up foreign key relationships
                .WithMany(m => m.Courses);

            modelBuilder.Entity<Course>()
                .HasMany(m => m.EnrolledStudents)
                .WithOne(m => m.Course);

            modelBuilder.Entity<Course>()
                .HasOne(m => m.Department);

            modelBuilder.Entity<Instructor>()
                .HasOne(m => m.Department);

            modelBuilder.Entity<Student>()
                .HasMany(m => m.EnrolledCourses)
                .WithOne(m => m.Student);

            modelBuilder.Entity<CourseEnrollment>()
                .Property(m => m.FinalGrade)
                .HasColumnType("decimal(6,3)");
            
        }

    }
}
