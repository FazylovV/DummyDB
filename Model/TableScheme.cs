using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DummyDatabase;

public class TableScheme
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("columns")]
    public List<Column> Columns { get; set; }

    public TableScheme()
    {
        Columns = new List<Column>();
    }

    public void ToJson(string name)
    {
        var serialized = JsonSerializer.Serialize(this, new JsonSerializerOptions() {WriteIndented = true});
        File.Create($"Database/json/{name}.json").Close();
        
    }

    public TableScheme? GetSchemeFromJson(string jsonPath)
    {
        string json = File.ReadAllText(jsonPath);
        return JsonSerializer.Deserialize<TableScheme>(json);
    }
}