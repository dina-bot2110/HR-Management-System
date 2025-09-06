using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace company
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            string path_attendance = @"D:\Helper\HR Management System\attendance";
            
            if (!File.Exists(path_attendance))
            {
                using (StreamWriter writer = new StreamWriter(path_attendance, false))
                {
                    writer.WriteLine("{0,-8} {1,-8} {2,-8} {3,-10}",
                        "EmpID", "CheckIn", "CheckOut", "TotalTime");
                    writer.WriteLine(new string('-', 40));
                }
            }
            Employee emp1 = new Employee("Ahmed Ali", "IT", 1001, "Developer", 8000m);
            Employee emp2 = new Employee("Mona Hassan", "HR", 1002, "HR", 10000m);
            Employee emp3 = new Employee("Omar Khaled", "Finance", 1003, "Manager", 15000m);
            Employee emp4 = new Employee("Sara Mostafa", "IT", 1004, "Intern", 3000m);
            Employee emp5 = new Employee("Youssef Ibrahim", "Marketing", 1005, "Developer", 8500m);
            Employee emp6 = new Employee("Laila Adel", "HR", 1006, "HR", 9500m);
            Employee emp7 = new Employee("Karim Samir", "HR", 1007, "HR", 11000m);
            List<Employee> employees = new List<Employee>() { emp1, emp2, emp3, emp4, emp5, emp6, emp7};
            List<Attendance> attendances = new List<Attendance>();
            List<LeaveRequest> leaveRequests = new List<LeaveRequest>();
             
            while (true) { 
                Employee employee=new Employee();
                int employee_number = employee.login(employees);
                if (employee_number==-1)
                {
                    Console.WriteLine("Name or ID or Role is not correct");
                    continue;
                }
                if (employee.Role.Equals("admin", StringComparison.OrdinalIgnoreCase) || employee.Role.Equals("HR", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. Calculate Payroll");
                    Console.WriteLine("3. View Attendance");                    
                    Console.WriteLine("4. View Log File");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter number of your choise: ");
                    int choise = int.Parse(Console.ReadLine());
                    if (choise == 1)
                    {     
                        HR emp = new HR();
                        HR.AddEmployee(employees,emp);
                        
                    }
                    else if (choise == 2)
                    {
                        HR.ViewEmployee(employees);
                        Console.Write("Enter the employee number: ");
                        int index=int .Parse(Console.ReadLine())-1;
                        Payroll.CalculatePoyroll(index,employees,attendances);                        
                    }
                    else if (choise == 3)
                    {
                        Attendance.ViewAttendanceFile(path_attendance);
                    }                    
                    else if (choise == 4)
                    {
                        logger.ViewLog();
                    }
                    else if (choise == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("System shut down successfully.");
                        Console.ForegroundColor = ConsoleColor.White;
                        logger.Log(" System closes safely after saving data.");
                        break;
                    }
                }
                else if (employee.Role.Equals("Manager", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("1.Check-in");
                    Console.WriteLine("2.Check-out");
                    Console.WriteLine("3.Manage request Leave");
                    Console.Write("Enter number of your choise: ");
                    int choise = int.Parse(Console.ReadLine());
                    if (choise == 1)
                    {
                        Attendance.Check_in(employee_number,employees,attendances);
                        
                    }
                    else if (choise == 2)
                    {
                        Attendance.Check_out(employee_number, path_attendance, employees, attendances);
                    }
                    else if (choise == 3)
                    {
                        LeaveRequest.ViewLeaveRequests(leaveRequests);
                        Console.Write("Enter the request number you want to review: ");
                        int index = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("What modification do you want to make?");
                        Console.WriteLine("1.Approval of leave");
                        Console.WriteLine("2.Refusal to leave");
                        Console.Write("Enter the process number: ");
                        int process_number= int.Parse(Console.ReadLine());
                        if(process_number == 1)
                        {
                            LeaveRequest.Approval_of_leave(index, leaveRequests);
                        }
                        else
                        {
                            LeaveRequest.Refusal_to_leave(index, leaveRequests);
                        }
                    }                 
                }
                else //Develper || Intern
                {
                    Console.WriteLine("1.Check-in");
                    Console.WriteLine("2.Check-out");
                    Console.WriteLine("3.Request Leave");
                    Console.Write("Enter number of your choise: ");
                    int choise = int.Parse(Console.ReadLine());                    
                    if (choise == 1)
                    {
                        Attendance.Check_in(employee_number, employees, attendances);

                    }
                    else if (choise == 2)
                    {
                        Attendance.Check_out(employee_number, path_attendance, employees, attendances);
                    }
                    else if (choise == 3)
                    {
                        Console.Write("Enter the number of leave days: ");
                        int days=int.Parse(Console.ReadLine());
                        Console.Write("Enter the reason for your leave: ");
                        string reason =Console.ReadLine();
                        LeaveRequest leaveRequest = new LeaveRequest(employees[employee_number].ID, days, reason, "Pending");
                        leaveRequests.Add(leaveRequest);
                        logger.Log($"Leave request submitted by Employee {employee.Name} (ID: {employee.ID}) → Days: {days}, Reason: {reason}, Status: Pending");
                    }
                }
            }           
        }
    }
}