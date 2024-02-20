namespace Lab.MVVM.Model
{
    public class RandomNumberGenerator
    {
        private const int Y0 = 3091;
        private const int M = 4096;
        private const int SamplesCount = 2000;
        private const int PartitionsCount = 21;

        public static double[] GenerateRandomNumbers()
        {
            double[] randomNumbers = new double[SamplesCount];
            int[] counts = new int[PartitionsCount];

            int a = Y0;

            for (int i = 0; i < SamplesCount; i++)
            {
                a = (a * Y0) % M;
                randomNumbers[i] = (double)a / M;
                int partitionIndex = (int)(randomNumbers[i] * (PartitionsCount - 1));
                counts[partitionIndex]++;
            }

            double[] frequencies = new double[PartitionsCount];
            for (int i = 0; i < PartitionsCount; i++)
            {
                frequencies[i] = (double)counts[i] / SamplesCount;
            }

            return frequencies;
        }

        public static double[] GenerateCumulativeDistribution()
        {
            double[] frequencies = GenerateRandomNumbers();
            double[] cumulativeDistribution = new double[frequencies.Length];
            cumulativeDistribution[0] = frequencies[0];

            for (int i = 1; i < frequencies.Length; i++)
            {
                cumulativeDistribution[i] = cumulativeDistribution[i - 1] + frequencies[i];
            }

            return cumulativeDistribution;
        }
    }
}