
using System;
using System.Linq;

//These are C# namespace declarations, which allow the code to access classes and methods defined in the System and System.Linq namespaces, respectively.

namespace TextOperations
{
    class Program
    {
        static void Main(string[] args)

        {
            //This is the start of the program's Main method, which is the entry point for the program

            while (true)

            {
                Console.WriteLine("Please enter some text (or type 'exit' to quit):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                //This section prompts the user to enter some text and reads in the input. If the user types "exit", the program breaks out of the loop and terminates.



                Console.WriteLine("Please choose an operation to perform:");
                Console.WriteLine("1. Duplicate check");
                Console.WriteLine("2. Count the number of unique vowels");
                Console.WriteLine("3. Output if there are more unique vowels or unique non vowels");

                int operation = int.Parse(Console.ReadLine());

                switch (operation)
                {


                    case 1:
                        string duplicates = new string(input.ToLower().GroupBy(c => c).Where(g => g.Count() > 1).Select(g => g.Key).ToArray());

                        if (duplicates.Length > 0)
                        {
                            Console.WriteLine("Found the following duplicates: " + duplicates);
                        }
                        else
                        {
                            Console.WriteLine("No duplicate values were found.");
                        }
                        break;

                    //If the user chooses operation 1, the program finds any duplicate characters in the input and outputs them, or a message indicating that no duplicates were found.

                    case 2:
                        int uniqueVowels = input.ToLower().Distinct().Count(c => "aeiou".Contains(c));

                        if (uniqueVowels > 0)
                        {
                            Console.WriteLine("The number of vowels is " + uniqueVowels);
                        }
                        else
                        {
                            Console.WriteLine("No vowels were found.");
                        }
                        break;

                    //If the user chooses operation 2, the program counts the number of unique vowels in the input and outputs the result, or a message indicating that no vowels were found.



                    case 3:
                        int uniqueNonVowels = input.ToLower().Distinct().Count(c => !"aeiou".Contains(c));
                        uniqueVowels = input.ToLower().Distinct().Count(c => "aeiou".Contains(c));

                        if (uniqueVowels > uniqueNonVowels)
                        {
                            Console.WriteLine("The text has more vowels than non vowels.");
                        }
                        else if (uniqueNonVowels > uniqueVowels)
                        {
                            Console.WriteLine("The text has more non vowels than vowels.");
                        }
                        else
                        {
                            Console.WriteLine("The text has an equal amount of vowels and non vowels.");
                        }
                        break;

                    //If the user chooses operation 3, the program counts the number of unique vowels and non-vowels in the input and outputs which type of character is more common, or a message indicating that they are equally common.

                    default:
                        Console.WriteLine("Invalid operation selected.");
                        break;

                        //In this case, it means that the user has entered an invalid option for the operation they wish to perform, and the program will display the message "Invalid operation selected." to the console. The 'break' statement following the message will exit the switch statement and allow the program to continue with the next iteration of the while loop
                }
            }
        }
    }
}
