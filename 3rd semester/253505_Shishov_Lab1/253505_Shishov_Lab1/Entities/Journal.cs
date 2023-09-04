using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253505_Shishov_Lab1.Collections;

namespace _253505_Shishov_Lab1.Entities
{
    internal class Journal
    {
        MyCustomCollection<(string, Goods[])> order_journal;

        public Journal()
        {
            order_journal = new MyCustomCollection<(string, Goods[])>();
        }

        public void Register(string order_info, Goods[] goods)
        {
            order_journal.Add((order_info, goods));
        }

        public void ShowInfo()
        {
            for (int i = 0; i<order_journal.Count; i++)
            {
                Console.WriteLine(order_journal[i]);
            }
        }

        public string GetOrders(string surname)
        {
            string orders = "";
            for (int i = 0; i < order_journal.Count; i++)
            {
                if (order_journal[i].Item1 == surname)
                {
                    foreach(var item in order_journal[i].Item2)
                    {
                        orders += item.ToString() + "\n";
                    }
                }
            }
            return orders;
        }

        public double GetTotal(string surname)
        {
            var total = 0;
            for(int i = 0; i < order_journal.Count; i++)
            {
                if (order_journal[i].Item1 == surname)
                {
                    foreach (var item in order_journal[i].Item2)
                    {
                        total += item.Price;
                    }
                }
            }
            return total;
        }
    }
}
