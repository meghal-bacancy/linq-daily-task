using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace day2
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { EmployeeId = 1, Name = "Alice", Department = "HR" },
                new Employee { EmployeeId = 2, Name = "Bob", Department = "IT" },
                new Employee { EmployeeId = 3, Name = "Charlie", Department = "Finance" },
                new Employee { EmployeeId = 4, Name = "David", Department = "IT" },
                new Employee { EmployeeId = 5, Name = "Eve", Department = "HR" },
                new Employee { EmployeeId = 6, Name = "Frank", Department = "Finance" },
                new Employee { EmployeeId = 7, Name = "Grace", Department = "IT" },
                new Employee { EmployeeId = 8, Name = "Hank", Department = "HR" },
                new Employee { EmployeeId = 9, Name = "Ivy", Department = "Finance" },
                new Employee { EmployeeId = 10, Name = "Jack", Department = "IT" },
                new Employee { EmployeeId = 11, Name = "Karen", Department = "HR" },
                new Employee { EmployeeId = 12, Name = "Leo", Department = "Finance" },
                new Employee { EmployeeId = 13, Name = "Mona", Department = "IT" },
                new Employee { EmployeeId = 14, Name = "Nate", Department = "HR" },
                new Employee { EmployeeId = 15, Name = "Olivia", Department = "Finance" },
                new Employee { EmployeeId = 16, Name = "Paul", Department = "Marketing" }
            };
        }
        public override string ToString()
        {
            return $"{EmployeeId}, {Name}, {Department}";
        }
    }

    class Salary
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public string Month { get; set; }
        public static List<Salary> GetSalaries()
        {
            return new List<Salary>
            {
                new Salary { SalaryId = 101, EmployeeId = 1, Amount = 4000, Month = "January" },
                new Salary { SalaryId = 102, EmployeeId = 1, Amount = 4200, Month = "February" },
                new Salary { SalaryId = 103, EmployeeId = 2, Amount = 5000, Month = "January" },
                new Salary { SalaryId = 104, EmployeeId = 3, Amount = 6000, Month = "March" },
                new Salary { SalaryId = 105, EmployeeId = 4, Amount = 5500, Month = "April" },
                new Salary { SalaryId = 106, EmployeeId = 5, Amount = 4500, Month = "May" },
                new Salary { SalaryId = 107, EmployeeId = 6, Amount = 7000, Month = "June" },
                new Salary { SalaryId = 108, EmployeeId = 7, Amount = 8000, Month = "July" },
                new Salary { SalaryId = 109, EmployeeId = 8, Amount = 7500, Month = "August" },
                new Salary { SalaryId = 110, EmployeeId = 9, Amount = 6200, Month = "September" },
                new Salary { SalaryId = 111, EmployeeId = 10, Amount = 5600, Month = "October" },
                new Salary { SalaryId = 112, EmployeeId = 11, Amount = 5800, Month = "November" },
                new Salary { SalaryId = 113, EmployeeId = 12, Amount = 6900, Month = "December" },
                new Salary { SalaryId = 114, EmployeeId = 13, Amount = 7300, Month = "January" },
                new Salary { SalaryId = 115, EmployeeId = 14, Amount = 4800, Month = "February" },
                new Salary { SalaryId = 116, EmployeeId = 17, Amount = 5000, Month = "March" },
                new Salary { SalaryId = 117, EmployeeId = 18, Amount = 6200, Month = "April" }
            };
        }

        public static List<Salary> GetSalariesSecond()
        {
            return new List<Salary>
            {
                new Salary { SalaryId = 201, EmployeeId = 21, Amount = 3500, Month = "January" },
                new Salary { SalaryId = 202, EmployeeId = 22, Amount = 4100, Month = "February" },
                new Salary { SalaryId = 203, EmployeeId = 23, Amount = 4700, Month = "February" },
                new Salary { SalaryId = 204, EmployeeId = 24, Amount = 5200, Month = "February" },
                new Salary { SalaryId = 205, EmployeeId = 25, Amount = 4900, Month = "February" },
                new Salary { SalaryId = 206, EmployeeId = 26, Amount = 6100, Month = "June" },
                new Salary { SalaryId = 207, EmployeeId = 27, Amount = 7200, Month = "July" },
                new Salary { SalaryId = 208, EmployeeId = 28, Amount = 8100, Month = "August" },
                new Salary { SalaryId = 209, EmployeeId = 29, Amount = 6500, Month = "September" },
                new Salary { SalaryId = 210, EmployeeId = 30, Amount = 5800, Month = "October" },
                new Salary { SalaryId = 211, EmployeeId = 31, Amount = 5300, Month = "November" },
                new Salary { SalaryId = 212, EmployeeId = 32, Amount = 6000, Month = "December" },
                new Salary { SalaryId = 213, EmployeeId = 33, Amount = 6800, Month = "January" },
                new Salary { SalaryId = 214, EmployeeId = 34, Amount = 4500, Month = "February" },
            };
        }


        public override string ToString()
        {
            return $"{SalaryId}, {EmployeeId}, {Amount}, {Month}";
        }
    }
}