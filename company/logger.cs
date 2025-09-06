using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company
{
    internal class logger
    {
        private static string path_log_file = @"D:\Helper\HR Management System\system.log";
        public static void Log(string action)
        {
            using (StreamWriter writer = new StreamWriter(path_log_file, true))
            {
                writer.WriteLine($"{DateTime.Now}: {action}");
            }
        }
        public static void ViewLog()
        {            
            if (File.Exists(path_log_file))
            {
                string[] lines = File.ReadAllLines(path_log_file);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Log file not found!");
            }
        }
    }
} 