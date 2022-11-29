using System.Text.Json;

Console.WriteLine("Type column name:");
string column = Console.ReadLine();

Console.WriteLine("Type search query:");
string query = Console.ReadLine();

var record = File.ReadLines("20220601182758.csv").Skip(1)
                 .Select(Line.ParseRecordFromLine)
                 .Where(rec => ((string)typeof(Line).GetProperty(column).GetValue(rec)).Contains(query))
                 .AsEnumerable();

if (record != null || record.Any())
{
    foreach (var item in record)
    {
        string jsonString = JsonSerializer.Serialize(item);
        Console.WriteLine(jsonString);
    }
}
else
{
    Console.WriteLine("No records found");
}