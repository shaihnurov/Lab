using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Lab.MVVM.Model;
using Lab.MVVM.ViewModel.Egor;

namespace Lab.MVVM.ViewModel.Egor
{
    public class EgorGistogrammViewModel : ObservableRecipient
    {
        private readonly List<double> randomNumbers;
        private readonly int bins;
        private readonly int sampleSize;

        public List<HistogramItem> HistogramData { get; private set; }
        public double Mean { get; private set; }
        public double Variance { get; private set; }
        public double SecondMoment { get; private set; }
        public double ThirdMoment { get; private set; }

        public EgorGistogrammViewModel()
        {
            sampleSize = 2000;
            bins = 21;

            AdditiveRandomNumberGeneratorEgor generator = new(sampleSize);
            randomNumbers = generator.RandomNumbers;
            PrepareHistogramData();
            CalculateStatistics();
        }

        private void PrepareHistogramData()
        {
            double binWidth = 1.0 / bins;
            int[] frequencies = new int[bins];

            foreach (double randomNumber in randomNumbers)
            {
                int binIndex = (int)(randomNumber / binWidth);
                frequencies[binIndex]++;
            }

            HistogramData = frequencies.Select((frequency, index) => new HistogramItem
            {
                Value = (index + 0.5) * binWidth,
                Frequency = frequency
            }).ToList();

            OnPropertyChanged(nameof(HistogramData));
        }

        private void CalculateStatistics()
        {
            Mean = randomNumbers.Average();
            Variance = randomNumbers.Select(x => x * x).Average() - Mean * Mean;
            SecondMoment = randomNumbers.Select(x => x * x * x).Average();
            ThirdMoment = randomNumbers.Select(x => x * x * x * x).Average();
        }
    }
}