using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253505_Shishov_Lab3.Contracts;

namespace _253505_Shishov_Lab3.Entities
{
    internal class Shop<T> : IShop<T>
    {
        Dictionary<string, T> goods;
        List<T> clients;

        public Shop()
        {
            goods = new Dictionary<string, T>();
            clients = new List<T>();
        }

        //standart collections
        public void AddGoods(Goods goods)
        {

        }

        public string GetOrders(string surname)
        {

        }

        public int ShowTotalAmount(string surname)
        {

        }

        public void RegisterOrder(string order_info, Goods[] goods)
        {

        }

        public int GetTotalAmountByGood(Goods good)
        {

        }

        //LINQ only
        public List<string> GetAllGoodsName()
        {

        }
        public int GetTotalGoodsAmount()
        {

        }
        public int GetTotalOrderedGoodsAmount(string client_name)
        {

        }
        public string GetTheRichestClientName()
        {

        }
        public int GetAmountOfTheReachestClieants()
        {

        }

        public List<int> GetTotalsByEveryGoods()
        {

        }
    }
}
