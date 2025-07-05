using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        welcomeMessage();

        string UserName = getUserName();
        int number = getNumber();

        endMessage(UserName, number);

        static void welcomeMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string getUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int getNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();
            int favoriteNumber = int.Parse(input);
            int favNumSquare = favoriteNumber * favoriteNumber;
            return favNumSquare;
        }

        static void endMessage(string UserName, int number)
        {
            Console.WriteLine($"{UserName}, the square of your number is {number}.");
        }
    }
}