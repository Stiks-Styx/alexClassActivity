using static System.Console;
using static System.Convert;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> result = new List<int>();
        int count=0;
        Write("Input a number: ");
        int n = ToInt32(ReadLine());
        int i = 1;

        while (count < n)
        {
            while (true)
            {
                if (i % 2 != 0)
                {
                    count++;
                    result.Add(i);
                }
                i++;
                if (count == n) break;
            }
        }
        string output = String.Join(", ", result);
        WriteLine(output);
    }
}
