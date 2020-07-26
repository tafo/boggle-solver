using System.IO;

namespace BoggleSolver.Library
{
    public static class Extensions
    {
        public static string Path(this string dictionary)
        {
            return $"{Directory.GetCurrentDirectory()}/Dictionary/{dictionary}.txt";
        }

        public static string[] ToArray(this string dictionary)
        {
            return File.ReadAllLines(dictionary.Path());
        }
    }
}