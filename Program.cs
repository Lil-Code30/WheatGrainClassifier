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

    foreach (var item in test)
    {
        string prediction = knn.predict(item);

        Console.WriteLine($"Variety : {prediction} , Area : {item.Area} ");
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