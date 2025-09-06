using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace company
{
    internal class Payroll
    {
        public decimal BaseSalary;
        public decimal Overtime;
        public decimal Bonus;
        public double WorkingHours;
        public static void CalculatePoyroll(int index, List<Employee> employees, List<Attendance> attendances)
        {
            string s=employees[index].Role;
            if (s == "Intern")
            {
                Console.WriteLine($"This employee's salary {employees[index].salary_:c4}");
                logger.Log($"Payroll calculated for Employee {employees[index].Name} (ID:{employees[index].ID}) → Base={employees[index].salary_:c4}, No overtime, Final={employees[index].salary_:c4}");
            }
            else if (s == "Developer")
            {
                int id = employees[index].ID;
                for (int i = 0; i < attendances.Count; i++)
                {
                    if (id == attendances[i].ID)
                    {
                        decimal Hourly_salary = employees[index].salary_ / (22 * 8);
                        decimal overtime_money = attendances[i].total_hours * Hourly_salary * 1.5m;
                        Console.WriteLine($"This employee's salary {employees[index].salary_ + overtime_money:c4}");
                        logger.Log($"Payroll calculated for Employee {employees[index].Name} (ID:{employees[index].ID}) → Base={employees[index].salary_:c4}, Overtime={overtime_money:c4}, Final={employees[index].salary_ + overtime_money:c4}");
                    }
                }
            }
            else //Manager
            {
                Console.Write("Do you want to give a bonus to this manager? (yes/no): ");
                string choice = Console.ReadLine();
                decimal bonus = 0;
                if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Enter bonus amount: ");
                    bonus = decimal.Parse(Console.ReadLine());
                }
                Console.WriteLine($"This Manager's salary: {employees[index].salary_ + bonus:c4}");
                logger.Log($"Payroll calculated for Employee {employees[index].Name} (ID:{employees[index].ID}) → Base={employees[index].salary_:c4}, Bonus={bonus:c4}, Final={employees[index].salary_ + bonus:c4}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Salary is calculated and displayed");
            Console.ForegroundColor = ConsoleColor.White;            
        }

    }
}
