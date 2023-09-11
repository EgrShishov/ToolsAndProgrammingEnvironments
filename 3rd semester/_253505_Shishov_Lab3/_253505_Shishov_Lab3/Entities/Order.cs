using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab3.Entities
{
    internal class Order
    {
        List<Goods> goods;
        
        public Order(List<Goods> goods) { this.goods = goods; }

        public List<Goods> Goods
        {
            get
            {
                return goods;
            }
            set
            {

            }
        }
        public override string ToString()
        {
            string goods_str = "";
            foreach(var goods in this.goods)
            {
                goods_str += goods;
            }
            return $" Ordered -> {goods_str}";
        }
    }
}
