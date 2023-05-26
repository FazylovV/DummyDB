using System.Text.Json;
using System.Text.Json.Nodes;

namespace DummyDatabase;

public class TableScheme
{
    public string Name { get; }
    public List<Column> Columns { get; }

    public TableScheme(string jsonPath)
    {
        string json = File.ReadAllText(jsonPath);
        JsonObject? jsonObject = JsonSerializer.Deserialize<JsonObject>(json);
        JsonArray jsonColumns = (JsonArray)jsonObject["columns"];

        Name = jsonObject["name"].ToString();
        Columns = new List<Column>();

        foreach (var jsonColumn in jsonColumns)
        {
            Columns.Add(new Column(
                jsonColumn["name"].ToString(),
                jsonColumn["type"].ToString()
            ));
        }
    }
}