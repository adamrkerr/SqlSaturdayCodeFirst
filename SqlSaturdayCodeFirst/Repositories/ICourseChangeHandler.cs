using System;
using System.Threading.Tasks;
using SqlSaturdayCodeFirst.Models;

namespace SqlSaturdayCodeFirst.Repositories
{
    public interface ICourseChangeHandler
    {
        Task<CourseDetail> CreateCourse(CourseCreationCommand courseToCreate);
        Task DeleteCourse(Guid courseId);
    }
}