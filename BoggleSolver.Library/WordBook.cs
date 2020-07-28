using System.IO;

namespace BoggleSolver.Library
{
    public class WordBook
    {
        public const string Test = "Test";
        public const string Mini = "Mini";
        public const string Midi = "Midi";
        public const string Maxi = "Maxi";

        public static string GetPath(string dictionary)
        {
            return $"{Directory.GetCurrentDirectory()}/Dictionary/{dictionary}.txt";
        }

        public static string[] GetWords(string size)
        {
            return File.ReadAllLines(GetPath(size));
        }
    }
}