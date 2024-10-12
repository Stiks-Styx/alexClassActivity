using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Get user input for age and income
        Console.Write("Enter customer age: ");
        int customerAge = Convert.ToInt32(Console.ReadLine());

        // Check if age is eligible
        if (customerAge < 21 || customerAge > 65)
        {
            Console.WriteLine("Not eligible for any loan due to age.");
            return; // Stop the program
        }

        Console.Write("Enter customer monthly income: ");
        decimal monthlyIncome = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Credit Score: ");
        int creditScore = Convert.ToInt32(Console.ReadLine());

        // Set initial interest rates based on credit score
        decimal personalLoanRate, carLoanRate, homeLoanRate;

        if (creditScore > 750)
        {
            personalLoanRate = 0.05m;
            carLoanRate = 0.04m;
            homeLoanRate = 0.03m;
        }
        else if (creditScore >= 600 && creditScore <= 750)
        {
            personalLoanRate = 0.08m;
            carLoanRate = 0.06m;
            homeLoanRate = 0.05m;
        }
        else // creditScore < 600
        {
            personalLoanRate = 0.1m;
            carLoanRate = 0.08m;
            homeLoanRate = 0.07m;
        }

        // Get employment status
        Console.Write("Enter employment status (salaried/self-employed): ");
        string employmentStatus = Console.ReadLine().ToLower();

        // Call the method to get the eligible loans and max loan amount
        var result = LoanEligibility.GetLoanOptions(customerAge, monthlyIncome, employmentStatus, personalLoanRate, carLoanRate, homeLoanRate);

        // Check if there are eligible loans
        if (result.Item1.Length == 0)
        {
            Console.WriteLine("Not eligible for any loans.");
            return;
        }

        // Display eligible loans
        Console.WriteLine("Eligible Loans:");
        for (int i = 0; i < result.Item1.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {result.Item1[i]}");
        }

        // Ask the user to select a loan
        Console.Write("Select a loan type by entering the number: ");
        int loanChoice = Convert.ToInt32(Console.ReadLine()) - 1;

        // Ensure valid choice
        if (loanChoice < 0 || loanChoice >= result.Item1.Length)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        Console.WriteLine($"You selected: {result.Item1[loanChoice]}");

        // Prompt user for loan tenure based on the loan type
        int maxTenure = LoanEligibility.GetMaxLoanTenure(result.Item1[loanChoice]);
        Console.WriteLine($"The maximum tenure for {result.Item1[loanChoice]} is {maxTenure} years.");
        Console.Write("Enter desired loan tenure (in years): ");

        int loanTenure = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Loan Tenure: {loanTenure} years.");

        // Validate loan tenure
        if (loanTenure < 1 || loanTenure > maxTenure)
        {
            Console.WriteLine($"Invalid tenure. It should be between 1 and {maxTenure} years.");
            return;
        }

        // Monthly interest rate calculation
        decimal annualInterestRate = result.Item2.Item2[loanChoice];
        Console.WriteLine($"Annual Interest Rate: {annualInterestRate * 100}%"); // Print the annual interest rate
        decimal monthlyInterestRate = annualInterestRate / 12;
        Console.WriteLine($"Monthly Interest Rate: {monthlyInterestRate * 100}%"); // Print the monthly interest rate

        int loanTenureMonths = loanTenure * 12; // Convert years to months

        // Compute the monthly installment using the formula
        decimal monthlyInstallment;

        if (monthlyInterestRate == 0) // Handle zero interest rate case
        {
            monthlyInstallment = result.Item2.Item1 / loanTenureMonths; // No interest, just divide by number of months
        }
        else
        {
            monthlyInstallment = (result.Item2.Item1 * monthlyInterestRate * (decimal)Math.Pow((double)(1 + monthlyInterestRate), loanTenureMonths))
                                 / ((decimal)Math.Pow((double)(1 + monthlyInterestRate), loanTenureMonths) - 1);
        }

        // Compute the total cost of the loan
        decimal totalCostOfLoan = monthlyInstallment * loanTenureMonths;

        // Output the results
        Console.WriteLine("\n\n\nLoan Eligibility: Eligible");
        Console.WriteLine($"Loan Amount: ₱{result.Item2.Item1:N}");
        Console.WriteLine($"Interest Rate: {annualInterestRate * 100}%");
        Console.WriteLine($"Monthly Installment: ₱{monthlyInstallment:N}");
        Console.WriteLine($"Total Cost of Loan: ₱{totalCostOfLoan:N}");
    }
}

public class LoanEligibility
{
    public static (string[], (decimal, decimal[])) GetLoanOptions(int age, decimal monthlyIncome, string employmentStatus, decimal personalLoanRate, decimal carLoanRate, decimal homeLoanRate)
    {
        // Array of all loan types
        string[] loanTypes = { "Personal Loan", "Car Loan", "Home Loan" };
        string[] eligibleLoans = new string[] { }; // To store eligible loans
        decimal maxLoanAmount = 0;
        decimal[] totalInterestRates = new decimal[3]; // Array to store total interest rates for each loan type

        // Determine eligibility based on age
        if (age < 21 || age > 65)
        {
            return (new string[] { }, (0, new decimal[0])); // Not eligible for any loan
        }
        else if (age >= 21 && age <= 25)
        {
            if (monthlyIncome < 15000)
            {
                eligibleLoans = new string[] { loanTypes[0] }; // Only Personal Loan
                maxLoanAmount = 200000; // ₱200,000
                totalInterestRates[0] = personalLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
            }
            else if (monthlyIncome >= 15000 && monthlyIncome <= 50000)
            {
                eligibleLoans = new string[] { loanTypes[0], loanTypes[1] }; // Personal and Car Loans
                maxLoanAmount = 1000000; // ₱1,000,000
                totalInterestRates[0] = personalLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
                totalInterestRates[1] = carLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
            }
            else // monthlyIncome > 50000
            {
                eligibleLoans = new string[] { loanTypes[0], loanTypes[1], loanTypes[2] }; // Personal, Car, and Home Loans
                maxLoanAmount = 5000000; // ₱5,000,000
                totalInterestRates[0] = personalLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
                totalInterestRates[1] = carLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
                totalInterestRates[2] = homeLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
            }
        }
        else if (age >= 26 && age <= 45)
        {
            if (monthlyIncome < 15000)
            {
                eligibleLoans = new string[] { loanTypes[0] }; // Only Personal Loan
                maxLoanAmount = 200000; // ₱200,000
                totalInterestRates[0] = personalLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
            }
            else if (monthlyIncome >= 15000 && monthlyIncome <= 50000)
            {
                eligibleLoans = new string[] { loanTypes[0], loanTypes[1] }; // Personal and Car Loans
                maxLoanAmount = 1000000; // ₱1,000,000
                totalInterestRates[0] = personalLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
                totalInterestRates[1] = carLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
            }
            else // monthlyIncome > 50000
            {
                eligibleLoans = new string[] { loanTypes[0], loanTypes[1], loanTypes[2] }; // Personal, Car, and Home Loans
                maxLoanAmount = 5000000; // ₱5,000,000
                totalInterestRates[0] = personalLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
                totalInterestRates[1] = carLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
                totalInterestRates[2] = homeLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
            }
        }
        else if (age >= 46 && age <= 65)
        {
            if (monthlyIncome < 15000)
            {
                eligibleLoans = new string[] { loanTypes[0] }; // Only Personal Loan
                maxLoanAmount = 200000; // ₱200,000
                totalInterestRates[0] = personalLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
            }
            else if (monthlyIncome >= 15000 && monthlyIncome <= 50000)
            {
                eligibleLoans = new string[] { loanTypes[0], loanTypes[1] }; // Personal and Car Loans
                maxLoanAmount = 1000000; // ₱1,000,000
                totalInterestRates[0] = personalLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
                totalInterestRates[1] = carLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
            }
            else // monthlyIncome > 50000
            {
                eligibleLoans = new string[] { loanTypes[0], loanTypes[1], loanTypes[2] }; // Personal, Car, and Home Loans
                maxLoanAmount = 5000000; // ₱5,000,000
                totalInterestRates[0] = personalLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
                totalInterestRates[1] = carLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
                totalInterestRates[2] = homeLoanRate + (employmentStatus == "self-employed" ? 0.015m : 0);
            }
        }
                //Item1         //Item2.Item1   //Item2.Item2
        return (eligibleLoans, (maxLoanAmount, totalInterestRates));
    }

    public static int GetMaxLoanTenure(string loanType)
    {
        switch (loanType)
        {
            case "Personal Loan":
                return 5;
            case "Car Loan":
                return 7;
            case "Home Loan":
                return 30;
            default:
                return 0;
        }
    }
}
