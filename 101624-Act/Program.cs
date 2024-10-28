namespace _101624_Act
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal mixMatchPrice = 150m;
            decimal seniorDiscount = 0.20m;
            int amountOrder = 0;
            string isSenior = "";
            decimal totalPrice = 0m;

            int options = 0, options1 = 0, options2 = 0;

            string meal1 = "1-Piece Chickenjoy";
            string meal2 = "Jolly Spaghetti";
            string meal3 = "Burger Steak";

            string sides1 = "French Fries";
            string sides2 = "Mashed Potatoes";
            string sides3 = "Buttered Corn";

            string drinks1 = "Coke";
            string drinks2 = "Sprite";
            string drinks3 = "Iced Tea";

            string selectedMeal = "";
            string selectedSide = "";
            string selectedDrink = "";

            Console.WriteLine("Welcome to Johnnybee Mix and Match!\n");

            /*********************************************************************/

            Console.WriteLine("\nSelect Your Main Dish: ");
            Console.WriteLine($"1 : {meal1}\n2 : {meal2}\n3 : {meal3}");
            Console.Write("Enter Your Choice: ");
            options = Convert.ToInt32(Console.ReadLine());

            switch (options) // for meal
            {
                case 1:
                    selectedMeal = meal1;
                    break;
                case 2:
                    selectedMeal = meal2;
                    break;
                case 3:
                    selectedMeal = meal3;
                    break;
                default:
                    Console.WriteLine($"{options} is an Invalid, Please Select from 1-3");
                    return;
            }

            /*********************************************************************/

            Console.WriteLine("\nSelect Your Side Dish: ");
            Console.WriteLine($"1 : {sides1}\n2 : {sides2}\n3 : {sides3}");
            Console.Write("Enter Your Choice: ");
            options1 = Convert.ToInt32(Console.ReadLine());

            switch (options1) // for sides
            {
                case 1:
                    selectedSide = sides1;
                    break;
                case 2:
                    selectedSide = sides2;
                    break;
                case 3:
                    selectedSide = sides3;
                    break;
                default:
                    Console.WriteLine($"{options1} is an Invalid, Please Select from 1-3");
                    return;
            }

            /*********************************************************************/

            Console.WriteLine("\nSelect Your Drinks: ");
            Console.WriteLine($"1 : {drinks1}\n2 : {drinks2}\n3 : {drinks3}");
            Console.Write("Enter Your Choice: ");
            options2 = Convert.ToInt32(Console.ReadLine());

            switch (options2) // for drinks
            {
                case 1:
                    selectedDrink = drinks1;
                    break;
                case 2:
                    selectedDrink = drinks2;
                    break;
                case 3:
                    selectedDrink = drinks3;
                    break;
                default:
                    Console.WriteLine($"{options2} is an Invalid, Please Select from 1-3");
                    return;
            }

            Console.WriteLine($"\nThe Price of Johnnybee Mix and Match meal is: Php {mixMatchPrice.ToString("F2")}");
            Console.Write("How many sets of the Johnnybee Mix and Match meal do you want to order: ");

            amountOrder = Convert.ToInt32(Console.ReadLine());
            if (amountOrder <= 0)
            {
                Console.WriteLine("The amount of order should be atleast 1:");
                return;
            }

            Console.Write("\nAre you a senior citezen (Yes|No): ");
            isSenior = Console.ReadLine().ToLower();

            if (isSenior == "yes")
            {
                totalPrice = (mixMatchPrice * amountOrder) * seniorDiscount;
                totalPrice = (mixMatchPrice * amountOrder) - totalPrice;
            }
            else
            {
                totalPrice = mixMatchPrice * amountOrder;
            }

            Console.WriteLine($"\nYou ordered {amountOrder} sets of {selectedMeal}, {selectedSide}, and {selectedDrink}");
            Console.WriteLine($"The total price of your order is {totalPrice.ToString("F2")}");
            Console.WriteLine("\nThank you for dining with us at Johnnybee! \nWe truly appreciate your patronage and hope you had a wonderful meal.");

        }
    }
}