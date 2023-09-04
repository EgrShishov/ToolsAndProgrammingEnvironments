using _253505_Shishov_Lab3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab3.Contracts
{
    internal interface IShop<T>
    {
        //standart collections
        void AddGoods(Goods goods);

        string GetOrders(string surname);

        int ShowTotalAmount(string surname);

        void RegisterOrder(string order_info, Goods[] goods);

        int GetTotalAmountByGood(Goods good);

        //LINQ only
        List<string> GetAllGoodsName();
        int GetTotalGoodsAmount();
        int GetTotalOrderedGoodsAmount(string client_name);
        string GetTheRichestClientName();
        int GetAmountOfTheReachestClieants();

        List<int> GetTotalsByEveryGoods();
    }
}
