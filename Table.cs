namespace DummyDatabase;

public class Table
{
    public List<Row> Rows { get; }
    private TableScheme TableScheme{ get; }

    public Table(string jsonPath, string[][] data)
    {
        TableScheme = new TableScheme(jsonPath);
        Rows = new List<Row>();
        for (int i = 0; i < data.Length; i++)
        {
            Rows.Add(new Row(TableScheme, data[i], i + 1)); 
        }
    }
}