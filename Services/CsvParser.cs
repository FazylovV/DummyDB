namespace DummyDatabase;

static class CsvParser
{
    private static string[] ParseLine(string line)
    {

        return line.Split(";");
    }

    public static string[][] ParseCsv(string csvPath)
    {
        string[] lines = File.ReadAllLines(csvPath);
        string[][] data = new string[lines.Length][];
        
        for (int i = 0; i < lines.Length; i++)
        {
            data[i] = ParseLine(lines[i]);
        }

        return data;
    }
}