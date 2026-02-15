
using WheatGrainClassifier.models;

namespace WheatGrainClassifier.classifiers
{
    public interface IDistance
    {
        public double Calculate(WheatGrain a, WheatGrain b);
    }
}
