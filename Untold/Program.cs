using System;

namespace Untold
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Untold!");

            string inputString = Console.ReadLine();
            inputString = inputString.ToUpper();
            if (inputString == "QUIT")
            {
                Console.WriteLine("Thank you for playing.");
            }
            else if (inputString == "LOOK")
            {
                Console.WriteLine("This is an open field west of a white house.");
            }
            else
            {
                Console.WriteLine("Unrecognized command.");
            }
        }
    }
}
