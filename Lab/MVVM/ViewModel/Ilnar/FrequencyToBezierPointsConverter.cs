using System.Globalization;
using System.Windows.Data;
using System;

namespace Lab.MVVM.ViewModel.Ilnar
{
    public class FrequencyToBezierPointsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double[] frequencies)
            {
                double[] points = new double[frequencies.Length * 2];

                for (int i = 0; i < frequencies.Length; i++)
                {
                    points[i * 2] = i * (1.0 / (frequencies.Length - 1));
                    points[i * 2 + 1] = frequencies[i];
                }

                return points;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
