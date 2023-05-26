namespace DummyDatabase;

public class DataValidator
{
    public static object ValidateValue(string value, string type, int lineNumber)
    {
        switch (type)
        {
            case "uint":
                if (uint.TryParse(value, out uint positiveNum))
                    return positiveNum;
                throw new Exception($"Invalid data in {lineNumber} line, value \'{value}\', type \'{type}\'");
            
            case "int":
                if (int.TryParse(value, out int num))
                    return num;
                throw new Exception($"Invalid data in {lineNumber} line, value \'{value}\', type \'{type}\'");
            
            case "float":
                if (float.TryParse(value, out float floatNum))
                    return floatNum;
                throw new Exception($"Invalid data in {lineNumber} line, value \'{value}\', type \'{type}\'");
            
            case "DateTime":
                if (DateTime.TryParse(value, out DateTime date))
                    return date;
                throw new Exception($"Invalid data in {lineNumber} line, value \'{value}\', type \'{type}\'");
        }

        return null;
    }
}