using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    public delegate void HelloDelegate(string Message);

    public delegate bool IsPromotableEmployeeDelegate(Employee employee);
    class Program
    {
        static void Main(string[] args)
        {
            //First example
            HelloDelegate helloDelegate = new HelloDelegate(Hello);
            helloDelegate("Hello from delegate.");

            List<Employee> employees = new List<Employee>
            {
                new Employee{ EmpId = 1, Name = "John", Salary = 12000, Experience = 4},
                new Employee{ EmpId = 2, Name = "Dora", Salary = 20000, Experience = 3},
                new Employee{ EmpId = 3, Name = "Jack", Salary = 150000, Experience = 14},
                new Employee{ EmpId = 4, Name = "Jeetu", Salary = 7000, Experience = 1},
                new Employee{ EmpId = 5, Name = "sanjay", Salary = 72000, Experience = 2},
                new Employee{ EmpId = 6, Name = "Umar", Salary = 52000, Experience = 4},
            };

            //Second example
            Employee.PromoteEmployee(employees);

            //Third example
            //init delgate using method
            IsPromotableEmployeeDelegate isPromotableEmployeeDelegate = new IsPromotableEmployeeDelegate(IsPromotableEmployee);
            Employee.PromoteEmployee(employees, isPromotableEmployeeDelegate);

            //using Anonymous methods
            Employee.PromoteEmployee(employees, delegate (Employee emp) { return emp.Salary > 52000; });

            //using Func methods
            Func<Employee, bool> selector = emp => (emp.Salary > 52000);
            IsPromotableEmployeeDelegate isPromotableEmployeeDelegate1 = selector.Invoke;
            Employee.PromoteEmployee(employees, isPromotableEmployeeDelegate1);

            //fourth example
            //callign using lamba exp
            Employee.PromoteEmployee(employees, emp => emp.Salary > 52000);
        }

        public static bool IsPromotableEmployee(Employee employee)
        {
            return employee.Salary > 52000;
        }

        public static void Hello(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        //Second example
        public static void PromoteEmployee(List<Employee> employees)
        {
            //Hardcoding promote employee logic
            foreach (Employee employee in employees)
                if (employee.Experience > 3)
                    Console.WriteLine($"Employee Name : {employee.Name}");
            Console.WriteLine($"==================================================");
            Console.WriteLine($"\n\n");
            Console.WriteLine($"==================================================");
        }

        //Third & fourth example
        public static void PromoteEmployee(List<Employee> employees, IsPromotableEmployeeDelegate isPromotableEmployee)
        {
            foreach (Employee employee in employees)
                if (isPromotableEmployee(employee))
                    Console.WriteLine($"Employee Name : {employee.Name}");

            Console.WriteLine($"==================================================");
            Console.WriteLine($"\n\n");
            Console.WriteLine($"==================================================");


        }
    }
}
