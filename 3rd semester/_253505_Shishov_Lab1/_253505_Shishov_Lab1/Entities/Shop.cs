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
        public delegate void GoodsHandler(string action);
        public delegate void ClientHandler(string action);
        public delegate void NewOrderHandler(string action);

        public event NewOrderHandler NotifyOrderCreated;
        public event GoodsHandler NotifyGoodsChanged;
        public event ClientHandler NotifyClientChanged;

        MyCustomCollection<Goods> all_goods;
        MyCustomCollection<string> clients;
        MyCustomCollection<(string, Goods[])> order_journal;

        public Shop()
        {
            order_journal = new MyCustomCollection<(string, Goods[])>();
            clients = new MyCustomCollection<string>();
            all_goods = new MyCustomCollection<Goods>();
        }

        public MyCustomCollection<Goods> GetGoods
        {
            get { return all_goods; }
        }

        public void AddGoods(Goods goods)
        {
            NotifyGoodsChanged($"list of goods changed. added {goods}");
            all_goods.Add(goods);
        }

        public void RegisterClient(string surname)
        {
            NotifyClientChanged($"list of client changed. added {surname}");
            clients.Add(surname);
        }

        public void RegisterOrder(string order_info, Goods[] goods)
        {
            NotifyOrderCreated($"{order_info}");
            order_journal.Add((order_info, goods));
        }

        public double GetTotalAmountByGood(Goods good)
        {
            var total = 0;
            foreach (var item in all_goods)
            {
                total += item.Price;
            }
            return total;
        }

        public void ShowInfo()
        {
           foreach (var item in order_journal) 
            {
                Console.WriteLine(item);
            }
        }

        public string GetOrders(string surname)
        {
            string orders = "";
            foreach(var order_journal_item in order_journal)
            {
                if (order_journal_item.Item1 == surname)
                {
                    foreach(var item in order_journal_item.Item2)
                    {
                        orders += item.ToString() + "\n";
                    }
                }
            }
            return orders;
        }

        public double ShowTotalAmount(string surname)
        {
            var total = 0;
            foreach(var order_journal_item in order_journal)
            {
                if (order_journal_item.Item1 == surname)
                {
                    foreach (var item in order_journal_item.Item2)
                    {
                        total += item.Price;
                    }
                }
            }
            return total;
        }
    }
}
