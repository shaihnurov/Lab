using System;
using System.Globalization;
using System.Windows.Data;

namespace Lab.MVVM.ViewModel.Ilnar
{
    public class ProportionalHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Проверяем, что массив значений не является null и имеет длину 2
            if (values != null && values.Length == 2 &&
                // Проверяем, что первый элемент массива values (values[0]) является double и преобразуем его в переменную frequency
                values[0] is double frequency &&
                // Проверяем, что второй элемент массива values (values[1]) является double и преобразуем его в переменную maxFrequency
                values[1] is double maxFrequency && maxFrequency > 0)
            {
                // Если все условия выполняются, вычисляем высоту столбца как отношение frequency к maxFrequency, умноженное на 100
                return frequency / maxFrequency * 100;
            }
            // Если какое-либо из условий не выполняется, возвращаем null
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
