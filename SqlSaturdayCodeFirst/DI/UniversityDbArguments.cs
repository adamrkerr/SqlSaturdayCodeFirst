using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSaturdayCodeFirst.DI
{
    public class UniversityDbArguments
    {
        public string ConnectionString { get; set; }

        public bool CreateDbIfNotFound { get; set; }
    }
}
