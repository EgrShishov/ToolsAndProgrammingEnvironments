using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab4.Entities
{
    internal class Goods
    {
        string name;
        int price;
        bool sold;

        public Goods(string name, int price, bool sold = false)
        {
            this.name = name;
            this.price = price;
            this.sold = sold;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Price
        {
            get { return price; }
            set { this.price = value; }
        }

        public bool Sold
        {
            get { return sold; }
            set { sold = value; }
        }

        public override string ToString()
        {
            return $"name - {name}, price - {price}, sold - {sold}";
        }
    }
}
