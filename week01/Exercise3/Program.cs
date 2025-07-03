using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "yes";

        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 20);
            int guess = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

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
                    Console.Write("Do you want to play again? ");
                    response = Console.ReadLine();
                }
            }
        } while (response == "yes");
    }
}