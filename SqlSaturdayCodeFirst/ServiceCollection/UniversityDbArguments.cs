using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSaturdayCodeFirst.ServiceCollection
{
    public class UniversityDbArguments
    {
        public string ConnectionString { get; set; }

        public bool CreateDbIfNotFound { get; set; }
    }
}
