using _253505_Shishov_Lab1.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab1.Entities
{
    internal class Journal
    {
        MyCustomCollection<string> events;

        public Journal() { events = new MyCustomCollection<string>();}
        public void ShowEvents()
        {
            foreach (var e in events)
            {
                Console.WriteLine($"{e}\n");
            }
            Console.WriteLine("----------------");
        }

        public void RegisterEvent(string desc)
        {
            events.Add(desc);
        }
    }
}
