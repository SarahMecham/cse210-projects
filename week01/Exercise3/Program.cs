using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number? 6");

        int magicNumber = 6;
        int guess = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string userInput = Console.ReadLine();
            guess = int.Parse(userInput);

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}