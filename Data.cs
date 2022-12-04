using System;
using System.Reflection;
public class Data
{
    public string? fileName { get; set; }
    public string? column { get; set; }
    public string? query { get; set; }
    public IEnumerable<Line>? result { get; set; }
    public int logCount { get; set; } = 0;

}