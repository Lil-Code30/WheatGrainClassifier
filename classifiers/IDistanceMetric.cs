
using WheatGrainClassifier.models;

namespace WheatGrainClassifier.classifiers
{
    public interface IDistanceMetric
    {
        public double Calculate(WheatGrain a, WheatGrain b);
    }
}
