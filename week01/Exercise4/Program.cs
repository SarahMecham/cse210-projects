using System;
using System.Globalization;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int number;

        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int total = numbers.Sum();
        Console.WriteLine($"The sum is: {total}.");

        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}.");

        int largest = numbers.Max();
        Console.WriteLine($"The largest number is: {largest}.");
    }
}