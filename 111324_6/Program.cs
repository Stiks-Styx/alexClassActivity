using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        for (int i = 1; i <= 1000; i++)
        {
            if (i % 3 == 0)
            {
                sum += i;
            }
        }
        WriteLine($"The sum of all the numbers between 1 and 1000 which are divisible by 3 is: {sum}");
    }
}
