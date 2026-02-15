namespace WheatGrainClassifier.models;

public class WheatGrain
{
    
    public double Area { get; init; }
    public double Perimeter { get; init; }
    public double Compactness { get; init; }
    public double Kernel_Length { get; init; }
    public double Kernel_Width { get; init; }
    public double Asymmetry_Coefficient { get; init; }
    public double Groove_Length { get; init; }
    public GrainType Variety { get; set; } 

}

public enum GrainType { Kama, Rosa, Canadian }