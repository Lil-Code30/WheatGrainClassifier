using WheatGrainClassifier.models;

namespace WheatGrainClassifier.classifiers
{
    public class ManhattanDistance : IDistanceMetric
    {
        public double Calculate(WheatGrain a, WheatGrain b)
        {
            return Math.Abs(a.Area - b.Area) +
                Math.Abs(a.Perimeter - b.Perimeter) +
                Math.Abs(a.Compactness - b.Compactness) +
                Math.Abs(a.Kernel_Length - b.Kernel_Length) +
                Math.Abs(a.Kernel_Width - b.Kernel_Width) +
                Math.Abs(a.Asymmetry_Coefficient - b.Asymmetry_Coefficient) +
                Math.Abs(a.Groove_Length - b.Groove_Length);
        }
    }
}
