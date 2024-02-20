using CommunityToolkit.Mvvm.ComponentModel;
using Lab.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.MVVM.ViewModel.Romanov
{
    public class RomanovGistogrammViewModel : ObservableObject
    {
        private List<double> randomNumbers;
        private readonly int sampleSize = 2000;
        private readonly int bins = 16;
        private readonly int k = 64;

        public double Average => randomNumbers?.Average() ?? 0;
        public double Dispersion => randomNumbers?.Select(x => x * x).Average() - Average * Average ?? 0;
        public double DispersionTwo => randomNumbers?.Select(x => x * x * x).Average() - Average * Average * Average ?? 0;
        public double DispersionThree => randomNumbers?.Select(x => x * x * x * x).Average() - Average * Average * Average * Average ?? 0;
        public List<HistogramDataItem> HistogramData { get; private set; }

        public RomanovGistogrammViewModel()
        {
            GenerateRandomNumbers();
            PrepareHistogramData();
        }

        private void GenerateRandomNumbers()
        {
            MacLarenMarsaglia generator = new(k, sampleSize);
            randomNumbers = generator.GetRandomNumbers();
        }

        private void PrepareHistogramData()
        {
            double binWidth = 1.0 / bins;
            int[] frequencies = new int[bins];

            foreach (double randomNumber in randomNumbers)
            {
                int binIndex = (int)Math.Floor(randomNumber / binWidth);
                frequencies[binIndex]++;
            }

            HistogramData = frequencies.Select((frequency, index) => new HistogramDataItem
            {
                Value = (index + 0.5) * binWidth,
                Frequency = frequency
            }).ToList();
        }
    }
}