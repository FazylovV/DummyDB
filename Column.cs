namespace DummyDatabase;

public class Column
{
    public string Name { get; }
    public string Type { get; set; }

    public Column(string name, string type)
    {
        Name = name;
        Type = type;
    }
}
