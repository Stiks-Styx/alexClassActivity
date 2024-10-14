using System.Threading.Channels;

namespace labAct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numGrade;
            double result = 0;


            Console.Write("What is Your Name: ");
            string name = Console.ReadLine();

            Console.Write("What Program are you in: ");
            string program = Console.ReadLine();

            Console.Write("What Course: ");
            string course = Console.ReadLine();

            Console.Write("What College department are you in: ");
            string college = Console.ReadLine();

            double[] gradePoint = { 1.00, 1.25, 1.50, 1.75,
                                    2.00, 2.25, 2.50, 2.75,
                                    3.00, 4.00, 5.00};

            string description = "";
            string[] descriptionArray = { "Excellent", "Very Satisfactory", "Satisfactory", "Fairly Satisfactory", "Passed", "Conditional Failure", "Failed" };

            Console.Write("Type which option would you like |Option1, Option2, Option3|: ");
            string option = Console.ReadLine();
            option = option.ToLower();


            if (option == "option1")
            {
                Console.Write("What is your grade: ");
                numGrade = Convert.ToDouble(Console.ReadLine());

                if (numGrade > 100 || numGrade < 50)
                {
                    Console.WriteLine($"The grade {numGrade} is an invalid grade.");
                    return;
                }
                else if (numGrade >= 96.00 && numGrade <= 100.99)
                {
                    description = descriptionArray[0];
                    result = (numGrade >= 99 && numGrade <= 100.00) ? gradePoint[0] : gradePoint[1]; 
                }
                else if (numGrade >= 90.00 && numGrade <= 95.99)
                {
                    description = descriptionArray[1];
                    result = (numGrade >= 93.00 && numGrade <= 95.99) ? gradePoint[2] : gradePoint[3]; 
                }
                else if (numGrade >= 84.00 && numGrade <= 89.99)
                {
                    description = descriptionArray[2];
                    result = (numGrade >= 87.00 && numGrade <= 89.99) ? gradePoint[4] : gradePoint[5]; 
                }
                else if (numGrade >= 78.00 && numGrade <= 83.00)
                {
                    description = descriptionArray[3];
                    result = (numGrade >= 81.00 && numGrade <= 83.00) ? gradePoint[6] : gradePoint[7]; 
                }
                else if (numGrade >= 75.00 && numGrade <= 77.99)
                {
                    description = descriptionArray[4];
                    result = gradePoint[8];
                }
                else if (numGrade >= 70.00 && numGrade <= 74.99)
                {
                    description = descriptionArray[5];
                    result = gradePoint[9];
                }
                else if (numGrade >= 50.00 && numGrade <= 69.99)
                {
                    description = descriptionArray[6];
                    result = gradePoint[10];
                }

                Console.WriteLine($"{name}, a student from {program} under the {college}, enrolled in {course}, received a grade of {numGrade}.\nThe corresponding grade point is {result} which is described as {description}.");
            }
            else if (option == "option2")
            {
                Console.WriteLine("\nNumerical Grade | Grade Point | Description\n");
                Console.WriteLine("    99-100          1.00        Excellent");
                Console.WriteLine("    96-98           1.25        Excellent");
                Console.WriteLine("    93-95           1.50        Very Satisfactory");
                Console.WriteLine("    90-92           1.75        Very Satisfactory");
                Console.WriteLine("    87-89           2.00        Satisfactory");
                Console.WriteLine("    84-86           2.25        Satisfactory");
                Console.WriteLine("    81-83           2.50        Fairly Satisfactory");
                Console.WriteLine("    78-80           2.75        Fairly Satisfactory");
                Console.WriteLine("    75-77           3.00        Passed");
                Console.WriteLine("    70-74           4.00        Conditional Failure");
                Console.WriteLine("    60 and below    5.00        Failed");
            }
            else if (option == "option3")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid Selection Please Select Either Option1, Option2, or Option3 only");
            }
        }
    }
}
