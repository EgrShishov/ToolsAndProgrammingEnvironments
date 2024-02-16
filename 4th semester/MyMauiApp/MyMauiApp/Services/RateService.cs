
using MyMauiApp.Entities;
using System.Net.Http.Json;

namespace MyMauiApp.Services
{
    public class RateService : IRateService
    {
        private readonly HttpClient httpClient;
        public RateService() 
        { 
            httpClient = new HttpClient { BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates") };
        }
        public IEnumerable<Rate> GetRates(DateTime date)
        {
            var rates = new List<Rate>();
            var response = Task.Run(async () => await httpClient.GetFromJsonAsync<List<Rate>>(new Uri(httpClient.BaseAddress,$"?ondate={date.ToString("yyyy-MM-dd")}&periodicity=0"))).GetAwaiter();
            
            var data = response.GetResult();
            foreach (var rate in data)
            {
                rates.Add(rate);
            }
            return rates;
        }
    }
}
