using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        int n = 5;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i - 1; j++)
            {
                Write(" ");
            }

            for (int j = 1; j <= 2 * (n-i) + 1; j++)
            {
                Write("*");
            }
            WriteLine();
        }
    }
}

