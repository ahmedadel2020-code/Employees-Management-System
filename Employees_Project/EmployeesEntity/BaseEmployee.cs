using System;

namespace EmployeesEntity
{
    public class BaseEmployee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public DateTime Birthday { get; set; }
        public int CodeMenue { get; set; }
        public string NameMenue { get; set; }

        public double Salary { get; set; }
    }
}
