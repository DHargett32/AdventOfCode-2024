using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        ReadInputFile();
    }

    private static void ReadInputFile()
    {
        StreamReader file = new StreamReader(@"./../../../sample-input.txt");

        string inputFileToParse = file.ReadToEnd();

        string pattern = @"[A-Za-z]+\([^)]*\)";
        Regex r = new Regex(pattern);
        var matches = r.Matches(inputFileToParse).ToList();

        string[] separators = { "mul(", ",", ")" };
        matches.ForEach(i => i.Value.Split(separators,StringSplitOptions.None));
        var numbers = matches.Where(i => Int32.Parse(i.Value) >= 0);
            
        // mul(123,456)
    }
}