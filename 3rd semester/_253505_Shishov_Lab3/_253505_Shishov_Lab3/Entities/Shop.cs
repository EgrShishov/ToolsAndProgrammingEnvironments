using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253505_Shishov_Lab3.Contracts;
using System.Numerics;
using System.ComponentModel.Design;

namespace _253505_Shishov_Lab3.Entities
{
    internal class Shop : IShop
    {
        Dictionary<string, Goods> goods_list;
        List<Client> clients;

        public delegate void NewOrderHandler(string desc);
        public delegate void ClientHandler(string desc);
        public delegate void GoodsHandler(string desc);
        public event NewOrderHandler NotifyNewOrderCreated;
        public event ClientHandler NotifyClientListChanged;
        public event GoodsHandler NotifyGoodsListChanged;

        public Shop()
        {
            goods_list = new Dictionary<string, Goods>();
            clients = new List<Client>();
        }

        //standart collections
        public void AddGoods(string category, Goods new_goods)
        {
            if (!goods_list.ContainsValue(new_goods))
            {
                goods_list[category] = new_goods;
                NotifyGoodsListChanged?.Invoke($"Shop -> added goods :{new_goods}");
            }
            else
            {
                throw new Exception("We already have such item in our shop");
            }
        }

        public List<Order> GetOrders(string surname)
        {
            foreach(var client in clients)
            {
                if(client.ClientName == surname)
                {
                    return client.ClientOrders;
                }
            }
            return new List<Order>();
        }

        public int ShowTotalAmount(string surname)
        {
            var total = 0;
            foreach(var client in clients)
            {
                if(client.ClientName == surname)
                {
                    foreach(var order in client.ClientOrders)
                    {
                        foreach (var item in order.Goods)
                        {
                            total += item.Price * item.Amount;
                        }
                    }
                }
            }
            return total;
        }

        public void RegisterOrder(Client client, List<Goods> goods)
        {
            var order = new Order(goods);
            client.ClientOrders.Add(order);
            NotifyClientListChanged?.Invoke($"Shop -> client {client} was added");

            if (!clients.Contains(client))
            {
                clients.Add(client);
                NotifyNewOrderCreated?.Invoke($"Shop -> New Order Created");
            }
        }

        public int GetTotalAmountByGood(Goods good)
        {
            var total = 0;
            foreach(var client in clients)
            {
                foreach(var order in client.ClientOrders)
                {
                    foreach (var item in order.Goods)
                    {
                        if (item.Name == good.Name)
                        {
                            total += item.Price * item.Amount;
                        }
                    }
                }
            }
            return total;
        }

        //LINQ only
        public List<string> GetAllGoodsName()
        {
            Console.WriteLine(goods_list.Count);
            return
                (
                from goods in goods_list
                orderby goods.Value.Price
                select goods.Value.Name
                ).ToList();
            
        }
        public int GetTotalGoodsAmount()
        {
            return(
                from client in clients
                from order in client.ClientOrders
                from goods in order.Goods
                select goods.Price * goods.Amount).Sum();
        }
        public int GetTotalOrderedGoodsAmount(string client_name)
        {
            return(
                from client in clients
                from order in client.ClientOrders
                from goods in order.Goods
                where client.ClientName == client_name
                select goods.Price * goods.Amount).Sum();
        }
        public string GetTheRichestClientName()
        {
            return (string)(
                from client in clients
                from order in client.ClientOrders
                orderby order.Goods.Sum(x => x.Price * x.Amount) descending
                select client.ClientName
                ).First();
        }
        public int GetClientsWhoPaidMoreThenSum(int sum)
        {
            return (
               from client in clients
               let tmp = client.ClientOrders
               from order in tmp 
               let mama = order.Goods.Aggregate((x, y) => x + y)
               where mama.Price * mama.Amount > sum
               select client.ClientName
               ).Count();
        }

        public void GetTotalsByEveryGoods(string surname)
        {
            var client = new Client("");
            var goods_list = new List<Goods>();
            var i = 0;
            foreach(var it in clients)
            {
                if(it.ClientName == surname)
                {
                   client = it;
                   foreach (var item in it.ClientOrders)
                   {
                        foreach(var goods in item.Goods)
                        {
                            goods_list.Add(goods);
                            i++;
                        }
                   }
                   break;
                }
            }
            List<(string, int)> totals = new();
            var ans = goods_list
                .GroupBy(x => x.Price)
                .First()
                .Sum(x => x.Price * x.Amount);
            Console.WriteLine(ans);
        }
    }
}
