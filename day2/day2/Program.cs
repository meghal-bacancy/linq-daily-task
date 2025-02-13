using day2;

class Program
{
    public static void Display<T>(List<T> list)
    {
        foreach (T item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        List<Employee> employees = Employee.GetEmployees();
        List<Salary> Salaries = Salary.GetSalaries();

        // Write a LINQ query to fetch the EmployeeId, Employee Name, SalaryId, and Amount using an inner join.
        var EmployeeSalary = employees.Join(Salaries,
                                employees => employees.EmployeeId,
                                Salaries => Salaries.EmployeeId, 
                                (employees, Salaries) => 
                                    new {
                                        EmployeeId = employees.EmployeeId,
                                        EmployeeName = employees.Name,
                                        SalaryId = Salaries.SalaryId,
                                        Amount = Salaries.Amount
                                    }).ToList();

        var EmployeeSalaryQuery = (from emp in employees 
                                   join sal in Salaries 
                                   on emp.EmployeeId equals sal.EmployeeId 
                                   select new 
                                   {
                                       EmployeeId = emp.EmployeeId,
                                       EmployeeName = emp.Name,
                                       SalaryId = sal.SalaryId,
                                       Amount = sal.Amount
                                   }).ToList();

        Display(EmployeeSalary);
        Display(EmployeeSalaryQuery);

        // Write a LINQ query to perform a Group Join, listing employees along with their salaries.
        var GroupJoin = employees.GroupJoin(Salaries,
                        emp => emp.EmployeeId,
                        sal => sal.EmployeeId,
                        (emp, salList) => new
                        {
                            EmployeeName = emp.Name,
                            Salaries = string.Join(", ", salList.Select(s => s.Amount)) // Convert to a readable string
                        }).ToList();

        var GroupJoinQuery = (from emp in employees 
                             join sal in Salaries
                             on emp.EmployeeId equals sal.EmployeeId
                             into EmployeeGroups 
                             select new
                             {
                                 EmployeeName = emp.Name,
                                 //Salaries = string.Join(", ", Salaries.Select(s => s.Amount))
                                 Salaries = string.Join(", ", EmployeeGroups.Select(s => s.Amount))
                             }).ToList();

        Display(GroupJoin);
        Display(GroupJoinQuery);

        // Group employees by Department using Method Syntax
        var GroupByEmployees = employees.GroupBy(s => s.Department).ToList();
        foreach (var group in GroupByEmployees)
        {
            Console.WriteLine(group.Key);
            foreach (var g in group)
            {
                Console.WriteLine(g.ToString());
            }
            Console.WriteLine();
        }

        // Write a LINQ query to perform a Cross Join, generating all possible combinations of Employees and Salaries.
        var CrossJoinResult = employees.SelectMany(sub => Salaries,
                                 (emp, sal) => new
                                 {
                                     emp,
                                     sal
                                 }).ToList();

        var CrossJoinResultQuery = (from emp in employees
                                    from sal in Salaries
                                    select new
                                    {
                                        emp,
                                        sal
                                    }).ToList();
        Display(CrossJoinResult);
        Display(CrossJoinResultQuery);

        // Write a LINQ query to perform a Left Outer Join, listing all employees along with their salaries(even if they don’t have any salaries recorded).
        var LeftOuterJoin = employees.GroupJoin(Salaries,
                            employee => employee.EmployeeId,
                            salary => salary.EmployeeId,
                            (employee, salaries) => new { employee, salaries })
                              .SelectMany(
                                    x => x.salaries.DefaultIfEmpty(),
                                    (x, salary) => new { x.employee, salary }
                               ).ToList();

        var LeftOuterJoinQuery = (from emp in employees 
                                 join sal in Salaries
                                 on emp.EmployeeId equals sal.EmployeeId
                                 into EmployeeLeftOuterJoin 
                                 from sal in EmployeeLeftOuterJoin.DefaultIfEmpty() 
                                 select new { emp, sal }).ToList();

        Display(LeftOuterJoin);
        Display(LeftOuterJoinQuery);

        // Write a LINQ query to group salaries by EmployeeId, displaying the total salary received by each employee.
        var totalSalary = LeftOuterJoin.GroupBy(e => e.employee.EmployeeId).Select(g => new { EmployeeId = g.Key, TotalSalary = g.Sum(e => e.salary != null ? e.salary.Amount : 0) }).ToList();
        var totalSalaryQuery = (from emp in LeftOuterJoinQuery
                                group emp by emp.emp.EmployeeId into SalaryQuery
                                select new
                                {
                                    EmployeeId = SalaryQuery.Key,
                                    //Salary = SalaryQuery.Sum(e => e.sal.Amount != null ? e.sal.Amount : 0)
                                    TotalSalary = SalaryQuery.Sum(e => e.sal != null ? e.sal.Amount : 0)
                                }).ToList();

        Display(totalSalary);
        Display(totalSalaryQuery);

        // Use ToLookup to create a dictionary-like structure where EmployeeId is the key and salaries are the values.
        var lookUp = EmployeeSalary.ToLookup(s => s.EmployeeId);
        foreach (var group in lookUp)
        {
            Console.WriteLine($"Employee ID: {group.Key}");
            foreach (var record in group)
            {
                Console.WriteLine($"  Name: {record.EmployeeName}, Salary: {record.Amount}");
            }
            Console.WriteLine();
        }

        // Modify the GroupBy query to display the EmployeeId, count of salaries received, and the highest salary per employee.
        var groupBySal = LeftOuterJoin.GroupBy(e => e.employee.EmployeeId).Select(g => new { EmployeeId = g.Key, HighestSalary = g.Max(e => e.salary != null ? e.salary.Amount : 0), Count = g.Count(), }).ToList();
        var groupBySalQuery = (from emp in LeftOuterJoinQuery
                               group emp by emp.emp.EmployeeId into SalaryQuery
                                select new
                                {
                                    EmployeeId = SalaryQuery.Key,
                                    HighestSalary = SalaryQuery.Max(e => e.sal != null ? e.sal.Amount : 0),
                                    Count = SalaryQuery.Count()
                                }).ToList();
        Display(groupBySal);
        Display(groupBySalQuery);

        // Fetch employee names who have received at least one salary above $5000 using a nested LINQ query.
        var salaryGreaterThan500 = EmployeeSalary.Where(e => e.Amount > 5000).Distinct().ToList();
        var salaryGreaterThan500Query = (from emp in EmployeeSalaryQuery
                                         where emp.Amount > 5000
                                         select emp).Distinct().ToList();
        Display(salaryGreaterThan500);
        Display(salaryGreaterThan500Query);

        // Get a list of unique departments where employees work.
        var distinctDepartments = employees.Select(e => e.Department).Distinct().ToList();
        var distinctDepartmentsQuery = (from emp in employees
                                        select emp.Department).Distinct().ToList();    
        Display(distinctDepartments);
        Display(distinctDepartmentsQuery);

        List<Salary> SalariesSecond = Salary.GetSalariesSecond();

        // Get a combined list of months from two different salary collections.
        var SalaryUnion = (Salaries.Select(s => s.Month)).Union(SalariesSecond.Select(s => s.Month)).ToList();
        var SalaryUnionQuery = (from s in Salaries select s.Month).Union(from s in SalariesSecond select s.Month).ToList();
        Display(SalaryUnion);
        Display(SalaryUnionQuery);

        // Find common months between two different salary collections.
        var SalaryIntersection = (Salaries.Select(s => s.Month)).Intersect(SalariesSecond.Select(s => s.Month)).ToList();
        var SalaryIntersectionnQuery = (from s in Salaries select s.Month).Intersect(from s in SalariesSecond select s.Month).ToList();
        Display(SalaryIntersection);
        Display(SalaryIntersectionnQuery);

        // Find months that exist in the first salary collection but not in the second.
        var SalaryExcept = (Salaries.Select(s => s.Month)).Except(SalariesSecond.Select(s => s.Month)).ToList();
        var SalaryExceptQuery = (from s in Salaries select s.Month).Except(from s in SalariesSecond select s.Month).ToList();
        Display(SalaryExcept);
        Display(SalaryExceptQuery);

        // Assume a list of duplicate employee names. Write a LINQ query to get a unique list.
        var UniqueName = employees.Select(s => s.Name).Distinct().ToList();
        var UniqueNameQuery = (from e in employees select e.Name).Distinct().ToList();
        Display(UniqueName);
        Display(UniqueNameQuery);

        // Create a LINQ query that retrieves employees from a collection and demonstrate deferred execution and immediate execution
        // Implement an example that simulates lazy vs.eager loading using LINQ queries.
    }
}