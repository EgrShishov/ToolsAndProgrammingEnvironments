using ClassLibrary;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        //говновывод в консоль нужно доработать
        Console.WriteLine("Hello, Walter!");
        var calcul = new Calculation(new Semaphore(3, 5)); //можно менять, чтобы задать нужное количество выполняемых потоков 
        calcul.NotifyProgressChanged += (int percentage) =>
        {
            var line = 0;
            switch (Thread.CurrentThread.Name)
            {
                case "1":
                    line = 2; break;
                case "2":
                    line = 4; break;
                case "3":
                    line = 6; break;
                case "4":
                    line = 8; break;
                case "5":
                    line = 10; break;
            }
            Console.SetCursorPosition(0, line);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            string bar = $"Поток #{Thread.CurrentThread.ManagedThreadId}, {Thread.CurrentThread.Name} [";
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
        };
        calcul.NotifyEnd += (time, ans) => 
        {
            var line = 0;
            switch (Thread.CurrentThread.Name)
            {
                case "1":
                    line = 3; break;
                case "2":
                    line = 5; break;
                case "3":
                    line = 7; break;
                case "4":
                    line = 9; break;
                case "5":
                    line = 11; break;
            }
            Console.SetCursorPosition(0, line);
            Console.CursorVisible = false;
            Console.WriteLine($"\nПоток #{Thread.CurrentThread.ManagedThreadId}: Завершен с результатом : {ans}, {time} ms");
        }
        ;

        Thread first = new(() => calcul.CalculateIntegral(100));
        first.Name = $"1";
        first.Priority = ThreadPriority.Highest;
        Thread second = new(() => calcul.CalculateIntegral(100));
        second.Name = "2";
        second.Priority = ThreadPriority.Lowest;
        Thread third = new(() => calcul.CalculateIntegral(100));
        third.Name = $"3";
        Thread fourth = new(() => calcul.CalculateIntegral(100));
        fourth.Name = $"4";
        Thread fifth = new(() => calcul.CalculateIntegral(100));
        fifth.Name = $"5";

        calcul.CalculateIntegral(100);
        first.Start();
        second.Start();
        third.Start();
        fourth.Start();
        fifth.Start();
    }
}