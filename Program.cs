using WheatGrainClassifier.services;
using Spectre.Console;

try
{
    // seeds_dataset_test.csv & seeds_dataset_training.csv

    // load training data
    var apprentissage = CSVLoader.Reader("seeds_dataset_training.csv");

    // load testing data 
    var test = CSVLoader.Reader("seeds_dataset_test.csv");

    foreach (var item in test)
    {
        Console.WriteLine($"Variety : {item.Variety} , Area : {item.Area} ");
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