using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProjectTest2
{
    internal class ViewSchedule
    {
        //sata structure
        private readonly (string Date, string Time, string Duration)[] events;

        public ViewSchedule()
        {
            //Initialize with preset schedule
            events = new[]
            {
                ("August 19", "10:00", "2 hours"),
                ("August 20", "13:00", "1.5 hours"),
                ("August 21", "03:00", "3 hours"),
                ("August 22", "09:30", "1 hours"),
            };
        }

        //Method to display schedule
        public void DisplaySchedule()
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-10}", "Date", "Time", "Duration");
            Console.WriteLine(new string('-', 40));

            foreach (var evt in events)
            {
                Console.WriteLine("{0,-15} {1,-10} {2,-10}", evt.Date, evt.Time, evt.Duration);
            }
        }
    }
}
