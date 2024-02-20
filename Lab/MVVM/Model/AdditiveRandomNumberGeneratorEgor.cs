using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.MVVM.Model
{
    public class AdditiveRandomNumberGeneratorEgor
    {
        private const int Y1 = 3971;
        private const int Y2 = 1013;
        private const int M = 4096 * 4;

        private int seed;
        private readonly List<double> randomNumbers;

        public List<double> RandomNumbers => randomNumbers;

        public AdditiveRandomNumberGeneratorEgor(int sampleSize)
        {
            randomNumbers = [];
            seed = Y1;

            GenerateRandomNumbers(sampleSize);
        }

        private void GenerateRandomNumbers(int sampleSize)
        {
            for (int i = 0; i < sampleSize; i++)
            {
                seed = (Y1 * seed + Y2) % M;
                double randomNumber = (double)seed / M;
                randomNumbers.Add(randomNumber);
            }
        }
    }
}
