using WheatGrainClassifier.services;
using Spectre.Console;

try
{
    // seeds_dataset_test.csv

    var list = CSVLoader.Reader("seeds_dataset_test.csv");

    foreach (var item in list)
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