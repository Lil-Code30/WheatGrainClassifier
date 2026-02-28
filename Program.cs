using WheatGrainClassifier.services;
using Spectre.Console;
using WheatGrainClassifier.classifiers;
using WheatGrainClassifier.models;

try
{
    ShowIntro();
    
    // interactive menu
    var trainDataPath = AnsiConsole.Prompt(
        new TextPrompt<string>("[green] Enter the path to the training data csv file: [/]")
        .Validate(f => string.IsNullOrWhiteSpace(f)
        ? ValidationResult.Error("[red] invalide file path")
        : ValidationResult.Success()));

    // load training data
    var trainData = CSVLoader.Reader(trainDataPath);

    var testDataPath = AnsiConsole.Prompt(
        new TextPrompt<string>("[green] Enter the path to the test data csv file:[/]")
        .Validate(f => string.IsNullOrWhiteSpace(f)
        ? ValidationResult.Error("[red] invalide file path[red]")
        : ValidationResult.Success()));

    // load testing data 
    var testData = CSVLoader.Reader(testDataPath);

    int k = AnsiConsole.Prompt(
        new TextPrompt<int>("[green] Enter the value of k to use in the algorithm:[/]")
        .Validate(n => n < 1
        ? ValidationResult.Error("[red] Value of must be greater than 0[red]")
        : ValidationResult.Success()));

    // prompting the user for the distance to use
    string distanceMetricChoice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[green] Which distance to you what to use for the prediction?[/]")
        .AddChoices(new[] { "Euclidean Distance", "Manhattan Distance" }));
   
    // Distance choice
    IDistanceMetric distanceMetric = distanceMetricChoice == "Euclidean Distance" ? new EuclideanDistance() : new ManhattanDistance();

    
    
    // 2. Training and prediction
    KNNClassifier knn = new KNNClassifier(k, distanceMetric, trainData);

    List<string> actualVarieties = new List<string>();
    List<string> predictedVarieties = new List<string>();

    foreach (var grain in testData)
    {
        string prediction = knn.predict(grain);
        predictedVarieties.Add(prediction);
        actualVarieties.Add(grain.Variety.ToString());
    }

    // 3. Calculating Performance
    // Accuracy on test set by our model
    
    AnsiConsole.MarkupLine("[green] Calculating the model accuracy... [/]");
    double accuracy = PerformanceMeasurement.accuracy(actualVarieties, predictedVarieties);
    Thread.Sleep(2000);
    
    AnsiConsole.MarkupLine("[green] Calculating the confusion matrix... [/]");
    int[,] matrix = PerformanceMeasurement.confusionMatrix(actualVarieties, predictedVarieties, 3);
    Thread.Sleep(2000);
    
    Console.WriteLine();
    
    var table = new Table();
    table.Border(TableBorder.Rounded);
    table.Title("[bold blue]Confusion Matrix[/]");
    
    table.AddColumn("[grey]Actual \\ Predicted[/]");
    var grainTypes = Enum.GetNames(typeof(GrainType));
    foreach (var name in grainTypes)
    {
        table.AddColumn($"[bold]{name}[/]");
    }
    
    for (int i = 0; i < grainTypes.Length; i++)
    {
        var rowData = new List<string> { $"[bold]{grainTypes[i]}[/]" };
        for (int j = 0; j < grainTypes.Length; j++)
        {
            int count = matrix[i, j];
            if (i == j && count > 0)
                rowData.Add($"[green]{count}[/]");
            else if (count > 0)
                rowData.Add($"[red]{count}[/]");
            else
                rowData.Add($"[grey]{count}[/]");
        }
        table.AddRow(rowData.ToArray());
    }
    
    AnsiConsole.Write(table);
    Console.WriteLine();

    AnsiConsole.MarkupLineInterpolated($"[bold green] Distance metric used: {distanceMetricChoice} [/]");
    AnsiConsole.MarkupLineInterpolated($"[bold green] Accuracy on test set by our model: {accuracy:0.00}% [/]");
    
    // 4. Storing the performance result in the JSON file
    ResultHistory resultHistory = new ResultHistory(k, distanceMetricChoice, testData, trainData, accuracy,  matrix);
    
    // List of result History    
    List<ResultHistory> resultHistories = new List<ResultHistory>();
    resultHistories.Add(resultHistory);
    
    string filePath = "result_history.json";
    
    Console.WriteLine();
    AnsiConsole.MarkupLine("[green] Saving predictions result... [/]");

    if (File.Exists(filePath))
    {
        JSONSaver.Modify(filePath, resultHistory);
    }
    else
    {
        JSONSaver.Save(filePath, resultHistories);
    }
    
    Console.WriteLine();
    Thread.Sleep(2000);
    AnsiConsole.MarkupLine("[green] Result History successfully saved. :) [/]");
    
    Console.WriteLine("\nPress any key to exit...");
    Console.ReadKey();
}
catch (FileNotFoundException)
{
    AnsiConsole.MarkupLine("[bold red]✗ Error:[/] File not found");
}
catch (Exception ex)
{
    AnsiConsole.MarkupLineInterpolated($"[bold red]✗ Error:[/] An Error occured: '{ex.Message}'");
}


// menu function
static void ShowIntro()
{
    AnsiConsole.Clear();

    // Big title rule
    AnsiConsole.Write(
        new Rule("[bold yellow]🌾 WHEAT GRAIN CLASSIFIER 🌾[/]")
            .Centered()
            .RuleStyle("grey")
    );

    AnsiConsole.WriteLine();

    // Main panel
    var panel = new Panel(
        "[bold white]Machine Learning Console Application[/]\n\n" +
        "[green]✔[/] Automatic Wheat Grain Classification\n" +
        "[green]✔[/] Powered by K-Nearest Neighbors (KNN)\n" +
        "[green]✔[/] Fast • Accurate • Intelligent\n\n" +
        "[grey]Built with C# & Spectre.Console[/]"
    )
    .Header("[bold blue] About The Project [/]")
    .Border(BoxBorder.Double)
    .BorderStyle(new Style(Color.Blue))
    .Padding(2, 1);

    AnsiConsole.Write(panel);

    AnsiConsole.WriteLine();

    // Footer rule
    AnsiConsole.Write(
        new Rule("[grey]Press any key to continue...[/]")
            .Centered()
            .RuleStyle("grey")
    );

    Console.ReadKey(true);
}