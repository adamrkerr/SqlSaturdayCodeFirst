using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SqlSaturdayCodeFirst.Models;

namespace SqlSaturdayCodeFirst.Repositories
{
    public interface ICourseRepository
    {
        Task<CourseDetail> GetCourse(Guid courseId);
        Task<IEnumerable<CourseSummary>> GetCourses();
    }
}