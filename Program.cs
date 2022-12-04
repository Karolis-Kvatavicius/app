using System.Text.Json;

Console.WriteLine("Type column name:");
string column = Console.ReadLine();

Console.WriteLine("Type search query:");
string query = Console.ReadLine();

try
{
    var record = File.ReadLines("20220601182758.csv").Skip(1)
                 .Select(Line.ParseRecordFromLine)
                 .Where(rec => ((string)typeof(Line).GetProperty(column).GetValue(rec)).Contains(query))
                 .AsEnumerable();

    var data = new Data();
    data.column = column;
    data.query = query;
    data.result = record;
    data.logCount = record.Count();

    string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { MaxDepth = 64, WriteIndented = true });
    Console.WriteLine(jsonString);
}
catch (System.NullReferenceException)
{
    Console.WriteLine("Column not found.");
}
