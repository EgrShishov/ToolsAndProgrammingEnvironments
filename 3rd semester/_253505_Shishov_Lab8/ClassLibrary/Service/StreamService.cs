using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary.Service
{
    public class StreamService<T>
    {
        public delegate void ProgressChangedHandler(int percentage);
        public event ProgressChangedHandler NotifyProgressChanged;

        public object? Object { get; set; }
        public StreamService() { Object = new object(); }
        public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            await Task.Run(() =>
            {
                lock (Object)
                {
                    progress?.Report(new string($"\nWritting in thread# {Thread.CurrentThread.ManagedThreadId} started\n"));
                    var amount = 0;
                    Thread.Sleep(500);
                    stream.WriteAsync(Encoding.ASCII.GetBytes("["));
                    foreach (var item in data)
                    {
                        Thread.Sleep(10);
                        JsonSerializer.SerializeAsync(stream, item, options);
                        if (amount != data.Count() - 1)
                        {
                            stream.WriteAsync(Encoding.ASCII.GetBytes(",\n"));
                        }
                        amount++;
                        progress?.Report(new string($"Thread {Thread.CurrentThread.ManagedThreadId} : {amount * 100/data.Count()} %"));
                    }
                    stream.WriteAsync(Encoding.ASCII.GetBytes("]"));
                    progress?.Report(new string($"\nWritting in thread# {Thread.CurrentThread.ManagedThreadId} finished"));

                }
            });
        }

        public async Task CopyFromStreamAsync(Stream stream, string filename, IProgress<string> progress)
        {
            await Task.Run (() =>
            {
                lock (Object)
                {
                    progress?.Report($"\nCopying in thread# {Thread.CurrentThread.ManagedThreadId} started\n");
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }
                    using (FileStream fs = new(filename, FileMode.OpenOrCreate))
                    {
                        stream.Position = 0;
                        stream.CopyToAsync(fs);
                    }
                    progress?.Report($"\nCopying in thread# {Thread.CurrentThread.ManagedThreadId} finished");
                }
            });
        }

        public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter)
        {
            var ans = 0;
            using (FileStream fs = new(fileName, FileMode.Open))
            {
                var response = await JsonSerializer.DeserializeAsync<T[]>(fs);

                if (response != null)
                {
                    foreach (var item in response)
                    {
                        if (filter(item))
                        {
                            ans++;
                        }
                    }
                }
            }
            return ans;
        }
    }
}
