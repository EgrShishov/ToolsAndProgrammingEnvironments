
using MyMauiApp.Entities;

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
            throw new NotImplementedException();
        }
    }
}
