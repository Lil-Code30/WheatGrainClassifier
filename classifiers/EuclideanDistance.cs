using WheatGrainClassifier.models;

namespace WheatGrainClassifier.classifiers
{

    public class EuclideanDistance : IDistanceMetric
    {
        public double Calculate(WheatGrain a, WheatGrain b)
        {
            double squareSum =
            Math.Pow(a.Area - b.Area, 2) +
            Math.Pow(a.Perimeter - b.Perimeter, 2) +
            Math.Pow(a.Compactness - b.Compactness, 2) +
            Math.Pow(a.Kernel_Length - b.Kernel_Length, 2) +
            Math.Pow(a.Kernel_Width - b.Kernel_Width, 2) +
            Math.Pow(a.Asymmetry_Coefficient - b.Asymmetry_Coefficient, 2) +
            Math.Pow(a.Groove_Length - b.Groove_Length, 2);

            return Math.Sqrt(squareSum);
        }
    }
}
