using _253505_Shishov_Lab1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab1.Contracts
{
    internal interface IShop
    {
        void AddGoods(Goods goods);

        string GetOrders(string surname);

        double ShowTotalAmount(string surname);

        void RegisterOrder(string order_info, Goods[] goods);

        double GetTotalAmountByGood(Goods good);
    }
}
