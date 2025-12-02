//I added a method to the reflecting activity that prevents a question from being repeated before all questions have been used during a session.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");


            int choice = GetUserChoice();

            if (choice == 4)
            {
                Console.WriteLine("Goodbye!");
                running = false;
                break;
            }

            Console.WriteLine("How long, in seconds, would you like for your session? ");
            int duration = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    new BreathingActivity(duration).Run();
                    break;

                case 2:
                    new ReflectingActivity(duration).Run();
                    break;

                case 3:
                    new ListingActivity(duration).Run();
                    break;
            } 
        }

        static int GetUserChoice()
        {
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();

            int choice;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter  a number 1-4: ");
                input = Console.ReadLine();
            }

            return choice;
        }
    }
}