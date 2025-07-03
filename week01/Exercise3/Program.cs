using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number? 6");
        Console.Write("What is your guess? ");
        string userInput = Console.ReadLine();
        int guess = int.Parse(userInput);

        int magicNumber = 6;

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