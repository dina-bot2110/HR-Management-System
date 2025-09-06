using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company
{
    public class Attendance
    {
        public int ID;
        public int hourIn;
        public int minuteIn;        
        public decimal total_hours;

        public static void AppendAttendanceRecord(string filePath, int empId, string checkIn, string checkOut, string total_time)
        {          
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("{0,-8} {1,-8} {2,-8} {3,-10}",
                    empId, checkIn, checkOut, total_time);
            }
        }
        public static void Check_in(int employee_number, List<Employee> employees, List<Attendance> attendances)
        {
            Attendance attendance = new Attendance();
            attendance.ID = employees[employee_number].ID;            
            Console.Write("Enter check-in hour (0-23): ");
            attendance.hourIn= int.Parse(Console.ReadLine());
            Console.Write("Enter check-in minute: ");
            attendance.minuteIn = int.Parse(Console.ReadLine());
            bool flag = true;
            for (int i = 0; i < attendances.Count; i++)
            {
                if(attendance.ID==attendances[i].ID)
                {
                    flag = false;
                    attendances[i].hourIn=attendance.hourIn;
                    attendances[i].minuteIn=attendance.minuteIn;                   
                }               
            }
            if (flag)
            {                
                attendances.Add(attendance);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Check in is recorded successfully.");
            Console.ForegroundColor = ConsoleColor.White;
            logger.Log($"Employee ID {attendance.ID} checked in at {attendance.hourIn}:{attendance.minuteIn}");
        }
        public static void Check_out(int employee_number, string filePath, List<Employee> employees, List<Attendance> attendances)
        {       
            Console.Write("Enter check-out hour (0-23): ");
            int hourOut = int.Parse(Console.ReadLine());
            Console.Write("Enter check-out minute: ");
            int minuteOut = int.Parse(Console.ReadLine());            
            for (int i = 0; i < attendances.Count; i++)
            {
                if (employees[employee_number].ID == attendances[i].ID)
                {
                    if (minuteOut < attendances[i].minuteIn) {
                        minuteOut += 60;
                        hourOut--;
                    }                    
                    int total_minute = (minuteOut - attendances[i].minuteIn);
                    decimal over_time =(hourOut - attendances[i].hourIn)+(total_minute/60)-8;
                    if (over_time > 0)
                        attendances[i].total_hours += over_time;
                    AppendAttendanceRecord(filePath, attendances[i].ID, $"{attendances[i].hourIn}:{attendances[i].minuteIn}", $"{hourOut}:{minuteOut}", $"{hourOut - attendances[i].hourIn}:{total_minute}");
                } 
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Check out is recorded successfully.");
            Console.ForegroundColor = ConsoleColor.White;
            logger.Log($"Employee ID {employees[employee_number].ID} checked in at {hourOut}:{minuteOut}");
        }
        public static void ViewAttendanceFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Attendance file not found!");
            }
        }

    }
}
