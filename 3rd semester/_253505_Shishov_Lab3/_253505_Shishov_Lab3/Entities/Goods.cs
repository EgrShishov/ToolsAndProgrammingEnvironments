using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab3.Entities
{
    internal class Goods : IAdditionOperators<Goods,Goods,Goods>
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

        public static Goods operator+(Goods a, Goods b)
        {
            return new Goods("total", a.price * a.amount + b.price * b.amount, a.amount + b.amount);
        }

        public override string ToString()
        {
            return $" name - {this.goods_name}, price - {this.price}, amount - {this.amount}";
        }

    }
}
