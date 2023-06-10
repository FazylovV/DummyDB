namespace DummyDatabase;

public class Database
{
    public string Name { get; private set; }
    public List<Table> Tables { get; }

    public Database(string name)
    {
        Tables = new List<Table>();
        Name = name;
    }

    public void RenameDatabase(string newName)
    {
        Name = newName;
    }

    public void CreateTable(string name)
    {
        Table table = Table.Create(name);
        table.Database = this;
        Tables.Add(table);
    }
    
    public void AddTable(Table table)
    {
        table.Database = this;
        Tables.Add(table);
    }

    public void RenameTable(string name, string newName)
    {
        Table table = Tables.FirstOrDefault(table => table.Name == name);
        table.Rename(newName);
    }

    public void DeleteTable(string name)
    {
        Table table = Tables.FirstOrDefault(table => table.Name == name);
        Tables.Remove(table);
    }
}