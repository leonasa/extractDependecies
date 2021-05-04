using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ExtractDependencies
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pattern = @"<PackageReference Include=""(.+)"" Version=""(.+)""";
            var listOfDependencies = new List<Dependency>();
            var path = @"C:\Git\DotNet";
            var list = Directory.GetFiles(path, "*.csproj", SearchOption.AllDirectories).ToList();

            foreach (var filePath in list)
            {
                var allText = File.ReadAllText(filePath);
                var matches = Regex.Matches(allText, pattern);
                var ms = matches.Select(m => new Dependency { Name = m.Groups[1].Value, Version = m.Groups[2].Value }).ToList();
                listOfDependencies.AddRange(ms);
            }

            var finalList = listOfDependencies.Distinct().Where(d => !d.Name.StartsWith("Sita.")).OrderBy(d=>d.Name);
            var resultPath = @"C:\Git\DotNet\FlightDbDependecies\list.json";
            File.WriteAllText(resultPath, JsonSerializer.Serialize(finalList));
        }
    }
}