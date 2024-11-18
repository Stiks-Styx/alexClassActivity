using static System.Console;
using static System.Convert;

internal class Program
{
    static void Main(string[] args)
    {
        int n = ToInt32(ReadLine());
        int evenSum = 0;
        int oddSum = 0;

        for (int i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
            {
                evenSum += i;
            }
            else
            {
                oddSum += i;
            }
        }
        WriteLine($"The sum of all even number from 1 to {n}: {evenSum}");
        WriteLine($"The sum of all odd number from 1 to {n}: {oddSum}");
    }
}
