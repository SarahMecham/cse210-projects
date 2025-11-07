//To add creativity, I made the program ready to save to a .csv file for tranfer to an Excel sheet.
//I also added a header if the file is a new file.
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    Entry journalEntry = new Entry();
                    journal.AddEntry(journalEntry);
                    break;

                case 2:
                    journal.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter the file name: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Entry saved!");
                    break;

                case 4:
                    Console.Write("Enter the file name: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("File Loaded!");
                    break;

                case 5:
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }
    }

    static int GetUserChoice()
    {
        Console.Write("What would you like to do? ");
        string input = Console.ReadLine();

        int choice;
        while (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
        {
            Console.WriteLine("Invalid input. Please enter  a number 1-5: ");
            input = Console.ReadLine();
        }

        return choice;
    }
}
