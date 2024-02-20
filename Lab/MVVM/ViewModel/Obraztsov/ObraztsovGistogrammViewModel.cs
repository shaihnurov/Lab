using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Lab.MVVM.ViewModel.Obraztsov
{
    public class ObraztsovGistogrammViewModel : ObservableObject
    {
        private readonly Random _random;
        private ObservableCollection<KeyValuePair<string, int>> _histogramData;
        private double _mean;
        private double _variance;
        private double _secondMoment;
        private double _thirdMoment;

        public ICommand GenerateRandomNumbersCommand { get; }

        public ObservableCollection<KeyValuePair<string, int>> HistogramData
        {
            get => _histogramData;
            set => SetProperty(ref _histogramData, value);
        }

        public double Mean
        {
            get => _mean;
            set => SetProperty(ref _mean, value);
        }

        public double Variance
        {
            get => _variance;
            set => SetProperty(ref _variance, value);
        }

        public double SecondMoment
        {
            get => _secondMoment;
            set => SetProperty(ref _secondMoment, value);
        }

        public double ThirdMoment
        {
            get => _thirdMoment;
            set => SetProperty(ref _thirdMoment, value);
        }

        public ObraztsovGistogrammViewModel()
        {
            _random = new Random();
            GenerateRandomNumbersCommand = new RelayCommand(GenerateRandomNumbers);
        }

        private void GenerateRandomNumbers()
        {
            int sampleSize = 6000;
            int intervals = 16;
            double[] randomNumbers = new double[sampleSize];
            double[] intervalLimits = new double[intervals + 1];
            Dictionary<string, int> histogram = [];

            for (int i = 0; i < sampleSize; i++)
            {
                randomNumbers[i] = GeneralizedAdditiveMethod(_random.NextDouble());
            }

            for (int i = 0; i <= intervals; i++)
            {
                intervalLimits[i] = (double)i / intervals;
            }

            for (int i = 0; i < intervals; i++)
            {
                histogram.Add($"{intervalLimits[i]:F2}-{intervalLimits[i + 1]:F2}", 0);
            }

            foreach (var randomNumber in randomNumbers)
            {
                for (int i = 0; i < intervals; i++)
                {
                    if (randomNumber >= intervalLimits[i] && randomNumber < intervalLimits[i + 1])
                    {
                        histogram[$"{intervalLimits[i]:F2}-{intervalLimits[i + 1]:F2}"]++;
                        break;
                    }
                }
            }

            HistogramData = new ObservableCollection<KeyValuePair<string, int>>(histogram);

            CalculateMoments(randomNumbers);
        }

        private void CalculateMoments(double[] randomNumbers)
        {
            Mean = randomNumbers.Average();

            Variance = randomNumbers.Select(x => Math.Pow(x - Mean, 2)).Average();

            SecondMoment = randomNumbers.Select(x => Math.Pow(x, 2)).Average();

            ThirdMoment = randomNumbers.Select(x => Math.Pow(x, 3)).Average();
        }

        private static double GeneralizedAdditiveMethod(double x)
        {
            const int r = 10;
            double[] xValues = [0.123, 0.456, 0.789, 0.321, 0.654, 0.987, 0.135, 0.246, 0.579, 0.813];

            double result = x;
            for (int i = 0; i < r; i++)
            {
                result = (result + xValues[i % xValues.Length]) % 1;
            }

            return result;
        }
    }
}
