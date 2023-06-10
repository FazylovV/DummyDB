using System.Text;

namespace DummyDatabase;

public class Table
{
    private string _jsonPath;
    private string _csvPath;
    private bool _disposed = false;
    public string Name { get; private set; }
    public List<Row> Rows { get; }
    public TableScheme TableScheme { get; }
    public List<string>? ReferencedTables { get; private set; }
    
    public Database Database { get; set; }

    public Table(string jsonPath, string csvPath)
    {
        TableScheme = new TableScheme();
        Rows = new List<Row>();
        _csvPath = csvPath;
        _jsonPath = jsonPath;
        SetReferencedTables();
    }
    

    private void SetReferencedTables()
    {
        List<string> referencedTables = new List<string>();
        foreach (var column in TableScheme.Columns)
        {
            if(column.ReferencedTable != null) referencedTables.Add(column.ReferencedTable);
        }

        ReferencedTables = referencedTables;
    }

    public static Table Create(string name)
    {
        string csvPath = $"Databases/csv/{name}.csv";
        string jsonPath = $"Databases/json/{name}.json";
        File.Create(csvPath).Close();
        File.Create(jsonPath).Close();
        return new Table(csvPath, jsonPath);
    }

    public void Rename(string newName)
    {
        Name = newName;
    }

    private int[] GetMaxWidthOfColumns(List<Column> columns)
    {
        int[] widthOfColumns = new int[columns.Count];

        for (int i = 0; i < columns.Count; i++)
        {
            widthOfColumns[i] = columns[i].Name.Length;
        }
        
        foreach (var row in Rows)
        {
            int i = 0;
            foreach (var value in row.Data.Values)
            {
                if (value.ToString().Length > widthOfColumns[i]) widthOfColumns[i] = value.ToString().Length;
                i++;
            }
        }

        return widthOfColumns;
    }

    public override string ToString()
    {
        return Name;
    }
}