namespace Red_NosedReports;

class Program
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText("input.txt");
        string[] lines = input.Split('\n');
        List<List<int>> list = new List<List<int>>();
        for (int r = 0; r < lines.Length; r++)
        {
            list.Add(new List<int>());
            string[] nums = lines[r].Split(' ');
            for (int i = 0; i < nums.Length; i++)
            {
                list[r].Add(int.Parse(nums[i]));
            }
        }

        int valid = 0;
        for (int r = 0; r < list.Count; r++)
        {
            // Part 01
            // valid += IsValid(list[r]) ? 1 : 0;
            // Part 02
            valid += IsValidWrapper(list[r]) ? 1 : 0;
        }
        Console.WriteLine(valid);
    }

    static bool IsValidWrapper(List<int> list)
    {
        if (IsValid(list)) {
            return true;
        }

        for (int i = 0; i < list.Count; i++)
        {
            List<int> newList = new List<int>();
            for (int j = 0; j < list.Count; j++)
            {
                if (j!=i)
                {
                    newList.Add(list[j]);
                }
            }
            if (IsValid(newList)) 
            {
                return true;
            }
        }
        return false;
    }

    static bool IsValid(List<int> nums)
    {
        bool match = true;
        bool assending = true;
        for (int c = 0; c < nums.Count - 1; c++)
        {
            int diff = nums[c+1] - nums[c];
            if (Math.Abs(diff) > 3 || diff == 0)
            {
                match = false;
                break;
            }
            bool current_assending = nums[c+1] > nums[c];
            if (c == 0)
            {
                assending = current_assending;
            }
            else
            {
                if (current_assending != assending)
                {
                    match = false;
                    break;
                }
            }
        }
        return match;
    }
}
