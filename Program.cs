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
    var data = new Data();
    data.column = column;
    data.query = query;
    data.result = record;

    string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { MaxDepth = 64 });
    Console.WriteLine(jsonString);
}
else
{
    Console.WriteLine("No records found");
}