using static System.Console;
using static System.Convert;

internal class Program
{
    static void Main(string[] args)
    {
        int n = ToInt32(ReadLine());
        int sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }
        WriteLine($"The sum of all numbers from 1 to {n} is: {sum}");
    }
}
