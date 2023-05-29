namespace DummyDatabase;

public class Column
{
    public string Name { get; }
    public string Type { get; }

    public Column(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public override string ToString()
    {
        return Name;
    }
}
