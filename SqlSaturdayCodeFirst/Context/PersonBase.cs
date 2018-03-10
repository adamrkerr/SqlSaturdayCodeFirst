using SqlSaturdayCodeFirst.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SqlSaturdayCodeFirst.Context
{
    internal abstract class PersonBase : AuditableEntity<Guid>
    {
        protected PersonBase() : base()
        {

        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }
    }
}
