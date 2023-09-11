using _253505_Shishov_Lab3.Entities;
using System.Data.Common;

Shop shop = new Shop();
Journal journal = new Journal("MyJournal");
shop.NotifyNewOrderCreated += (string desc) => Console.WriteLine($"Shop -> New Order Created");
shop.NotifyGoodsListChanged += journal.RegisterEvent;
shop.NotifyClientListChanged += journal.RegisterEvent;

shop.AddGoods("knife", new Goods("soap", 100));
shop.AddGoods("spoon", new Goods("chair", 43));
shop.AddGoods("knife", new Goods("notebook", 2134));
shop.AddGoods("spoon", new Goods("spoon", 43));

var Shishov = new Client("Shishov");
var Bekarev = new Client("Bekarev");
var Krasev = new Client("Krasev");
var Sergeev = new Client("Sergeev");

shop.RegisterOrder(Shishov, new List<Goods> { new Goods("soap", 100, 132) , new Goods("pillow", 99, 3)});
shop.RegisterOrder(Shishov, new List<Goods> { new Goods("nails", 23, 2) });
shop.RegisterOrder(Bekarev,  new List<Goods> { new Goods("chair", 43, 43) });
shop.RegisterOrder(Krasev, new List<Goods>{new Goods("notebook", 2134, 4)});
shop.RegisterOrder(Sergeev, new List<Goods> { new Goods("spoon", 43, 4000) });


Console.WriteLine("Get orders");
foreach(var order in shop.GetOrders("Shishov"))
{
    Console.WriteLine(order);
}

Console.WriteLine("------------------------");
Console.WriteLine($"Total amount for user Shishov : {shop.ShowTotalAmount("Shishov")}");
Console.WriteLine($"Total amount for user Krasev : {shop.ShowTotalAmount("Krasev")}");
Console.WriteLine($"Total amount for user Sergeev : {shop.GetTotalOrderedGoodsAmount("Sergeev")}");
Console.WriteLine($"Total amount for user Bekarev : {shop.GetTotalOrderedGoodsAmount("Bekarev")}");

var all_goods = shop.GetAllGoodsName();
Console.WriteLine($"The reachest person in this shop : {shop.GetTheRichestClientName()}");
Console.WriteLine("All goods in the shop:");
foreach(var item in all_goods)
{
    Console.WriteLine(item);
}
Console.WriteLine("------------------------");
Console.WriteLine($"Total sold goods amount : {shop.GetTotalGoodsAmount()}");
var euros = 10000;
Console.WriteLine($"Amount of clients, who paid more than {euros}$ euros : {shop.GetClientsWhoPaidMoreThenSum(euros)}");
Console.Write("Total by every good : "); shop.GetTotalsByEveryGoods("Shishov");
journal.ShowEvents();
