using _253505_Shishov_Lab1.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab1.Entities
{
    internal class Client
    {
        string name;
        MyCustomCollection<MyCustomCollection<Goods>>? order_journal;
        public Client(string name) { this.name = name; order_journal = new MyCustomCollection<MyCustomCollection<Goods>>(); }

        public string Name { get { return name; } }

        public MyCustomCollection<MyCustomCollection<Goods>> Order_journal { get { return order_journal; }}
    }
}
