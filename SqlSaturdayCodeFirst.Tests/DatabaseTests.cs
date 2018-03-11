using SqlSaturdayCodeFirst.Context;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SqlSaturdayCodeFirst.Tests
{
    public class DatabaseTests : IClassFixture<DatabaseTestingFixture<DatabaseTests>>
    {
        DatabaseTestingFixture<DatabaseTests> _fixture;

        public DatabaseTests(DatabaseTestingFixture<DatabaseTests> fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task TestStudentCreation()
        {
            var dbContext = _fixture.ServiceProvider.GetService<UniversityDbContext>();

            dbContext.Students.Add(new Student
            {
                BirthDate = new DateTime(2000, 1, 1),
                ExpectedGraduationYear = 2023,
                FirstName = "John",
                LastName = "Doe",
                LastChangedByUser = "test",
                LastChangedTimestamp = DateTimeOffset.UtcNow
            });

            await dbContext.SaveChangesAsync();

            var student = dbContext.Students.FirstOrDefault();

            Assert.NotNull(student);
            Assert.NotEqual(Guid.Empty, student.Id);

        }

        [Fact]
        public async Task TestSoftDeletion()
        {
            var studentId = Guid.NewGuid();

            //Do this in scopes to prove the change tracker isn't faking positives
            using (var scope = _fixture.ServiceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<UniversityDbContext>();

                dbContext.Students.Add(new Student
                {
                    Id = studentId,
                    BirthDate = new DateTime(2000, 1, 1),
                    ExpectedGraduationYear = 2023,
                    FirstName = "John",
                    LastName = "Doe"
                });

                await dbContext.SaveChangesAsync();
            }

            using (var scope = _fixture.ServiceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<UniversityDbContext>();

                var student = dbContext.Students.Find(studentId);
                
                Assert.NotNull(student);

                student.IsDeleted = true;

                await dbContext.SaveChangesAsync();
            }

            using (var scope = _fixture.ServiceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<UniversityDbContext>();

                var student = dbContext.Students.Find(studentId);

                Assert.Null(student);
                
                student = dbContext.Students
                    .IgnoreQueryFilters()
                    .Where(s => s.Id == studentId)
                    .Single();

                Assert.NotNull(student);
                Assert.True(student.IsDeleted, "Expected student.IsDeleted == false");

            }
        }
    }
}
