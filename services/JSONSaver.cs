using Newtonsoft.Json;

namespace WheatGrainClassifier.services;

public class JSONSaver
{
    public static void Save(string filename, string data)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException("File not found", filename);
        }
        
        string serilize_data = JsonConvert.SerializeObject(data);

        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.Write(serilize_data);
        }
    }
}