class Program
{
    static void Main(string[] args)
    {
        ReadInputFile();
    }

    private static void ReadInputFile()
    {
        string line;

        try
        {
            StreamReader file = new StreamReader(@".\..\..\..\files\input.txt");

            //Read the first line of text
            line = file.ReadLine();

            int safeReportsTotalCount = 0;

            while (line != null)
            {
                List<int> report = line.Split().Select(l => Int32.Parse(l)).ToList<int>();

                // all increasing
                if (MeetsRequirements_Increasing(report))
                {
                    safeReportsTotalCount++;
                }
                // all decreasing
                else if (MeetsRequirements_Decreasing(report))
                {
                    safeReportsTotalCount++;                   
                }

                line = file.ReadLine();
            }
            file.Close();

            Console.WriteLine($"We have {safeReportsTotalCount} safe reports!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    private static bool MeetsRequirements_Decreasing(List<int> report)
    {
        int? prev_i = null;
        bool hasBadLevel = false;

        foreach (int i in report)
        {
            if (prev_i == null)
                prev_i = i;
            else if (i < prev_i && (i >= (prev_i - 3)))
            {
                prev_i = i;
            }
            else
            {
                // If a bad level is encountered for the first time when evaluating a report, mark the
                //  hasBadLevel flag as true. If we encounter any further bad levels when evaluating a
                //  report, the the report can no longer meet the acceptable criteria.
                if (hasBadLevel)
                    return false;
                else
                    hasBadLevel = true;
            }
        }
        return true;
    }

    private static bool MeetsRequirements_Increasing(List<int> report)
    {
        int? prev_i = null;
        bool hasBadLevel = false;

        foreach (int i in report)
        {
            if (prev_i == null)
                prev_i = i;
            else if(i > prev_i && (i <= (prev_i + 3)))
            {
                prev_i = i;
            }
            else
            {
                // If a bad level is encountered for the first time when evaluating a report, mark the
                //  hasBadLevel flag as true. If we encounter any further bad levels when evaluating a
                //  report, the the report can no longer meet the acceptable criteria.
                if (hasBadLevel)
                    return false;
                else
                    hasBadLevel = true;
            }
        }
        return true;
    }
}