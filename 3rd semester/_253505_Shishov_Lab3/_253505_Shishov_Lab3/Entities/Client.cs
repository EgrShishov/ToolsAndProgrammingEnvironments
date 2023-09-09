using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab3.Entities
{
    internal class Client
    {
        List<Goods> client_goods;
        string client_name;

        public Client(string name)
        { 
            client_name = name;
            client_goods = new List<Goods>();
        }

        public List<Goods> ClientGoods
        {
            get { return client_goods; }
            set { client_goods = value; }
        }

        public string ClientName
        {
            get { return client_name; }
            set { client_name = value; }
        }

        public override string ToString()
        {
            return $" name - {client_name}";
        }
    }
}
