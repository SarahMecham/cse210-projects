using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var reference = new Reference("John", 3, 16);
        string text = "For God so loved the world, that he gave his only begotten Son,that whosoever believeth in him should not perish, but have everlasting life.";

        var scripture = new Scripture(reference, text);

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Press enter to hide 5 words. Type 'q' and enter to quit.");
        Console.WriteLine();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Great job!");
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Hide 5 words? (Enter to continue, q to quit): ");
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Trim().ToLower() == "q") break;

            scripture.HideRandomWords(5);
        }
    }
}