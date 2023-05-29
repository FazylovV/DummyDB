using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DummyDatabase
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Input path to .json file (example: 'file.json'): ");
            string jsonPath = Console.ReadLine();
            Console.Write("Input path to .csv file (example: 'csv.json'): ");
            string csvPath = Console.ReadLine();
            
            Table table = new Table(jsonPath, csvPath);
            Console.WriteLine(table);
        }
    }
}