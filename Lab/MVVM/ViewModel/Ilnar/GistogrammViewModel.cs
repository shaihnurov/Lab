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
        public double[] CumulativeDistribution { get; set; }
        private ObservableCollection<HistogramColumnViewModel> _histogramData;
        private double _maxFrequency;
        private double _average;
        private double _dispersion;
        private double _dispersionTwo;
        private double _dispersionThree;

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
        public double Average
        {
            get { return _average; }
            set 
            {
                _average = value;
                OnPropertyChanged(nameof(Average));
            }
        }
        public double Dispersion
        {
            get { return _dispersion; }
            set 
            {
                _dispersion = value;
                OnPropertyChanged(nameof(Dispersion));
            }
        }
        public double DispersionTwo
        {
            get { return _dispersionTwo; }
            set
            {
                _dispersionTwo = value;
                OnPropertyChanged(nameof(DispersionTwo));
            }
        }
        public double DispersionThree
        {
            get { return _dispersionThree; }
            set
            {
                _dispersionThree = value;
                OnPropertyChanged(nameof(DispersionThree));
            }
        }
        public GistogrammViewModel()
        {
            CumulativeDistribution = RandomNumberGenerator.GenerateCumulativeDistribution();
            HistogramData = [];
            double[] frequencies = RandomNumberGenerator.GenerateRandomNumbers();
            MaxFrequency = frequencies.Max();

            for (int i = 0; i < frequencies.Length; i++)
            {
                HistogramData.Add(new HistogramColumnViewModel
                {
                    Value = i * (1.0 / frequencies.Length),
                    Frequency = frequencies[i]
                });
            }

            var mean = frequencies.Average();
            Average = mean;
            Dispersion = frequencies.Select(x => Math.Pow(x - mean, 2)).Average();
            DispersionTwo = frequencies.Select(x => Math.Pow(x - mean, 2)).Average();
            DispersionThree = frequencies.Select(x => Math.Pow(x - mean, 3)).Average();
        }
    }
}