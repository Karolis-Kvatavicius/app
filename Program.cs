using System.Text.Json;

Console.WriteLine("Type column name:");
string column = Console.ReadLine();

Console.WriteLine("Type search query:");
string query = Console.ReadLine();

string fileNames = "";
string currentInput = "";
while (true)
{
    Console.WriteLine("Type file name (1, 2 or leave empty to end selection):");
    currentInput = Console.ReadLine();

    if (currentInput != "")
    {
        fileNames += currentInput + "<=>";
    }
    else
    {
        break;
    }
}


string[] fileNameList = fileNames.Split("<=>");

try
{
    foreach (string fileName in fileNameList.Where(x => !string.IsNullOrEmpty(x)).ToArray())
    {

        try
        {
            var record = File.ReadLines(fileName + ".csv").Skip(1)
             .Select(Line.ParseRecordFromLine)
             .Where(rec => ((string)typeof(Line).GetProperty(column).GetValue(rec)).Contains(query))
             .AsEnumerable();

            var data = new Data();
            data.fileName = fileName + ".csv";
            data.column = column;
            data.query = query;
            data.result = record;
            data.logCount = record.Count();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.ResetColor();
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { MaxDepth = 64, WriteIndented = true });
            Console.WriteLine(jsonString);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No file '" + fileName + "' found");
            Console.ResetColor();
        }

    }

}
catch (System.NullReferenceException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Column not found in at least one of the files.");
    Console.ResetColor();
}

