uusing System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Step 1: Prompt the user to input their name and birthdate
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your birthdate (yyyy-MM-dd): ");
        string birthdateInput = Console.ReadLine();

        // Step 2: Validate the birthdate format using a regular expression
        string dateFormatPattern = @"^\d{4}-\d{2}-\d{2}$";
        if (!Regex.IsMatch(birthdateInput, dateFormatPattern))
        {
            Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
            return; // Exit the program if the date format is incorrect
        }

        DateTime birthdate;
        if (!DateTime.TryParseExact(birthdateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out birthdate))
        {
            Console.WriteLine("Invalid date. Please enter a valid birthdate.");
            return;
        }

        // Step 3: Calculate and display the user's age based on the birthdate
        int age = DateTime.Now.Year - birthdate.Year;
        if (DateTime.Now.Date < birthdate.AddYears(age)) // Adjust if the birthdate hasn't occurred yet this year
        {
            age--;
        }

        Console.WriteLine($"Hello {name}, you are {age} years old.");

        // Step 4: Save the user's information to a file named "user_info.txt"
        string userInfo = $"Name: {name}\nBirthdate: {birthdate:yyyy-MM-dd}\nAge: {age}";
        File.WriteAllText("user_info.txt", userInfo);
        Console.WriteLine("User information saved to 'user_info.txt'.");

        // Step 5: Read and display the contents of the "user_info.txt"
        string fileContents = File.ReadAllText("user_info.txt");
        Console.WriteLine("\nContents of 'user_info.txt':");
        Console.WriteLine(fileContents);

        // Step 6: Prompt the user to enter a directory path
        Console.Write("\nEnter a directory path: ");
        string directoryPath = Console.ReadLine();

        // Step 7: List all files within the specified directory
        if (Directory.Exists(directoryPath))
        {
            Console.WriteLine("\nFiles in the directory:");
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        else
        {
            Console.WriteLine("Directory not found.");
        }

        // Step 8: Prompt the user to input a string
        Console.Write("\nEnter a string: ");
        string inputString = Console.ReadLine();

        // Step 9: Format the string to title case
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string titleCaseString = textInfo.ToTitleCase(inputString.ToLower());
        Console.WriteLine($"Title-cased string: {titleCaseString}");

        // Step 10: Explicitly trigger garbage collection
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Garbage collection triggered.");

        Console.WriteLine("\nProgram completed.");
    }
};
