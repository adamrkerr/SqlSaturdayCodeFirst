using SqlSaturdayCodeFirst.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace SqlSaturdayCodeFirst.Context
{
    internal class CourseEnrollment : AuditableEntity<Guid>
    {
        public CourseEnrollment() : base()
        {

        }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        public float FinalGrade { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }

    }
}
