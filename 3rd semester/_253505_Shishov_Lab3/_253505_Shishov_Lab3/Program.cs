using _253505_Shishov_Lab3.Entities;

Shop shop = new Shop();

shop.RegisterOrder(new Client("Shishov"), new Goods("soap", 100) , 132);
shop.RegisterOrder(new Client("Bekarev"),  new Goods("mama", 100), 43);
Console.WriteLine($"Total amount for Shishov : {shop.ShowTotalAmount("Shishov")}");

shop.AddGoods("kitchen", new Goods("knife", 13));
shop.AddGoods("kitchen", new Goods("spoon",43));

var all_goods = shop.GetAllGoodsName();
Console.WriteLine(shop.GetTheRichestClientName());
foreach(var item in all_goods)
{
    Console.WriteLine(item);
}