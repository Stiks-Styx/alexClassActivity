namespace _103024 //change this with the project file name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            int i = 0;
            try
            {
                string input = Console.ReadLine();
                
                
                /*Start:
                if (input == null) return;
                if (i >= input.Length)
                {
                    Console.WriteLine(result);
                    return;
                }

                switch (input[i]) // replace 0 with i
                {
                    case '0': result += "zero "; break;
                    case '1': result += "one "; break;
                    case '2': result += "two "; break;
                    case '3': result += "three "; break;
                    case '4': result += "four "; break;
                    case '5': result += "five "; break;
                    case '6': result += "six "; break;
                    case '7': result += "seven "; break;
                    case '8': result += "eight "; break;
                    case '9': result += "nine "; break;
                }

                i++;
                goto Start;
*/
                // =====================================================================//
                switch (input[0])
                {
                    case '0': result += "zero "; break;
                    case '1': result += "one "; break;
                    case '2': result += "two "; break;
                    case '3': result += "three "; break;
                    case '4': result += "four "; break;
                    case '5': result += "five "; break;
                    case '6': result += "six "; break;
                    case '7': result += "seven "; break;
                    case '8': result += "eight "; break;
                    case '9': result += "nine "; break;
                }
                switch (input[1])
                {
                    case '0': result += "zero "; break;
                    case '1': result += "one "; break;
                    case '2': result += "two "; break;
                    case '3': result += "three "; break;
                    case '4': result += "four "; break;
                    case '5': result += "five "; break;
                    case '6': result += "six "; break;
                    case '7': result += "seven "; break;
                    case '8': result += "eight "; break;
                    case '9': result += "nine "; break;
                }
                switch (input[2])
                {
                    case '0': result += "zero "; break;
                    case '1': result += "one "; break;
                    case '2': result += "two "; break;
                    case '3': result += "three "; break;
                    case '4': result += "four "; break;
                    case '5': result += "five "; break;
                    case '6': result += "six "; break;
                    case '7': result += "seven "; break;
                    case '8': result += "eight "; break;
                    case '9': result += "nine "; break;
                }
                Console.WriteLine(result.Trim());
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine(result.Trim());
            }
        }
    }
}
