using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DummyDatabase
{
    class Program
    {
        public static void Main()
        {
            string[][] data = CsvParser.ParseCsv("csv/match.csv");
            Table table = new Table("json/match.json", data);
        }
    }
}