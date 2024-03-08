
using System.Globalization;

namespace LabRab5App.ValueConverters
{
    internal class ChartToColorValueConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if((Int32)value < 10) return Colors.Red;
            return Colors.CornflowerBlue;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
