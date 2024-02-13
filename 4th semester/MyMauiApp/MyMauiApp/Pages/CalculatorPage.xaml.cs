
namespace MyMauiApp;

public partial class CalculatorPage : ContentPage
{
    private Stack<double> memory = new Stack<double>();
    private string first = "";
    private string second = "";
    private string op = "";
    private string ans = "";
	public CalculatorPage()
	{
		InitializeComponent();
	}

    private void OnButtonPressed(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        btn.BackgroundColor = Color.FromRgba("#d3e7e8");
    }

    private void OnButtonRealesed(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        btn.BackgroundColor = Color.FromRgba("#F0FFFF");
    }

	private void OnPercentButtonClicked(object sender, System.EventArgs e)
	{
		Button btn = (Button)sender;
        if (op != "") return;
        if (double.TryParse(first, out double parsedFirst))
        {
            parsedFirst /= 100;
            first = Convert.ToString(parsedFirst);
            CalculatorLabel.Text = first;
        }
    }

	private void OnCEButtonClicked(object sender, System.EventArgs e)
	{
        CalculatorLabel.Text = "0";
        TopCalculatorLabel.Text = "";
        first = "";
        second = "";
        op = "";
        ans = "";
        CalculatorLabel.TextColor = Colors.Black;
	}

    private void OnCButtonClicked(object sender, System.EventArgs e)
    {
        CalculatorLabel.Text = "0";
        first = "";
        second = "";
        op = "";
        ans = "";
        CalculatorLabel.TextColor = Colors.Black;
    }

    private void OnDeleteButtonClicked(object sender, System.EventArgs e)
    {
        if (CalculatorLabel.Text.Last() == '-' || CalculatorLabel.Text.Last() == '+' || CalculatorLabel.Text.Last() == '*' || CalculatorLabel.Text.Last() == '÷' && CalculatorLabel.Text.Length > 1)
        {
            var text = CalculatorLabel.Text;
            CalculatorLabel.Text = text.Remove(text.Length - 1, 1);
            op = "";
        }

        if (CalculatorLabel.Text.Length == 1)
        {
            CalculatorLabel.Text = "0";
            first = "";
            second = "";
            return;
        }

        if (op == "" && first.Length > 0)
        {
            first = first.Remove(first.Length - 1, 1);
            CalculatorLabel.Text = first;
        } 
        else
        {
            second = second.Remove(second.Length - 1, 1);
            CalculatorLabel.Text = second;
        }

    }
    private void OnReverseButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        if(double.TryParse(first, out double parsedFirst))
        {
            if(parsedFirst == 0)
            {
                ShowError("Деление на ноль!");
                first = "";
                second = "";
                ans = "";
                op = "";
                return;
            }
            var result = 1/parsedFirst;
            ans = first = result.ToString();
            CalculatorLabel.Text = ans;
        }

    }
    private void OnSquareButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        var parsedNumber = .0;
        if (op != "") double.TryParse(second, out parsedNumber);
        else double.TryParse(first, out parsedNumber);
        var result = Math.Pow(parsedNumber,2);
        if (op == "")
        {
            ans = first = result.ToString();
            ShowAnswer();
            TopCalculatorLabel.Text = $"sqr({parsedNumber})";
            return;
        }
        second = result.ToString();
        TopCalculatorLabel.Text += $"sqr({parsedNumber})=";
    }

    private void OnSqrtButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        var parsedNumber = .0;    
        if (op != "") double.TryParse(second, out parsedNumber);
        else double.TryParse(first, out parsedNumber);
        var result = Math.Sqrt(parsedNumber);
        if (op == "")
        {
            ans = first = result.ToString();
            ShowAnswer();
            TopCalculatorLabel.Text = $"sqrt({parsedNumber})";
            return;
        }
        second = result.ToString();
        TopCalculatorLabel.Text += $"sqrt({parsedNumber})=";
    }

    private void OnExpButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        var parsedNumber = .0;
        if (op != "") double.TryParse(second, out parsedNumber);
        else double.TryParse(first, out parsedNumber);
        var result = Math.Exp(parsedNumber);
        if (op == "")
        {
            ans = first = result.ToString();
            ShowAnswer();
            TopCalculatorLabel.Text = $"exp({parsedNumber})";
            return;
        }
        second = result.ToString();
        TopCalculatorLabel.Text += $"exp({parsedNumber})=";
    }

    private void OnDivisionButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        //if (op != "") return;
        op = btn.Text;
        TopCalculatorLabel.Text = "";
        if (first == "") first = "0";
        TopCalculatorLabel.Text += first + btn.Text;
    }

    private void OnNumberButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        if(op == "")
        {
            if (first == "") CalculatorLabel.Text = "";
            first += btn.Text;
        }
        else
        {
            if (second == "") CalculatorLabel.Text = "";
            second += btn.Text;
        }
        CalculatorLabel.Text += btn.Text;
    }

    private void OnMultiplyButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        //if (op != "") return;
        op = btn.Text;
        TopCalculatorLabel.Text = "";
        if (first == "") first = "0";
        TopCalculatorLabel.Text += first + btn.Text;
    }

    private void OnPlusButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        //if (op != "") return;
        op = btn.Text;
        TopCalculatorLabel.Text = "";
        if (first == "") first = "0";
        TopCalculatorLabel.Text += first + btn.Text;
    }
    private void OnMinusButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        //if (op != "") return;
        op = btn.Text;
        TopCalculatorLabel.Text = "";
        if (first == "") first = "0";
        TopCalculatorLabel.Text += first + btn.Text;
    }

    private void OnComaButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        if(op == "")
        {
            if (first.Contains(',')) return;
            CalculatorLabel.Text += btn.Text;
            first += btn.Text;
        }
        else
        {
            if (second.Contains(',')) return;
            CalculatorLabel.Text += btn.Text;
            second += btn.Text;
        }
    }

    private void OnInverseSignButtonClicked(object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        if (first == "") return;
        if (first.Contains("-")) first = first.Remove(0, 1);
        else first = first.Insert(0, "-");
        CalculatorLabel.Text = first;
    }

    private void OnAnswerButtonClicked(object sender, System.EventArgs e)
    {
        Calculate();
        CalculatorLabel.TextColor = Colors.Black;
        CalculatorLabel.Text = ans;
    }

    private string Calculate()
    {
        if (second == "") return "";
        if (first == "") first = "0";
        if (!double.TryParse(first,out double parsedFirst)) return "";
        if (!double.TryParse(second,out double parsedSecond)) return "";
        var result = .0;
        if (first != "" && second != "")
        {
            switch (op)
            {
                case "+":
                    result = parsedFirst + parsedSecond;
                    break;
                case "-":
                    result = parsedFirst - parsedSecond;
                    break;
                case "×":
                    result = parsedFirst * parsedSecond;
                    break;
                case "÷":
                    if (parsedSecond == 0)
                    {
                        ShowError("Деление на 0!");
                        ans = "";
                        first = "";
                        second = "";
                        op = "";
                        return "";
                    }
                    result = parsedFirst / parsedSecond;
                    break;
            }
        }
        if(!TopCalculatorLabel.Text.Contains("=")) TopCalculatorLabel.Text += second + "=";
        ans = first = result.ToString();
        second = "";
        op = "";
        return "";
    }

    private void ShowError(string message)
    {
        CalculatorLabel.TextColor = Colors.Red;
        CalculatorLabel.Text = message;
    }

    private void ShowAnswer()
    {
        CalculatorLabel.Text = ans;
    }
}