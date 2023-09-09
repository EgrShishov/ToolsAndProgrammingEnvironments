using _253505_Shishov_Lab1.Collections;
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

        string GetOrders(Client client);

        double ShowTotalAmount(Client client);

        void RegisterOrder(Client client, MyCustomCollection<Goods> goods, int amount);

        double GetTotalAmountByGood(Goods good);


    }
}
