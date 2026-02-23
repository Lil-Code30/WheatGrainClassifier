using WheatGrainClassifier.models;

namespace WheatGrainClassifier.services;

public class PerformanceMeasurement
{
    public static double accuracy(List<string> testData, List<string> predictedLabels)
    {
        int correctly_classified = 0;

        if (testData.Count != predictedLabels.Count)
        {
            throw new Exception("Test and Predicted labels must have the same number of labels");
        }

        for (int i = 0; i < predictedLabels.Count; i++)
        {
            string prediction = predictedLabels[i];
            string testLabel = testData[i];

            if (string.Equals(prediction, testLabel, StringComparison.OrdinalIgnoreCase))
            {
                correctly_classified++;
            }
        }
        
        // calculating the accuracy
        
        double accuracy = ((double)correctly_classified / testData.Count) * 100;
        
        return accuracy;
    }
}