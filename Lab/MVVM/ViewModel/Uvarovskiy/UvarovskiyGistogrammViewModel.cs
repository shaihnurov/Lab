using CommunityToolkit.Mvvm.ComponentModel;
using Lab.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.MVVM.ViewModel.Uvarovskiy
{
    public class UvarovskiyGistogrammViewModel : ObservableObject
    {
        private List<double> randomNumbers;
        private readonly int sampleSize = 5000;
        private readonly int bins = 26;
        private readonly int k = 128;

        public double Average => randomNumbers?.Average() ?? 0;
        public double Dispersion => randomNumbers?.Select(x => x * x).Average() - Average * Average ?? 0;
        public double DispersionTwo => randomNumbers?.Select(x => x * x * x).Average() - Average * Average * Average ?? 0;
        public double DispersionThree => randomNumbers?.Select(x => x * x * x * x).Average() - Average * Average * Average * Average ?? 0;
        public List<HistogramDataItem> HistogramData { get; private set; }

        public UvarovskiyGistogrammViewModel()
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
