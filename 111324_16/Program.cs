using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        int n = 5;
        int m = 6;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (i == 1 || i == n || j == 1 || j == m)
                {
                    Write("*");
                }
                else
                {
                    Write(" ");
                }
            }
            WriteLine();
        }
    }
}
