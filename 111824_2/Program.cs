using static System.Console;
using static System.Convert;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Write($"Enter number {i + 1}: ");
            numbers[i] = ToInt32(ReadLine());
        }

        int smallest = numbers[0];
        foreach (int num in numbers)
        {
            if (num < smallest)
            {
                smallest = num;
            }
        }

        WriteLine($"The smallest number is: {smallest}");
    }
}
