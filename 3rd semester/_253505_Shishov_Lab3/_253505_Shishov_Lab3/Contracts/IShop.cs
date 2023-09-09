using _253505_Shishov_Lab3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab3.Contracts
{
    internal interface IShop
    {
        //standart collections
        void AddGoods(string category, Goods goods);

        List<Goods> GetOrders(string surname);

        int ShowTotalAmount(string surname);

        void RegisterOrder(Client client, Goods goods, int amount);

        int GetTotalAmountByGood(Goods good);

        //LINQ only
        List<string> GetAllGoodsName();
        int GetTotalGoodsAmount();
        int GetTotalOrderedGoodsAmount(string client_name);
        string GetTheRichestClientName();
        public int GetClientsWhoPaidMoreThenSum(int sum);

        void GetTotalsByEveryGoods(string surname);
    }
}
