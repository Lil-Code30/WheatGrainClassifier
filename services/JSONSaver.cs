using Newtonsoft.Json;
using WheatGrainClassifier.models;

namespace WheatGrainClassifier.services;

public class JSONSaver
{
    public static void Save(string filename, List<ResultHistory> data)
    {
        string serilize_data = JsonConvert.SerializeObject(data, Formatting.Indented);
        
        File.WriteAllText(filename, serilize_data);
    }

    public static void Modify(string filename, ResultHistory data)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException("File not found", filename);
        }
        
        string fileContent =  File.ReadAllText(filename);
        List<ResultHistory> resultHistories = JsonConvert.DeserializeObject<List<ResultHistory>>(fileContent);
        
        resultHistories.Add(data);
        
        string serilize_data = JsonConvert.SerializeObject(resultHistories,  Formatting.Indented);
        File.WriteAllText(filename, serilize_data);
    }
}