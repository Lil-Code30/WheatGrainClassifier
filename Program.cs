using WheatGrainClassifier.services;
using Spectre.Console;
using WheatGrainClassifier.classifiers;

try
{
    // seeds_dataset_test.csv & seeds_dataset_training.csv

    // load training data
    var training = CSVLoader.Reader("seeds_dataset_training.csv");
    // load testing data 
    var test = CSVLoader.Reader("seeds_dataset_test.csv");

    int k = 2;
    var distanceMetric = new EuclideanDistance();

    KNNClassifier knn = new KNNClassifier(k, distanceMetric, training);
    
    // executing the knn algo on the test data
    var predictResult = knn.run(test);
    
    // Measure Performance 
    int correctly_classified = 0;
    
    if (test.Count != predictResult.Count)
    {
        throw new Exception("Test and prediction counts do not match.");
    }

    for (int i = 0; i < predictResult.Count; i++)
    {
      string prediction = predictResult[i];
      string testItem = test[i].Variety.ToString();

      if (string.Equals(prediction, testItem, StringComparison.OrdinalIgnoreCase))
      {
          correctly_classified++;
      }
      
    }
    
    // Accuracy on test set by our model
    double accuracy = ((double)correctly_classified / predictResult.Count) * 100;
    
    Console.WriteLine($"Correctly Classified Count : {correctly_classified}");
    Console.WriteLine($"Accuracy on test set by our model: {accuracy:0.00}%");
    
}
catch (FileNotFoundException)
{
    AnsiConsole.MarkupLine("[bold red]✗ Error:[/] File not found");
}
catch (Exception ex)
{
    AnsiConsole.MarkupLineInterpolated($"[bold red]✗ Error:[/] An Error occured: '{ex.Message}'");
}