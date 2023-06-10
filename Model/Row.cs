namespace DummyDatabase;

public class Row
{
    public static int Id { get; private set; }
    private int _id;
    public Dictionary<Column, object> Data { get; }

    public Row()
    {
        Id++;
        _id = Id;
        Data = new Dictionary<Column, object>();
    }

    public void ChangeValue(Column column, string value)
    {
        Data[column] = DataValidator.GetValidateValue(value, column.Type, _id);
    }
}