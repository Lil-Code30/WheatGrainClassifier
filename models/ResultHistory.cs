namespace WheatGrainClassifier.models;

public class ResultHistory
{
    private int K {get; }
    private string DistanceMetric { get; }
    private DateTime CreatedAt {get; }
    private List<WheatGrain> TestData { get; }
    private List<WheatGrain> TrainingData { get; }
    private double Accuracy { get; }
    // private List<WheatGrain> PredictedResult { get; }

    public ResultHistory(int k, string distanceMetric, List<WheatGrain> testData,  List<WheatGrain> trainingData, double accuracy)
    {
        K = k;
        DistanceMetric = distanceMetric;
        CreatedAt = DateTime.Today;
        TestData = testData;
        TrainingData = trainingData;
        Accuracy = accuracy;
    }
    
}