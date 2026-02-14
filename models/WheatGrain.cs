using CsvHelper.Configuration.Attributes;
namespace WheatGrainClassifier.models;

public class WheatGrain
{
    // variety;Area;Perimeter;Compactness;Kernel_Length;Kernel_Width;Asymmetry_Coefficient;Groove_Length
    
    public string Variety { get; set; }
    public float Area { get; set; }
    public float Perimeter { get; set; }
    public float Compactness { get; set; }
    public float Kernel_Length { get; set; }
    public float Kernel_Width { get; set; }
    public float Asymmetry_Coefficient { get; set; }
    public float Groove_Length { get; set; }

    public WheatGrain(string variety, float area, float perimeter, float compactness, float kernelLength, float kernelWidth, float asymmetryCoefficient, float grooveLength)
    {
        Variety = variety;
        Area = area;
        Perimeter = perimeter;
        Compactness = compactness;
        Kernel_Length = kernelLength;
        Kernel_Width = kernelWidth;
        Asymmetry_Coefficient = asymmetryCoefficient;
        Groove_Length = grooveLength;
    }
}