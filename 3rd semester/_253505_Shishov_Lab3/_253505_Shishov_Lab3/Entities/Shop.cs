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

        public List<Goods> GetOrders(string surname)
        {
            foreach(var client in clients)
            {
                if(client.ClientName == surname)
                {
                    return client.ClientGoods;
                }
            }
            return new List<Goods>();
        }

        public int ShowTotalAmount(string surname)
        {
            var total = 0;
            foreach(var client in clients)
            {
                if(client.ClientName == surname)
                {
                    foreach(var item in client.ClientGoods)
                    {
                        total += item.Price * item.Amount;
                    }
                }
            }
            return total;
        }

        public void RegisterOrder(Client client, Goods goods, int amount)
        {
            if (amount > 1)
            {
                goods.Amount = amount;
            }

            client.ClientGoods.Add(goods);
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
                foreach(var item in client.ClientGoods)
                {
                    if(item.Name == good.Name)
                    {
                        total += item.Price * item.Amount;
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
                from goods in client.ClientGoods
                select goods.Price * goods.Amount).Sum();
        }
        public int GetTotalOrderedGoodsAmount(string client_name)
        {
            return(
                from client in clients
                from goods in client.ClientGoods
                where client.ClientName == client_name
                select goods.Price * goods.Amount).Sum();
        }
        public string GetTheRichestClientName()
        {
            return (string)(
                from client in clients
                orderby client.ClientGoods.Sum(x => x.Price * x.Amount) descending
                select client.ClientName
                ).First();
        }
        public int GetClientsWhoPaidMoreThenSum(int sum)
        {
            return (
               from client in clients
               let tmp = client.ClientGoods.Aggregate((x, y) => x + y)
               where tmp.Price * tmp.Amount > sum
               select client.ClientName
               ).Count();
        }

        public void GetTotalsByEveryGoods(string surname)
        {
            var ans = (
                from client in clients
                where client.ClientName == surname
                let items = client.ClientGoods
                select client.ClientGoods.Count
                ).ToList();

            foreach ( var item in ans )
            {
                Console.WriteLine($"{item}");
            }
        } //not working
    }
}
