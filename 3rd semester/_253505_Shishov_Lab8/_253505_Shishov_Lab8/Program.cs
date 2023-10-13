using ClassLibrary;
using ClassLibrary.Service;
using ClassLibrary.Entities;
using LoremNET;

class Program
{
    static async Task Main(string[] args)
    {
        Func<Goods, bool> filter = (goods) =>
        {
            return goods.isOverdue;
        };

        Console.CursorVisible = false;
        Console.WriteLine("Hello, Walter!");
        Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} started");

        var collection = new List<Goods>();
        Random rand = new Random();
        StreamService<Goods> ss = new StreamService<Goods>(new Semaphore(1,1));
        MemoryStream mStream = new();
        for (int i = 0; i < 1000; i++)
        {
            collection.Add(new Goods(rand.Next(), Lorem.Words(1), Convert.ToBoolean(Lorem.Number(0,1))));
        }
        
        var progressBar = new Progress<string>(str => Console.Write($"\r{str}"));
        var task1 =  ss.WriteToStreamAsync(mStream, collection, progressBar);
        Task.Delay(200);
        var task2 = ss.CopyFromStreamAsync(mStream, "test.json", progressBar);
        Task.WaitAll(task1, task2);
        var ans = await ss.GetStatisticsAsync("test.json", filter);
        Console.WriteLine($"\n Amount of overdue goods : {ans}");
    }
}