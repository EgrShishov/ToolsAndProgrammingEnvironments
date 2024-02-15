using MyMauiApp.Entities;

namespace MyMauiApp.Services
{
    public interface IRateService
    {
        IEnumerable<Rate> GetRates(DateTime date);
    }
}
