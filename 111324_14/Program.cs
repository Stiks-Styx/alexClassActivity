using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        int n = 4;

        for (int i = n; i > 0; i--)
        {
            for (int j = 1; j < i+1; j++)
            {
                Write(j);
            }
            WriteLine();
        }
    }
}
