using System.Diagnostics;

namespace ClassLibrary
{
    public class Calculation
    {
        public delegate void CalculationHandler(int ms, double computed);
        public delegate void ProgressHandler(int percentage);

        public event ProgressHandler NotifyProgressChanged;
        public event CalculationHandler NotifyEnd;
        static Semaphore sem;
    
        public Calculation(Semaphore semaphore) 
        {
            sem = semaphore;
        }
        public void CalculateIntegral(double x)
        {
            sem.WaitOne();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            double  ans = 0;
            var n = Math.Pow(10,-4);
            var percentage = 0;

            for (double i = 0; i <= 1 ; i += n)
            {
                ans += Math.Sin(i) * n;
                for (var j = 0; j < 1000; j++) //для замедления вычислений
                {
                    var garbage = i + j;
                }
                percentage = (int)(i/1.0*100);
                NotifyProgressChanged(percentage);
            }

            percentage = 100;
            NotifyProgressChanged(percentage);
            TimeSpan time = watch.Elapsed;
            NotifyEnd(time.Milliseconds, ans);
            watch.Stop();
            sem.Release();
            return;
        }
    }
}