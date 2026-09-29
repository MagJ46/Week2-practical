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
                case "3":
                    CipherMenuSystem();
                    break;
                case "4":
                    RunCircleAreaTask();
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

    // =========================================================================
    // TASKS 6 - 9: CAESAR CIPHER SYSTEM
    // =========================================================================

    static void CipherMenuSystem()
    {
        bool inCipherMenu = true;

        while (inCipherMenu)
        {
            try
            {
                Console.WriteLine("=== Caesar Cipher System (Tasks 6-9) ===");
                Console.WriteLine("1. Encrypt Text");
                Console.WriteLine("2. Decrypt Text");
                Console.WriteLine("3. Run Task 9 Test Suite");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    inCipherMenu = false;
                    break;
                }

                if (choice == "3")
                {
                    RunCipherTests();
                    continue;
                }

                if (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Invalid option selected.\n");
                    continue;
                }

                Console.Write("Enter string: ");
                string text = Console.ReadLine();

                Console.Write("Enter rotation key K (0 < K < 100): ");
                int k = int.Parse(Console.ReadLine());

                // Task 9 Constraint check: Ensure 0 < K < 100
                if (k <= 0 || k >= 100)
                {
                    Console.WriteLine("Error: Rotation value must be strictly greater than 0 and less than 100.\n");
                    continue;
                }

                if (choice == "1")
                {
                    string encrypted = Encrypt(text, k);
                    Console.WriteLine($"\nOriginal Text : {text}");
                    Console.WriteLine($"Encrypted Text: {encrypted}\n");
                }
                else if (choice == "2")
                {
                    string decrypted = Decrypt(text, k);
                    Console.WriteLine($"\nEncrypted Text: {text}");
                    Console.WriteLine($"Decrypted Text: {decrypted}\n");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid integer for rotation key.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}\n");
            }
        }
    }

    // Tasks 6 & 9: Encrypt with Circular Wrap & Case Sensitivity
    static string Encrypt(string input, int K)
    {
        K = K % 26; // Normalize rotation key
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (char.IsUpper(ch))
            {
                result[i] = (char)('A' + (ch - 'A' + K) % 26);
            }
            else if (char.IsLower(ch))
            {
                result[i] = (char)('a' + (ch - 'a' + K) % 26);
            }
            else
            {
                // Non-alphabetic symbols (hyphens, spaces, punctuation) remain untouched
                result[i] = ch;
            }
        }
        return new string(result);
    }

    // Tasks 7 & 9: Decrypt Implementation
    static string Decrypt(string input, int K)
    {
        K = K % 26; // Normalize rotation key
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (char.IsUpper(ch))
            {
                result[i] = (char)('A' + (ch - 'A' - K + 26) % 26);
            }
            else if (char.IsLower(ch))
            {
                result[i] = (char)('a' + (ch - 'a' - K + 26) % 26);
            }
            else
            {
                result[i] = ch;
            }
        }
        return new string(result);
    }

    // Task 9 Required Test Suite
    static void RunCipherTests()
    {
        Console.WriteLine("\n--- Task 9 Required Test Cases ---");
        string[] testStrings = { "try-catch", "MixedCASE", "C# string manipulation is fun!" };
        int key = 3;

        foreach (string str in testStrings)
        {
            string encrypted = Encrypt(str, key);
            string decrypted = Decrypt(encrypted, key);

            Console.WriteLine($"Original  : {str}");
            Console.WriteLine($"Encrypted : {encrypted}");
            Console.WriteLine($"Decrypted : {decrypted}");
            Console.WriteLine(new string('-', 40));
        }
        Console.WriteLine();
    }

    // =========================================================================
    // TASK 10: MATH CLASS - CIRCLE AREA
    // =========================================================================

    static void RunCircleAreaTask()
    {
        double radius = -1;

        Console.WriteLine("=== Task 10: Circle Area Calculator ===");

        while (radius != 0)
        {
            Console.Write("Enter circle radius (or enter 0 to exit back to main menu): ");
            if (double.TryParse(Console.ReadLine(), out radius))
            {
                if (radius == 0)
                {
                    Console.WriteLine("Returning to main menu...\n");
                    break;
                }
                else if (radius < 0)
                {
                    Console.WriteLine("Please enter a positive radius value.\n");
                }
                else
                {
                    double area = CircleArea(radius);
                    Console.WriteLine($"Radius: {radius} | Calculated Area: {area:F4}\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid numerical value.\n");
            }
        }
    }

    // Task 10 Required Signature: Uses Math.Pow and Math.PI
    static double CircleArea(double radius)
    {
        return Math.PI * Math.Pow(radius, 2);
    }
}