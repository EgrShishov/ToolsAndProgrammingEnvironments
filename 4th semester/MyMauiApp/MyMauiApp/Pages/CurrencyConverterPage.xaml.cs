using MyMauiApp.Entities;
using MyMauiApp.Services;

namespace MyMauiApp;

public partial class CurrencyConverterPage : ContentPage
{
	private IRateService rateService;
	//431, 451, 456, 429, 462, 426
	//доллар, евро, рубль, фунт, китай, швейцария
	private List<int> cur_ids = new List<int> { 431, 451, 456, 429, 462, 426 };
    public CurrencyConverterPage()//(IRateService service)
	{
		InitializeComponent();

		//rateService = service;
		rateService = new RateService();
		BindingContext = this;
	}

	public void OnPageLoaded(object sender, EventArgs e)
	{
		datePicker.Date = DateTime.Now.Date;
		datePicker.MinimumDate = DateTime.Now.AddYears(-1);
		datePicker.MaximumDate = DateTime.Now;

        var response = rateService.GetRates(DateTime.Now);
        var currencyList = new List<Rate>();
		foreach (var rate in response)
		{
			if(cur_ids.Contains(rate.Cur_ID)) currencyList.Add(rate);
		}
		Currency.ItemsSource = currencyList;
	}

	public void OnDateSelected(object sender, DateChangedEventArgs e)
	{
		Label.Text = $"Вы выбрали {e.NewDate.ToString("yyyy-MM-dd")}";

		var response = rateService.GetRates(e.NewDate);
        var currencyList = new List<Rate>();
        foreach (var rate in response)
        {
            if (cur_ids.Contains(rate.Cur_ID)) currencyList.Add(rate);
        }
        Currency.ItemsSource = currencyList;
    }
}