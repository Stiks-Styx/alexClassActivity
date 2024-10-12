using System;

internal class Program
{
    static void Main(string[] args)
    {
        // Declare variables to store the student's grade, converted grade, and grade description
        double intGrade;
        double grade = 0;
        string desc = "";
        // Prompt the user to input the student's grade
        Console.Write("Enter the Numerical Grade: ");

        // Read the input from the user and convert it to a double value
        intGrade = Double.Parse(Console.ReadLine());

        // Check if the input grade is outside the valid range (less than 50 or greater than 100)
        if (intGrade > 100 || intGrade < 50)
        {
            // Print an invalid grade message and exit the program
            Console.WriteLine($"{intGrade} Invalid Grade");
        }
        // Handle the cases for different ranges
        else if (intGrade >= 96 && intGrade <= 100)
        {
            desc = "Excellent";
            grade = intGrade >= 99 ? 1.00 : 1.25;
        }
        else if (intGrade >= 90 && intGrade <= 95.99)
        {
            desc = "Very Satisfactory";
            grade = intGrade >= 93 ? 1.50 : 1.75;
        }
        else if (intGrade >= 84 && intGrade <= 89.99)
        {
            desc = "Satisfactory";
            grade = intGrade >= 87 ? 2.00 : 2.25;
        }
        else if (intGrade >= 78 && intGrade <= 83.99)
        {
            desc = "Fairly Satisfactory";
            grade = intGrade >= 81 ? 2.50 : 2.75;
        }
        else if (intGrade >= 75 && intGrade <= 77.99)
        {
            desc = "Passed";
            grade = 3.00;
        }
        else if (intGrade >= 70 && intGrade <= 74.99)
        {
            desc = "Conditional Failure";
            grade = 4.00;
        }
        else if (intGrade < 70)
        {
            desc = "Failed";
            grade = 5.00;
        }


        string formattedGrade = grade % 1 == 0 ? grade.ToString("F1") : grade.ToString("F2");
        string output = $"The Grade {intGrade} : {formattedGrade} is {desc}.";
        // Output the final grade and description to the user
        Console.WriteLine(output);

    }
}

