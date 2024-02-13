
namespace MyMauiApp;

public partial class ProgressBarPage : ContentPage
{
	public ProgressBarPage()
	{
		InitializeComponent();
	}

	static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
	CancellationToken cancellationToken = cancellationTokenSource.Token;
	private void ButtonPressed(object sender, EventArgs e)
	{
		((Button)sender).BackgroundColor = Microsoft.Maui.Graphics.Color.FromRgba("#4f6354");
	}

	private void ButtonRealesed(object sender, EventArgs e)
	{
        ((Button)sender).BackgroundColor = Colors.SeaGreen;
	}

	private async void StartCalculation(object sender, EventArgs e)
	{
		StartButton.IsEnabled = false;
		CancelButton.IsEnabled = true;

		progressBar.Progress = 0;
		TopLabel.Text = "Вычисление";

        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;

        await Calculation();
    }

	private void CancelCalculation(object sender, EventArgs e)
	{
		if (cancellationTokenSource == null) return;
		cancellationTokenSource.Cancel();
		StartButton.IsEnabled = true;
		CancelButton.IsEnabled = false;
		TopLabel.Text = "Процесс отменен";
	}

	private async Task Calculation()
	{
        var result = 0.0;
        TopLabel.Text = "Вычисление";
        var h = 1E-3;
        var a = 0.0; var b = 1.0;
		for (double i = a; i < b; i += h)
		{
			if (cancellationToken.IsCancellationRequested) return;
			result += Math.Sin(i) * h;
			await progressBar.ProgressTo(i, 1, Easing.Linear);
			ProgressBarLabel.Text = $"Состояние процесса: {Math.Round(i*100, 2)}%";
		}
        TopLabel.Text = $"Процесс завершён с результатом : {result}";
        StartButton.IsEnabled = true;
        CancelButton.IsEnabled = false;
    }
}