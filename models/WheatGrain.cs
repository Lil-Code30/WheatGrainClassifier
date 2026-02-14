using CsvHelper.Configuration.Attributes;
namespace WheatGrainClassifier.models;

public class WheatGrain
{
    
    public double Area { get; init; }
    public double Perimeter { get; init; }
    public double Compactness { get; init; }
    public double LengthOfKernel { get; init; }
    public double WidthOfKernel { get; init; }
    public double AsymmetryCoefficient { get; init; }
    public double LengthOfKernelGroove { get; init; }
    public GrainType? Variety { get; set; } // null = unlabeled

    public double[] ToFeatureVector() => new[]
    {
        Area, Perimeter, Compactness,
        LengthOfKernel, WidthOfKernel,
        AsymmetryCoefficient, LengthOfKernelGroove
    };
}

public enum GrainType { Kama, Rosa, Canadian }