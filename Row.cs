namespace DummyDatabase;

public class Row
{
    public Dictionary<Column, object> Data { get; }

    public Row(TableScheme scheme, string[] row, int lineNumber)
    {
        Data = new Dictionary<Column, object>();
        for (int i = 0; i < scheme.Columns.Count; i++)
        {
            Column column = scheme.Columns[i];
            Data.Add(column, DataValidator.ValidateValue(row[i], column.Type, lineNumber));
        }
    }
}