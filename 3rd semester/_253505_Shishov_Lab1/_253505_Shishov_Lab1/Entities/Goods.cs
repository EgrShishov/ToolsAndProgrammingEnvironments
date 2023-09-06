using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _253505_Shishov_Lab1.Collections;

namespace _253505_Shishov_Lab1.Entities
{
    internal class Goods : IAdditionOperators<Goods, Goods, Goods>
    {
        int price;
        string goods_name;

        public Goods(int price, string name)
        {
            this.price = price;
            goods_name = name;
        }

        public int Price { get { return price; } }

        public override string ToString()
        {
            return $"price : {price}, product_name : {goods_name}";
        }

        public static Goods operator +(Goods a, Goods b)
        {
            return new Goods(a.Price + b.Price, "");
        }
    }
}
