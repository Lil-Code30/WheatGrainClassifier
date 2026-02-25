namespace WheatGrainClassifier.models;

public class ResultHistory
{
    public int K {get; set; }
    public string DistanceMetric { get; set; }
    public DateTime CreatedAt {get; set;}
    public List<WheatGrain> TestData { get; set;}
    public List<WheatGrain> TrainingData { get; set; }
    public double Accuracy { get; set; }
    public int[,]  MatrixConfusion {get; set;}
    // private List<WheatGrain> PredictedResult { get; }

    public ResultHistory(int k, string distanceMetric, List<WheatGrain> testData,  List<WheatGrain> trainingData, double accuracy, int[,] matrix)
    {
        K = k;
        DistanceMetric = distanceMetric;
        CreatedAt = DateTime.Today;
        TestData = testData;
        TrainingData = trainingData;
        Accuracy = accuracy;
        MatrixConfusion = matrix;
    }
    
}