using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        int n = 4;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i+1; j++)
            {
                Write(" ");
            }

            for (int j = i; j < n; j++)
            {
                Write("*");
            }
            WriteLine();
        }
    }
}
