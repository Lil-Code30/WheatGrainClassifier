using WheatGrainClassifier.models;

namespace WheatGrainClassifier.services;

public class PerformanceMeasurement
{
    // Accuracy
    public static double accuracy(List<string> actualVarieties, List<string> predictedVarieties)
    {
        int correctly_classified = 0;

        if (actualVarieties.Count != predictedVarieties.Count)
        {
            throw new Exception("Test and Predicted labels must have the same number of labels");
        }

        for (int i = 0; i < predictedVarieties.Count; i++)
        {
            string prediction = predictedVarieties[i];
            string testLabel = actualVarieties[i];

            if (string.Equals(prediction, testLabel, StringComparison.OrdinalIgnoreCase))
            {
                correctly_classified++;
            }
        }
        
        // calculating the accuracy
        
        double accuracy = ((double)correctly_classified / actualVarieties.Count) * 100;
        
        return accuracy;
    }
    
    // confusion matrix
    public static int[,] confusionMatrix(List<string> actualVarieties, List<string> predictedVarieties, int numberOfVarieties)
    {
        if (actualVarieties.Count != predictedVarieties.Count)
        {
            throw new ArgumentException("The two List should have the same length.");
        }
        
        
        int[,] matrix = new int[0,0];

        for (int i = 0; i < actualVarieties.Count; i++)
        {
            // int actual = Convert.ToInt32(actualVarieties[i]);
        }

        return matrix;
    }
}