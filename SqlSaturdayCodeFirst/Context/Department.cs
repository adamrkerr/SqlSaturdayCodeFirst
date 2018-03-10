using SqlSaturdayCodeFirst.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SqlSaturdayCodeFirst.Context
{
    internal class Department : AuditableEntity<int>
    {
        public Department() : base() { }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
