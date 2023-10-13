using ClassLibrary;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Walter!");
        var calcul = new Calculation(new Semaphore(4, 9)); //можно менять, чтобы задать нужное количество выполняемых потоков 
        calcul.NotifyProgressChanged += (int percentage) =>
        {
            lock (Console.Out)
            {
                Console.SetCursorPosition(0, 2*int.Parse(Thread.CurrentThread.Name)+1);
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string bar = $"Поток #{Thread.CurrentThread.Name} [";
                for (int i = 0; i <= 100; i++)
                {
                    if (i < percentage)
                    {
                        bar += "=";
                    }
                    else if (i == percentage)
                    {
                        if (percentage == 100)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        bar +=">";
                    }
                }

                Console.Write($"\r{bar}] {percentage}%");
            }
        };
        calcul.NotifyEnd += (time, ans) => 
        {
            lock (Console.Out)
            {
                Console.SetCursorPosition(0, 2*int.Parse(Thread.CurrentThread.Name)+2);
                Console.CursorVisible = false;
                Console.Write(
                    $"Поток #{Thread.CurrentThread.Name}: Завершен с результатом : {ans}, {time} ms\n");
            }
        }
        ;
        
        Thread first = new(() => calcul.CalculateIntegral(100));
        first.Name = "1";
        first.Priority = ThreadPriority.Highest;
        Thread second = new(() => calcul.CalculateIntegral(100));
        second.Name = "2";
        second.Priority = ThreadPriority.Lowest;
        Thread third = new(() => calcul.CalculateIntegral(100));
        third.Name = "3";
        Thread fourth = new(() => calcul.CalculateIntegral(100));
        fourth.Name = "4";
        Thread fifth = new(() => calcul.CalculateIntegral(100));
        fifth.Name = "5";
        
        for (int i = 0; i < 9; i++)
        {
            Thread thr = new(()=>calcul.CalculateIntegral(100));
            thr.Name = $"{i + 1}";
            thr.Start();
        }
        //first.Start();
        //second.Start();
        //third.Start();
        //fourth.Start();
        //fifth.Start();
    }
}