using System.IO;
using BoggleSolver.Library;
using Newtonsoft.Json;

namespace BoggleSolver.Tests
{
    public static class TestData
    {
        static TestData()
        {
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Boggle.json");
            Boggle = JsonConvert.DeserializeObject<BoggleModel>(json);
        }

        public static BoggleModel Boggle { get; set; }
    }
}