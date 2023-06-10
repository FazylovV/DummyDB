using System.Text;

namespace DummyDatabase;

public static class CsvWriter
{
    private const string pathToDb= "C:/Users/vladi/RiderProjects/Dummy Database/Databases/";
    
    public static void WriteCsv(Table table)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var rowElements in table.Rows.Select(t => t.Data.Select(pair => pair.Value)))
        {
            sb.AppendJoin(';', rowElements);
            sb.AppendLine();
        }

        try
        {
            File.WriteAllText($"{pathToDb}/{table.Database.Name}/{table.Name}/{table.Name}.csv", sb.ToString());
        }
        catch
        {
            
        }
        
    }
}