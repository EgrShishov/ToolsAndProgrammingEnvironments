
using MyMauiApp.Entities;
using System.Net.Http.Json;

namespace MyMauiApp.Services
{
    public class RateService : IRateService
    {
        private HttpClient httpClient = null;
        public RateService(HttpClient client)
        {
            httpClient = client;
        }
        public IEnumerable<Rate> GetRates(DateTime date)
        {
            return Task.Run(async () => await httpClient.GetFromJsonAsync<List<Rate>>(new Uri(httpClient.BaseAddress,$"?ondate={date.ToString("yyyy-MM-dd")}&periodicity=0"))).Result.ToList();
        }
    }
}
