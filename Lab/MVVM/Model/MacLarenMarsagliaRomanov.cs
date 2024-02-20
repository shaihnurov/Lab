using System;
using System.Collections.Generic;

namespace Lab.MVVM.Model
{
    public class MacLarenMarsaglia
    {
        private readonly int k;
        private readonly int[] seeds;
        private int currentIndex;
        private readonly List<double> randomNumbers;

        public MacLarenMarsaglia(int k, int sampleSize)
        {
            this.k = k;
            seeds = new int[k];
            randomNumbers = new List<double>(sampleSize);
            InitializeSeeds();
            GenerateRandomNumbers(sampleSize);
        }

        private void InitializeSeeds()
        {
            Random rnd = new();
            for (int i = 0; i < k; i++)
            {
                seeds[i] = rnd.Next();
            }
        }

        private void GenerateRandomNumbers(int sampleSize)
        {
            for (int i = 0; i < sampleSize; i++)
            {
                int index1 = currentIndex % k;
                int index2 = (currentIndex + 31) % k;
                seeds[index1] = seeds[index2];
                currentIndex = (currentIndex + 1) % k;
                randomNumbers.Add((double)seeds[index1] / int.MaxValue);
            }
        }

        public List<double> GetRandomNumbers()
        {
            return randomNumbers;
        }
    }
}