using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What was your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        int onesPlace = grade % 10;

        string letter = "";
        string plusMinus = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade < 90 && grade >= 80)
        {
            letter = "B";
        }
        else if (grade < 80 && grade >= 70)
        {
            letter = "C";
        }
        else if (grade < 70 && grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (onesPlace >= 7)
        {
            plusMinus = "+";
        }
        else if (onesPlace < 3)
        {
            plusMinus = "-";
        }
        else
        {
            plusMinus = "";
        }

        Console.WriteLine($"Your letter grade is {letter}{plusMinus}.");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the class!");
        }
        else
        {
            Console.WriteLine("Keep trying. You'll get it next time!");
        }
    }
}