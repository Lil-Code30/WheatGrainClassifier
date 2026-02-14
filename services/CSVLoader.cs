using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using WheatGrainClassifier.models;
using Spectre.Console;

namespace WheatGrainClassifier.services;


public class CSVLoader
{
    public static List<WheatGrain> Reader(string filename)
    {

        List<WheatGrain> wheatGrains = new List<WheatGrain>();

        if (!File.Exists(filename))
        {
            throw new FileNotFoundException("File not found", filename);
        }

        // csv config
        var config = new CsvConfiguration(CultureInfo.InstalledUICulture)
        {
            Delimiter = ";",
            HasHeaderRecord = true,
            MissingFieldFound = null,
            HeaderValidated = null
        };

        try
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<WheatGrain>();


                foreach (var record in records)
                {
                    
                    wheatGrains.Add(record);
                }
            }

        } 
        catch (Exception ex)
        {
            AnsiConsole.MarkupLineInterpolated($"[bold red]✗ Error:[/] when loading csv file - {ex.Message}");
            throw;
        }
        
        return wheatGrains;
    }
}