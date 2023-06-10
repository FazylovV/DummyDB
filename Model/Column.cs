using System.Text.Json.Serialization;

namespace DummyDatabase;

public class Column
{
    [JsonPropertyName("name")] 
    public string? Name { get; set; }
    
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    
    [JsonPropertyName("isPrimary")]
    public bool IsPrimary { get; set; }
    
    [JsonPropertyName("referenced_table")]
    public string? ReferencedTable { get; set; }
    
    public override string ToString()
    {
        return Name;
    }
}
