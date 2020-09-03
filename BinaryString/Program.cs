using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryString
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display title as the C# console calculator app.
            Console.WriteLine("Check good or not good binary string\r\n");

            bool validInput = false;
            string inputsString;
            do
            {
                // Ask the user to type the binary string.
                Console.WriteLine("------------------------");
                Console.WriteLine("Type a binary string, and then press Enter\n");
                inputsString = Console.ReadLine();
                if (string.IsNullOrEmpty(inputsString))
                {
                    Console.WriteLine("Please enter binary string\n");
                }
                else if (!CheckBinaryFormat(inputsString))
                {
                    Console.WriteLine("You have entered invalid binary string, binary string accepting only 0 and 1\n");
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);

            bool isGoodBinary = true;
            List<int> prefixValues = new List<int>();
            char[] charArr = inputsString.ToCharArray();
            foreach (char ch in charArr)
            {
                prefixValues.Add(int.Parse(ch.ToString()));

                if (CheckZeroValuesGreaterthanOneValues(prefixValues))
                {
                    isGoodBinary = false;
                    break;
                }
            }

            if (isGoodBinary)
            {
                Console.Write($"{inputsString} is good binary string!\n");
            }
            else
            {
                Console.Write($"{inputsString} is not good binary string!\n");
            }

            // Wait for the user to respond before closing.
            Console.Write("\n\nPress any key to close the console app...");
            Console.ReadKey();
        }

        static bool CheckBinaryFormat(string inputsString)
        {
            char[] charArr = inputsString.ToCharArray();
            foreach (char ch in charArr)
            {
                if (ch != '0' && ch != '1')
                    return false;
            }
            return true;
        }

        static bool CheckZeroValuesGreaterthanOneValues(List<int> prefixValues)
        {
            int numberZeroCount = prefixValues.Where(x => x == 0).Count();
            int numberOneCount = prefixValues.Where(x => x == 1).Count();
            if (numberZeroCount > numberOneCount)
                return true;
            return false;
        }
    }
}
