using System.IO;
using BoggleSolver.Library;
using Newtonsoft.Json;

namespace BoggleSolver.Tests
{
    public class TestData
    {
        public Boggle[] Boggles { get; set; }

        public TestData()
        {
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggles.json");
            Boggles = JsonConvert.DeserializeObject<Boggle[]>(json);
        }
    }
}