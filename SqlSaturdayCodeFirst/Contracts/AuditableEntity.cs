using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SqlSaturdayCodeFirst.Contracts
{
    internal abstract class AuditableEntity<T> : IIdentified<T>
    {
        [Required]
        public T Id { get; set; }

        [Required]
        public DateTimeOffset? LastChangedTimestamp { get; set; }

        [Required]
        public string LastChangedByUser { get; set; }

        public bool IsDeleted { get; set; }

    }
}
