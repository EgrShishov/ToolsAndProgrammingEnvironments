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
        MyCustomCollection<Client> clients;

        public Shop()
        {
            clients = new MyCustomCollection<Client>();
            all_goods = new MyCustomCollection<Goods>();
        }

        public MyCustomCollection<Goods> GetGoods
        {
            get { return all_goods; }
        }

        public void AddGoods(Goods goods)
        {
            NotifyGoodsChanged?.Invoke($"Goods : list of goods changed. added {goods}");
            all_goods.Add(goods);
        }

        public void RegisterClient(Client client)
        {
            NotifyClientChanged?.Invoke($"clients : list of client changed. added {client.Name}");
            clients.Add(client);
        }

        public void RegisterOrder(Client client, MyCustomCollection<Goods> goods, int amount)
        {
            var items = "";
            foreach(var item in goods)
            {
                items += item;
            }
            NotifyOrderCreated?.Invoke($"Shop : Surname : {client.Name}, ordered : {items}");
            client.Order_journal.Add(goods);
        }

        public double GetTotalAmountByGood(Goods good)
        {
            var tmp = new Goods(0, "");
            foreach (var item in all_goods)
            {
                tmp = GenericMath<Goods>.Add<Goods>(tmp, item);
            }
            return tmp.Price;
        }

        public void ShowInfo()
        {
           foreach (var item in clients) 
            {
                Console.WriteLine(item.Name);
                foreach(var el in item.Order_journal)
                {
                    Console.WriteLine(el);
                }
            }
        }

        public string GetOrders(Client client)
        {
            string orders = "";
            foreach(var cur_client in clients)
            {
                if (cur_client.Name == client.Name)
                {
                    foreach (var item in cur_client.Order_journal)
                    {
                        foreach (var el in item)
                        {
                            orders += item.ToString() + "\n";
                        }
                    }
                }
            }
            return orders;
        }

        public double ShowTotalAmount(Client client)
        {
            var total = 0;
            foreach(var cur_client in clients)
            {
                if (cur_client.Name == client.Name)
                {
                    foreach (var item in cur_client.Order_journal)
                    {
                        foreach(var el in item)
                        {
                            total += el.Price;
                        }
                    }
                }
            }
            return total;
        }
    }
}
