using System.Diagnostics;
using System.Globalization;

namespace LabRab5App.ValueConverters
{
    public class IdToImageSourceConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var dirPath = FileSystem.Current.AppDataDirectory;
            var path_to_image = Path.Combine(dirPath,"Images");
            path_to_image = Path.Combine(path_to_image, $"{(int)value}.png");
            Trace.WriteLine(path_to_image);
            if(File.Exists(path_to_image))
            {
                Trace.WriteLine("exists");
                return ImageSource.FromFile(path_to_image);
            }
            return ImageSource.FromFile("dotnet_bot.png");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
