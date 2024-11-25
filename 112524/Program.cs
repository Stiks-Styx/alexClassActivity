using static System.Console;
using static System.Convert;
using static System.Threading.Thread;

namespace _112524
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    int pow = 1;
                    WriteLine("Options\n1 : Binary To Decimal\n2 : Decimal To Binary\n3 : Exit");
                    Write("=>: ");
                    int option = ToInt32(ReadLine());
                    WriteLine();
                    string input;
                    int output = 0;

                    switch (option)
                    {
                        case 1:
                            Write("Enter The Number: ");
                            input = ReadLine();
                            for (int i = input.Length - 1; i >= 0; i--)
                            {
                                if (input[i] == '1')
                                {
                                    output += pow;
                                }
                                pow *= 2;
                            }
                            WriteLine($"The Equivalent of {input} To Decimal is: {output}\n");
                            Sleep(3500);
                            Clear();
                            break;
                        case 2:
                            Write("Enter The Number: ");
                            input = ReadLine();
                            output = ToInt32(input);
                            string binary = "";
                            while (output > 0)
                            {
                                binary = (output % 2) + binary;
                                output /= 2;
                            }
                            WriteLine($"The Equivalent of {input} To Decimal is: {binary}\n");
                            Sleep(3500);
                            Clear();
                            break;
                        case 3:
                            WriteLine("Terminating Session...");
                            Thread.Sleep(800);
                            return;
                        default:
                            WriteLine("Wrong Input: Please Only Select 1-3");
                            break;
                    }
                }
                catch (Exception e) { Clear(); }
            }
        }
    }
}
