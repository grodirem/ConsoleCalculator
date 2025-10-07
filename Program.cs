namespace ConsoleCalculator;

internal class Program
{
    private static readonly string[] validOperations = { "+", "-", "*", "/" };
    private const string calculateAgain = "1";
    private const string exit = "2";

    static void Main(string[] args)
    {
        while (true)
        {
            RunCalculator();

            var choice = GetUserChoice();

            if (IsExitChosen(choice)) break;
        }
    }

    private static void RunCalculator()
    {
        Console.Clear();
        var firstNumber = GetNumber("Enter the first number: ");
        var operation = GetOperation();
        var secondNumber = GetNumber("Enter the second number: ");
        var result = Calculate(firstNumber, operation, secondNumber);
        PrintResult(result);
        PrintHeaderAfterCalculations();
    }

    private static bool IsExitChosen(string choice)
    {
        if (choice == exit)
        {
            Console.WriteLine("Thank you for using my calculator!");
            return true;
        }

        return false;
    }

    private static string GetUserChoice()
    {
        string? choice;

        while (true)
        {
            Console.Write("Enter your choice (1 or 2): ");
            choice = Console.ReadLine()?.Trim();


            if (choice == calculateAgain || choice == exit)
            {
                return choice;
            }

            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
        }
    }

    private static double GetNumber(string message)
    {
        double number;

        while (true)
        {
            Console.Write(message);
            var input = Console.ReadLine();

            if (double.TryParse(input, out number))
            {
                return number;
            }
            
            Console.WriteLine("Error: Invalid number.");
        }
    }

    private static string GetOperation()
    {
        while (true) 
        {
            Console.WriteLine("Available operations: \"+\", \"-\", \"*\", \"/\".");
            Console.Write("Choose operation: ");

            var operation = Console.ReadLine()?.Trim();

            if (validOperations.Contains(operation))
            {
                return operation!;
            }

            Console.WriteLine("Error: Invalid operation.");
        }
    }

    private static double Calculate(double firstNumber, string operation, double secondNumber)
    {
        switch (operation)
        {
            case "+":
                return firstNumber + secondNumber;
            case "-":
                return firstNumber - secondNumber;
            case "*":
                return firstNumber * secondNumber;
            case "/":
                while (secondNumber == 0)
                {
                    Console.WriteLine("You can't divide by 0. Enter another number:");
                    secondNumber = GetNumber("Enter the second number: ");
                }
                return firstNumber / secondNumber;


            default:
                Console.WriteLine("Error: Unable to perform calculations.");
                return double.NaN;
        }
    }

    private static void PrintResult(double result)
    {
        if (double.IsNaN(result))
        {
            Console.WriteLine("Calculation failed.");
        }
        else if (double.IsInfinity(result))
        {
            Console.WriteLine("Error: Result is too large or too small for a double type.");
        }
        else
        {
            Console.WriteLine($"Result: {result:F3}");
        }
    }

    private static void PrintHeaderAfterCalculations()
    {
        Console.WriteLine();
        Console.WriteLine("What's next?");
        Console.WriteLine("1. Calculate again.");
        Console.WriteLine("2. Exit.");
    }
}
