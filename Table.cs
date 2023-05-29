using System.Text;

namespace DummyDatabase;

public class Table
{
    public List<Row> Rows { get; }
    public TableScheme TableScheme { get; }

    public Table(string jsonPath, string csvPath)
    {
        string[][] data = CsvParser.ParseCsv(csvPath);
        TableScheme = new TableScheme(jsonPath);
        Rows = new List<Row>();
        
        for (int i = 0; i < data.Length; i++)
        {
            Rows.Add(new Row(TableScheme, data[i], i + 1)); 
        }
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

    private string ComposeHeaderLine(List<Column> columns, int[] widthOfColumns)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < columns.Count; i++)
        {
            sb.Append(" | ");
            sb.Append(columns[i].Name.PadRight(widthOfColumns[i]));
        }

        sb.AppendLine(" |");
        return sb.ToString();
    }

    public override string ToString()
    {
        List<Column> columns = TableScheme.Columns;
        int[] widthOfColumns = GetMaxWidthOfColumns(columns);
        StringBuilder sb = new StringBuilder();
        int lengthOfSeparateLine = widthOfColumns.Sum() + columns.Count * 3 + 1;

        sb.AppendLine($" {new String('-', lengthOfSeparateLine)}");
        sb.Append(ComposeHeaderLine(columns, widthOfColumns));
        
        foreach (var row in Rows)
        {
            int i = 0;

            sb.AppendLine($" {new String('-', lengthOfSeparateLine)}");
            
            foreach (var value in row.Data.Values)
            {
                sb.Append(" | ");
                sb.Append(value.ToString().PadRight(widthOfColumns[i]));
                i++;
            }

            sb.AppendLine(" |");
        }

        sb.AppendLine($" {new String('-', lengthOfSeparateLine)}");
            
        return sb.ToString();
    }
}