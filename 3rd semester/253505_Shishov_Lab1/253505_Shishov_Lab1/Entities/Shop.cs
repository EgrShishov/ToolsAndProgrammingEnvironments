using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253505_Shishov_Lab1.Collections;
using _253505_Shishov_Lab1.Contracts;

namespace _253505_Shishov_Lab1.Entities
{
    internal class Shop : IShop
    {
        MyCustomCollection<string> orders;
        MyCustomCollection<Goods> all_goods;
        Journal journal;

        public Shop()
        {
            orders = new MyCustomCollection<string>();
            journal = new Journal();
            all_goods = new MyCustomCollection<Goods>();
        }

        public MyCustomCollection<Goods> GetGoods
        {
            get { return all_goods; }
        }

        public void AddGoods(Goods goods)
        {
            all_goods.Add(goods);
        }

        public string GetOrders(string surname)
        {
            return journal.GetOrders(surname);
        }

        public double ShowTotalAmount(string surname)
        {
            return journal.GetTotal(surname);
        }

        public void RegisterOrder(string order_info, Goods[] goods)
        {
            journal.Register(order_info, goods);
        }

        public double GetTotalAmountByGood(Goods good)
        {
            var total = 0;
            for(int i=0;i<all_goods.Count; i++)
            {
                total += all_goods[i].Price;
            }
            return total;
        }
    }
}
