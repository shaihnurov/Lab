using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using Lab.MVVM.Model;

namespace Lab.MVVM.ViewModel.Ilnar
{
    public class GistogrammViewModel : ObservableObject
    {
        private ObservableCollection<HistogramColumnViewModel> _histogramData;
        private double _maxFrequency;

        public ObservableCollection<HistogramColumnViewModel> HistogramData
        {
            get => _histogramData;
            set
            {
                _histogramData = value;
                OnPropertyChanged(nameof(HistogramData));
            }
        }

        public double MaxFrequency
        {
            get => _maxFrequency;
            set
            {
                _maxFrequency = value;
                OnPropertyChanged(nameof(MaxFrequency));
            }
        }

        public double[] CumulativeDistribution { get; set; }

        public GistogrammViewModel()
        {
            CumulativeDistribution = RandomNumberGenerator.GenerateCumulativeDistribution();
            HistogramData = new ObservableCollection<HistogramColumnViewModel>();
            double[] frequencies = RandomNumberGenerator.GenerateRandomNumbers();
            MaxFrequency = frequencies.Max(); // Вычисляем максимальную частоту

            for (int i = 0; i < frequencies.Length; i++)
            {
                HistogramData.Add(new HistogramColumnViewModel
                {
                    Value = i * (1.0 / frequencies.Length),
                    Frequency = frequencies[i]
                });
            }

            // Добавим вывод информации в консоль для отладки
            foreach (var item in HistogramData)
            {
                Console.WriteLine($"Value: {item.Value}, Frequency: {item.Frequency}");
            }
        }

    }
}