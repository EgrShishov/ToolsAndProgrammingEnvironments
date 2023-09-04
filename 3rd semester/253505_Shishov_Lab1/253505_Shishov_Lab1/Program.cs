using System;
using _253505_Shishov_Lab1.Collections;
using _253505_Shishov_Lab1.Entities;

 class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("hello, walter");
        Shop shop = new Shop();
        shop.AddGoods(new Goods(123, "notebook"));
        shop.AddGoods(new Goods(456, "phone"));
        shop.AddGoods(new Goods(12, "soap"));
        shop.AddGoods(new Goods(43, "walter"));
        shop.RegisterOrder("shishov", new[] { shop.GetGoods[0], shop.GetGoods[1], shop.GetGoods[2] });
        Console.WriteLine(shop.GetOrders("shishov"));
        Console.WriteLine(shop.ShowTotalAmount("shishov"));

        shop.AddGoods(new Goods(54, "charger"));
        shop.AddGoods(new Goods(523, "headphones"));
        shop.AddGoods(new Goods(443, "fridge"));

        shop.GetGoods.Next();
        shop.GetGoods.Next();
        shop.GetGoods.Next();

        shop.RegisterOrder("bekarev", new[] {shop.GetGoods.Current()});
        Console.WriteLine(shop.GetOrders("bekarev"));
        Console.WriteLine(shop.ShowTotalAmount("bekarev"));

        Console.WriteLine(shop.GetTotalAmountByGood(shop.GetGoods[0]));
    }
}