namespace CeresSearch;

class Program
{
    static void Main(string[] args)
    {
        string input = File.ReadAllText("input.txt");
        var lines = input.Split("\n");
        int rowNum = lines[0].Length;
        int colNum = lines.Length;
        char[,] chars = new char[rowNum, colNum];
        for (int i = 0; i < rowNum; i++) {
            for (int j = 0; j < colNum; j++) {
                chars[i, j] = lines[i][j];
            }
        }

        Console.WriteLine(P01(chars));
        Console.WriteLine(P02(chars));
    }


    static int P01(char[,] c) {
        int r = 0;
        int row = c.GetLength(0);
        int col = c.GetLength(1);
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                if (c[i, j] == 'X') {
                    r += check(i, j+1, i, j+2, i, j+3, row, col, c);
                    r += check(i+1, j+1, i+2, j+2, i+3, j+3, row, col, c);
                    r += check(i+1, j, i+2, j, i+3, j, row, col, c);
                    r += check(i+1, j-1, i+2, j-2, i+3, j-3, row, col, c);
                    r += check(i, j-1, i, j-2, i, j-3, row, col, c);
                    r += check(i-1, j-1, i-2, j-2, i-3, j-3, row, col, c);
                    r += check(i-1, j, i-2, j, i-3, j, row, col, c);
                    r += check(i-1, j+1, i-2, j+2, i-3, j+3, row, col, c);
                }
            }
        }
        return r;
    }

    static int check(int a, int b, int c, int d, int e, int f, int row, int col, char[,] ch) {
        if (a >= 0 && b >= 0 && c >= 0 && d >= 0 && e >= 0 && f >= 0
            && a < row && c < row && e < row && b < col && d < col && f < row) 
        {
            if (ch[a,b] == 'M' && ch[c,d] == 'A' && ch[e,f] == 'S'){
                return 1;
            }
        }
        return 0;
    }

    static int P02(char[,] c) {
        int r = 0;
        int row = c.GetLength(0);
        int col = c.GetLength(1);
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                if (c[i, j] == 'A') {
                    r += check02(i, j, c);
                }
            }
        }
        return r;
    }

    static int check02(int i, int j, char[,] ch) {
        int row = ch.GetLength(0);
        int col = ch.GetLength(1);
        if (i-1 >= 0 && j-1 >= 0 && j+1 < col && i+1 < row) 
        {
            if (ch[i-1,j-1] == 'M' && ch[i+1,j+1] == 'S' && ch[i-1,j+1] == 'M' && ch[i+1,j-1] == 'S'){
                return 1;
            }
            if (ch[i-1,j+1] == 'M' && ch[i+1,j-1] == 'S' && ch[i+1,j+1] == 'M' && ch[i-1,j-1] == 'S'){
                return 1;
            }
            if (ch[i+1,j+1] == 'M' && ch[i-1,j-1] == 'S' && ch[i+1,j-1] == 'M' && ch[i-1,j+1] == 'S'){
                return 1;
            }
            if (ch[i+1,j-1] == 'M' && ch[i-1,j+1] == 'S' && ch[i-1,j-1] == 'M' && ch[i+1,j+1] == 'S'){
                return 1;
            }
        }
        return 0;
    }
}
