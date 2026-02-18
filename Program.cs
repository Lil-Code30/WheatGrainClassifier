using WheatGrainClassifier.services;
using Spectre.Console;
using WheatGrainClassifier.classifiers;
using WheatGrainClassifier.models;

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
    // Accuracy on test set by our model
    double accuracy = PerformanceMeasurement.accuracy(test, predictResult);
    
    Console.WriteLine($"Accuracy on test set by our model: {accuracy:0.00}%");
    
    // creating a resultHistory instance
    ResultHistory resultHistory = new ResultHistory(k,"Euclidean Distance", test, training, accuracy);
    
    // List of result History    
    List<ResultHistory> resultHistories = new List<ResultHistory>();
    resultHistories.Add(resultHistory);
    
    // Saving the result histories in the json file
    
    string filePath = "result_history.json";
    
    Console.WriteLine("Saving predictions result...");

    if (File.Exists(filePath))
    {
        JSONSaver.Modify(filePath, resultHistory);
    }
    else
    {
        JSONSaver.Save(filePath, resultHistories);
    }
}
catch (FileNotFoundException)
{
    AnsiConsole.MarkupLine("[bold red]✗ Error:[/] File not found");
}
catch (Exception ex)
{
    AnsiConsole.MarkupLineInterpolated($"[bold red]✗ Error:[/] An Error occured: '{ex.Message}'");
}