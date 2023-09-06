using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab3.Entities
{
    internal class Goods
    {
        string goods_name;
        int price;
        int amount;

        public string Name
        {
            get
            {
                return this.goods_name;
            }
            set
            {
                this.goods_name = value;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }
        }

        public int Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
        public Goods(string goods_name, int price) { this.goods_name = goods_name; this.price = price; this.amount = 1; }
        public Goods(string goods_name, int price, int amount) { this.goods_name = goods_name; this.price = price; this.amount = amount; }

    }
}
