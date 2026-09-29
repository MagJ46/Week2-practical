/*
 * Course: COM326 Object Oriented Programming
 * Practical: Week 2 Tasks 3 - 10
 * Author: [Your Name Here]
 * Date: [Insert Date]
 * Description: Combined solution for Week 2 practical including language menu, 
 *              word counter, Caesar cipher (encrypt/decrypt/validation), 
 *              and circle area calculation.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        bool exitApp = false;

        while (!exitApp)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("       COM326 WEEK 2 PRACTICAL MENU     ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Task 3 & 4: Language Selection Menu");
            Console.WriteLine("2. Task 5: Word Counter");
            Console.WriteLine("3. Tasks 6 - 9: Caesar Cipher System");
            Console.WriteLine("4. Task 10: Circle Area Calculator");
            Console.WriteLine("0. Exit");
            Console.WriteLine("========================================");
            Console.Write("Select a task option (0-4): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    RunLanguageMenuTask();
                    break;
                case "2":
                    RunWordCountTask();
                    break;
                
                case "0":
                    exitApp = true;
                    Console.WriteLine("Exiting application. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    // =========================================================================
    // TASKS 3 & 4: LANGUAGE MENU
    // =========================================================================

    static void RunLanguageMenuTask()
    {
        Console.WriteLine("=== Task 3 & 4: Language Selection ===");
        int option;
        do
        {
            PrintMenu();
            option = GetOption();
            string message = GetMessage(option);
            Console.WriteLine($"Message: {message}\n");
        } while (option != 0);

        // Test Task 3 requirement explicitly for argument 8
        Console.WriteLine("Testing GetMessage(8): " + GetMessage(8));

        Console.WriteLine("\nPress Enter to return to main menu...");
        Console.ReadLine();
    }

    // Task 3: Print Menu
    static void PrintMenu()
    {
        Console.WriteLine("Select a language:");
        Console.WriteLine("0 - English (Exit)");
        Console.WriteLine("1 - French");
        Console.WriteLine("2 - Spanish");
        Console.WriteLine("3 - German");
        Console.WriteLine("4 - Italian");
    }

    // Task 4: Get Option from User
    static int GetOption()
    {
        Console.Write("Enter your choice: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.Write("Invalid input. Enter an integer: ");
        }
        return choice;
    }

    // Task 3: Switch Statement Implementation
    static string GetMessage(int language)
    {
        switch (language)
        {
            case 0:
                return "Goodbye";
            case 1:
                return "Bonjour";
            case 2:
                return "Ola";
            case 3:
                return "Hallo";
            case 4:
                return "Ciao";
            default:
                return "Please enter a valid option";
        }
    }

    // =========================================================================
    // TASK 5: WORD COUNTER
    // =========================================================================

    static void RunWordCountTask()
    {
        Console.WriteLine("=== Task 5: Word Count ===");
        Console.Write("Enter a camelCase or PascalCase string (or press Enter for default): ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            input = "ThisIsASequenceOfWords";
        }

        Console.WriteLine($"Input String : {input}");
        Console.WriteLine($"Word Count   : {CountWords(input)}");

        Console.WriteLine("\nPress Enter to return to main menu...");
        Console.ReadLine();
    }

    // Task 5: Count Words in Pascal/CamelCase String
    static int CountWords(string str)
    {
        if (string.IsNullOrEmpty(str)) return 0;

        int count = 0;
        foreach (char c in str)
        {
            if (char.IsUpper(c))
            {
                count++;
            }
        }
        return count;
    }

    
}