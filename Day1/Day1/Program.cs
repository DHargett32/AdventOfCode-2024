
class Program
{
    static void Main(string[] args)
    {
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        // populate and sort the lists
        PopulateLists(ref leftList, ref rightList);

        // get the total difference
        Console.WriteLine($"Total distance = {GetTotalDistance(leftList, rightList)}");
        // calculate the similarity score
        Console.WriteLine($"Similarity score = {CalculateSimilarityScore(leftList, rightList)}");
        Console.ReadLine();
    }

    private static void PopulateLists(ref List<int> leftList, ref List<int> rightList)
    {
        // read text file
        String line;
        string[] splitLine;
        try
        {
            StreamReader file = new StreamReader(@".\..\..\..\files\input.txt");

            //Read the first line of text
            line = file.ReadLine();

            //Continue to read until you reach end of file
            while (line != null)
            {
                // split string by ' '
                splitLine = line.Split("   ");

                // cast each element to an integer before adding it to the list
                //  first item goes to leftList and second item goes to rightList
                leftList.Add(Int32.Parse(splitLine[0]));
                rightList.Add(Int32.Parse(splitLine[1]));

                //Read the next line
                line = file.ReadLine();
            }
            //close the file
            file.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            // sort both lists
            leftList.Sort();
            rightList.Sort();
        }
    }

    private static int GetTotalDistance(List<int> leftList, List<int> rightList)
    {
        int totalDistance = 0;
        for (int i = 0; i < leftList.Count; i++)
        {
            int totalDist = Math.Abs(leftList[i] - rightList[i]);
            totalDistance += Math.Abs(leftList[i] - rightList[i]);
        }

        return totalDistance;
    }

    // Calculate the similarity score by 
    private static object CalculateSimilarityScore(List<int> leftList, List<int> rightList)
    {
        int similarityScore = 0;

        foreach (int item in leftList)
        {
            int matchingElements = rightList.Count(i => i == item);
            similarityScore += item * matchingElements;
        }

        return similarityScore;
    }

}