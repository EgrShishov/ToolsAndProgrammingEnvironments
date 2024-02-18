using CommunityToolkit.Maui.Behaviors;
using MyMauiApp.Entities;
using MyMauiApp.Services;

namespace MyMauiApp;

public partial class CurrencyConverterPage : ContentPage
{
	private IRateService rateService;
	//431, 451, 456, 429, 462, 426
	//доллар, евро, рубль, фунт, китай, швейцария
	private List<int> cur_ids = new List<int> { 431, 451, 456, 429, 462, 426 };
	private List<Rate> cur_currency = new();

    private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        if(e.NetworkAccess == NetworkAccess.Internet)
        {
            OnPageLoaded(sender, EventArgs.Empty);
        } 
        else
        {
            DisplayAlert("Ошибка", "Отсутствует подключение к интернету. Некоторые функции могут быть недоступны", "Ок");
            Label.Text = "Ошибка интернет соединения";
        }
    }
    public CurrencyConverterPage(IRateService service)
	{
		InitializeComponent();

        Connectivity.ConnectivityChanged += OnConnectivityChanged;

		rateService = service;
        BindingContext = this;

        datePicker.Date = DateTime.Now.Date;
        datePicker.MinimumDate = DateTime.Now.AddYears(-1);
        datePicker.MaximumDate = DateTime.Now;

        var validStyle = new Style(typeof(Entry));
        validStyle.Setters.Add(new Setter
        {
            Property = Entry.TextColorProperty,
            Value = Colors.Black
        });

        var invalidStyle = new Style(typeof(Entry));
        invalidStyle.Setters.Add(new Setter
        {
            Property = Entry.TextColorProperty,
            Value = Colors.Red
        });

        var textValidationBehaviour = new TextValidationBehavior
        {
            InvalidStyle = invalidStyle,
            ValidStyle = validStyle,
            Flags = ValidationFlags.ValidateOnValueChanged,
            MinimumLength = 1,
            MaximumLength = 15,
            RegexPattern = @"^-?[0-9]*[.,]?[0-9]+$"
        };

        EnterTransfer.Behaviors.Add(textValidationBehaviour);
    }

	public void OnPageLoaded(object sender, EventArgs e)
	{
        var currencyList = new List<Rate>();
        if (Connectivity.NetworkAccess != NetworkAccess.Internet) return;

		cur_currency = rateService.GetRates(DateTime.Now).Where(x => cur_ids.Contains(x.Cur_ID)).ToList();
		cur_currency.Add(new Rate { Cur_Abbreviation = "BYN", Cur_Scale = 1, Cur_OfficialRate = 1 });

		var response = rateService.GetRates(DateTime.Now);
        foreach (var rate in response)
        {
            if (cur_ids.Contains(rate.Cur_ID)) currencyList.Add(rate);
        }
        Currency.ItemsSource = currencyList;

		var cur_abbreviationList = currencyList.Select(x => x.Cur_Abbreviation).ToList();
		cur_abbreviationList.Add("BYN");

        EntryPicker.ItemsSource = OutputPicker.ItemsSource = cur_abbreviationList;
		EntryPicker.SelectedIndex = 0;
		OutputPicker.SelectedIndex = 1;
	}

    public void OnDateSelected(object sender, DateChangedEventArgs e)
	{
        if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            DisplayAlert("Ошибка", "Отсутствует подключение к интернету. Некоторые функции могут быть недоступны", "Ок");
            return;
        }

        Label.Text = $"Вы выбрали {e.NewDate.ToString("yyyy-MM-dd")}";

		var response = rateService.GetRates(e.NewDate);
		var currencyList = new List<Rate>();
		foreach (var rate in response)
		{
			if (cur_ids.Contains(rate.Cur_ID)) currencyList.Add(rate);
		}
		Currency.ItemsSource = currencyList;
	}

	public void OnEntryIndexChanged(object sender, EventArgs e)
	{
		if (EntryPicker.SelectedIndex == -1) return;
        OnInputEntryTextChanged(EnterTransfer, new TextChangedEventArgs(EnterTransfer.Text, EnterTransfer.Text));
	}

	public void OnOutputIndexChanged(object sender, EventArgs e)
	{
		if (OutputPicker.SelectedIndex == -1) return;
        OnInputEntryTextChanged(EnterTransfer, new TextChangedEventArgs(EnterTransfer.Text, EnterTransfer.Text));
    }

	public void OnInputEntryTextChanged(object sender, TextChangedEventArgs e)
	{
		decimal inputValue = 0;
		if (!decimal.TryParse(e.NewTextValue, out inputValue)) return;
		var entryIndex = EntryPicker.SelectedIndex;
		var outputIndex = OutputPicker.SelectedIndex;

		if (entryIndex == -1 || outputIndex == -1) return;
		var BYNtransfered = inputValue * cur_currency[entryIndex].Cur_OfficialRate / cur_currency[entryIndex].Cur_Scale;
		OutputTransfer.Text = Math.Round((decimal)(BYNtransfered * cur_currency[outputIndex].Cur_Scale / cur_currency[outputIndex].Cur_OfficialRate), 8).ToString();
	}

	public void OnChangeClicked(object sender, EventArgs e)
	{

	}
}