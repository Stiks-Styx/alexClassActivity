namespace BSCS_1A_Alcazar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*HelloWorld("Console.ReadLine();");*/
            /*int num = 7;

            Console.WriteLine(num++);
            Console.WriteLine(++num);
            Console.WriteLine(num);*/
            string inputUsername;
            string inputPassword;

            
            retry:
            Console.Write("What is the Username: ");
            inputUsername = Console.ReadLine();
            Console.Write("What is the Password: ");
            inputPassword = Console.ReadLine();          

            string username = "johnny";
            string password = "johnny";
            if ((inputUsername == username) && (inputPassword == password))
            {
                Console.WriteLine("LogIn Succesful");
                Console.Write("Pick a number: ");
                int num = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(num % 2 == 0 ? $"{num} is even number" : $"{num} is odd number");
            }
            else
            {
                askAgain:
                Console.WriteLine("Wrong Username or Password");
                Console.WriteLine("Press Y to try again N to exit");
                char inputTry;
                inputTry = Convert.ToChar(Console.ReadLine().ToLower());
                if (inputTry == 'y')
                {
                    goto retry;
                }
                else if (inputTry == 'n')
                {
                    return;
                }
                else
                {
                    goto askAgain;
                }                
            }
        }
    }
}
