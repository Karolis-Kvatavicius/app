public class Line
{
    public string? deviceVendor { get; set; }
    public string? deviceProduct { get; set; }
    public string? deviceVersion { get; set; }
    public string? signatureId { get; set; }
    public string? severity { get; set; }
    public string? name { get; set; }
    public string? start { get; set; }
    public string? rt { get; set; }
    public string? msg { get; set; }
    public string? shost { get; set; }
    public string? smac { get; set; }
    public string? dhost { get; set; }
    public string? dmac { get; set; }
    public string? suser { get; set; }
    public string? suid { get; set; }
    public string? externalId { get; set; }
    public string? cs1Label { get; set; }
    public string? cs1 { get; set; }

    public static Line ParseRecordFromLine(string line)
    {
        string[] parts = line.Split(';');
        return new Line
        {
            deviceVendor = parts[0],
            deviceProduct = parts[1],
            deviceVersion = parts[2],
            signatureId = parts[3],
            severity = parts[4],
            name = parts[5],
            start = parts[6],
            rt = parts[7],
            msg = parts[8],
            shost = parts[9],
            smac = parts[10],
            dhost = parts[11],
            dmac = parts[12],
            suser = parts[13],
            suid = parts[14],
            externalId = parts[15],
            cs1Label = parts[16],
            cs1 = parts[17]
        };
    }
}