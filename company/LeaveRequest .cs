using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company
{
    internal class LeaveRequest
    {
        public int emId;
        public int Days;
        public string Reason;
        public string Status; //Pending / Approved / Rejected
        public LeaveRequest(int emId, int days, string reason, string status)
        {
            this.emId = emId;
            Days = days;
            Reason = reason;
            Status = status;
        }
        public static void ViewLeaveRequests(List<LeaveRequest> leaveRequests)
        {
            Console.WriteLine("{0,-3} {1,-10} {2,-6} {3,-25} {4,-10}",
                "#", "EmpId", "Days", "Reason", "Status");
            Console.WriteLine(new string('-', 60));

            for (int i = 0; i < leaveRequests.Count; i++)
            {
                Console.WriteLine("{0,-3} {1,-10} {2,-6} {3,-25} {4,-10}",
                    (i + 1) + ".",
                    leaveRequests[i].emId,
                    leaveRequests[i].Days,
                    leaveRequests[i].Reason,
                    leaveRequests[i].Status);
            }
        }
        public static void Approval_of_leave(int index, List<LeaveRequest> leaveRequests)
        {
            leaveRequests[index].Status = "Approved";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leave request is updated successfully.");
            Console.ForegroundColor = ConsoleColor.White;
            logger.Log($"Leave request Approved for Employee ID: {leaveRequests[index].emId} → Days: {leaveRequests[index].Days}");
        }
        public static void Refusal_to_leave(int index, List<LeaveRequest> leaveRequests)
        {
            leaveRequests[index].Status = "Rejected";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leave request is updated successfully.");
            Console.ForegroundColor = ConsoleColor.White;
            logger.Log($"Leave request Rejected for Employee ID: {leaveRequests[index].emId} → Days: {leaveRequests[index].Days}, Reason: {leaveRequests[index].Reason}");
        }  
         
    }
}
