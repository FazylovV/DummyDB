namespace DummyDatabase;

public class Database
{
    public List<Table> tables;

    public void CreateTable(string name)
    {
        if (tables == null) tables = new List<Table>();
        tables.Add(Table.Create(name));
    }
}