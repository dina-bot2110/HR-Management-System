using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace company
{
    public class HR:Employee
    {
        public static void AddEmployee(List<Employee>employees,HR emp)
        {

            Console.Write($"Name of new employee: ");
            emp.Name = Console.ReadLine();
            Console.Write($"ID of new employee: ");
            emp.ID = int.Parse(Console.ReadLine());
            Console.Write($"Department of new employee: ");
            emp.Department = Console.ReadLine();
            Console.Write($"Roll of new employee: ");
            emp.Role = Console.ReadLine();
            Console.Write($"Salary of new employee: ");
            emp.salary_ =decimal.Parse(Console.ReadLine());
            employees.Add(emp);
            Console.ForegroundColor =ConsoleColor.Red;
            Console.WriteLine("Employee is added successfully.");
            Console.ForegroundColor = ConsoleColor.White;
            logger.Log($"Employee {emp.Name}, whose ID is {emp.ID}, has been added with a salary of {emp.salary_}");            
        }

        public static void ViewEmployee(List<Employee> employees)
        {
            Console.WriteLine("{0,-3} {1,-20} {2,-6} {3,-15} {4,-15} {5,-10}",
        "#", "Name", "ID", "Department", "Role", "Salary");
            Console.WriteLine(new string('-', 75));

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine("{0,-3} {1,-20} {2,-6} {3,-15} {4,-15} {5,-10}",
                    (i + 1) + ".",
                    employees[i].Name,
                    employees[i].ID,
                    employees[i].Department,
                    employees[i].Role,
                    employees[i].salary_);
            }
        }
    }
}
