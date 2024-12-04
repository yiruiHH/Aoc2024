namespace MullItOver;

class Program
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText("input.txt");
        Console.WriteLine(P01(input));
        Console.WriteLine(P02(input));
    }

    enum Status {
        ShouldBeM,
        ShouldBeU,
        ShouldBeL,
        ShouldBeLe,
        ShouldBeFirstLeftNum,
        ShouldBeNumOrComma,
        ShouldBeFirstRightNum,
        ShouldBeNumOrRi
    }

    static int P01(string input)
    {
        int res = 0;
        Status s = Status.ShouldBeM;
        string l = string.Empty;
        string r = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (c == 'm' && s == Status.ShouldBeM) s = Status.ShouldBeU;
            else if (c == 'u' && s == Status.ShouldBeU) s = Status.ShouldBeL;
            else if (c == 'l' && s == Status.ShouldBeL) s = Status.ShouldBeLe;
            else if (c == '(' && s == Status.ShouldBeLe) s = Status.ShouldBeFirstLeftNum;
            else if (c >= '0' && c <= '9' && (s == Status.ShouldBeFirstLeftNum || s == Status.ShouldBeNumOrComma))
            {
                l += c;
                s = Status.ShouldBeNumOrComma;
            }
            else if (c == ',' && s == Status.ShouldBeNumOrComma)
            {
                s = Status.ShouldBeFirstRightNum;
            }
            else if (c >= '0' && c <= '9' && (s == Status.ShouldBeFirstRightNum || s == Status.ShouldBeNumOrRi))
            {
                r += c;
                s = Status.ShouldBeNumOrRi;
            }
            else if (c == ')' && s == Status.ShouldBeNumOrRi)
            {
                res += int.Parse(l) * int.Parse(r);
                l = string.Empty;
                r = string.Empty;
                s = Status.ShouldBeM;
            }
            else
            {
                l = string.Empty;
                r = string.Empty;
                s = Status.ShouldBeM;
            }
        }
        return res;
    }

    static int P02(string input)
    {
        int res = 0;
        int index = 0;
        bool enabled = true;
        while (index != -1)
        {
            string searchStr = enabled ? "don't()" : "do()";
            index = input.IndexOf(searchStr);
            if (index == -1) 
            {
                if (enabled) 
                {
                    res += P01(input);
                }
                break;
            }
            string subString = input.Substring(0, index + searchStr.Length);
            if (enabled)
            {
                res += P01(subString);
            }
            enabled = !enabled;
            input = input.Substring(index + searchStr.Length);
        }
        
        return res;
    }
}
