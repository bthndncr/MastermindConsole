using System;
using System.Linq;

namespace MastermindConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] target = generateNumber(4);  // generates random 4 digits number

            int attempts = 0;
            while (true)
            {
                Console.Write("=> ");
                string userInput = Console.ReadLine();
                if (userInput.Length != 4)
                {
                    Console.WriteLine("Please enter 4 digit number!");
                    continue;
                }

                attempts++;  // increment after each successfull attempt

                int[] userNumber = userInput.Select(v => v - '0').ToArray();
                string[] check = new string[4];
                int positionCorrect = 0;
                for (int i = 0; i < 4; i++)
                {
                    // if target includes the the digit, put - sign
                    if (target.Contains(userNumber[i]))
                    {
                        check[i] = "-";
                    }
                    else
                    {
                        check[i] = " ";
                    }

                    // if guested digit is correct and on the correct position, put + sign
                    if (target[i] == userNumber[i])
                    {
                        check[i] = "+";
                        positionCorrect++;
                    }
                }

                Console.WriteLine("=> " + string.Join("", check));
                if (positionCorrect == 4)
                {
                    Console.WriteLine("All correct! Attempts: " + attempts);
                    break;
                }
                if (attempts == 10)
                {
                    Console.WriteLine("Attempted: " + attempts + " times! Please restart the program...");
                    break;
                }

            }
        }


        public static int[] generateNumber(int size)
        {
            Console.WriteLine("Enter a four digit number, e.g. 1234");
            Random random = new Random();
            int[] target = new int[size];

            for (int i = 0; i < 4; i++)
            {
                target[i] = random.Next(1, 6);  // each digit is between 1 and 6
            }
            return target;

        }
    }
}
