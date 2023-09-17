using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab6.Entities
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Married { get; set; }

        public Employee(string name, int age, bool married) { Name = name; Age = age; Married = married; }

        public override string ToString() { return $"Person {Name}, age - {Age}, Is Married? - {Married}"; }
    }
}
