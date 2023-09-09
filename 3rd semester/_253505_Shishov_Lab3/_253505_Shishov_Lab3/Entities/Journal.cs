using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab3.Entities
{
    internal class Journal
    {
        List<string> events;
        string name;

        public Journal(string name) { events = new List<string>(); this.name = name; }
        public void ShowEvents()
        {
            Console.WriteLine("------------------------");
            foreach (var e in events)
            {
                Console.WriteLine($"{e}");
            }
            Console.WriteLine("------------------------");
        }

        public void RegisterEvent(string desc)
        {
            events.Add(desc);
        }
    }
}
