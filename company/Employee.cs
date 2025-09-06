using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company
{
    public class Employee
    {
        public int ID;
        public string Name;
        public string Department;
        private decimal Salary;
        public string Role;
        public decimal salary_
        {
            get
            {
                return Salary;
            }
            set
            {
                Salary = value;
            }
        }
        public int login(List<Employee>employees)
        {
            Console.WriteLine("-------------------------login------------------------- ");
            int employee_number = -1;// رقم الموظف اللي دخل
            Console.Write($"Enter your name: ");
            Name = Console.ReadLine();
            Console.Write($"Enter your ID: ");
            ID = int .Parse(Console.ReadLine());
            Console.Write($"Enter your department: ");
            Department = Console.ReadLine();
            Console.Write($"Enter your roll: ");
            Role = Console.ReadLine();
            for (int i = 0; i < employees.Count; i++)
            {
                //بشوف في موظف بالبيانات اللي هو دخلها ولا لا و بتجاهل حالة الحروف 
                if (employees[i].ID == ID&& employees[i].Role.Equals(Role, StringComparison.OrdinalIgnoreCase) && employees[i].Name.Equals(Name, StringComparison.OrdinalIgnoreCase) && employees[i].Department.Equals(Department, StringComparison.OrdinalIgnoreCase))
                    employee_number=i; //لو لقيت موظف بالبيانات اللي دخلت بغير رقم الموظف
            }
                return employee_number; //برجع رقم الموظف علشان لو ب -1 اعرف ان مفيش موظف بالبيانات دي
        }

        public Employee(string n,string d, int i, string r, decimal s)//constructor
        {
           ID=i;
           Name=n;
           Department=d;
           Salary=s;
           Role=r;
        }
        public Employee() { } //constructor

    }
}
