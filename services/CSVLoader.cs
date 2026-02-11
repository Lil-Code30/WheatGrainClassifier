using System.Globalization;
using CsvHelper;
using WheatGrainClassifier.models;

namespace WheatGrainClassifier.services;


public class CSVLoader
{
    public static List<WheatGrain> Reader(string filename)
    {
        if (!File.Exists(filename))
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("File not found", filename);
            }
        
        List<WheatGrain> wheatGrains = new List<WheatGrain>();
        
        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<WheatGrain>();


            foreach (var record in records)
            {
                wheatGrains.Add(record);
            }
        }    
        
        return wheatGrains;
    }
}