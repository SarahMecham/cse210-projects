using System;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        string json = File.ReadAllText("scriptures.json");
        List<ScriptureData> scriptures = JsonSerializer.Deserialize<List<ScriptureData>>(json);

        for (int i = 0; i < scriptures.Count; i++)
        {
            var s = scriptures[i];
            Console.WriteLine($"{i + 1}. {s.book} {s.chapter}: {s.verse}" +
                (s.endVerse.HasValue ? $"-{s.endVerse}" : ""));
        }

        Console.Write("Enter the number of the scripture you want: ");
        int choice = int.Parse(Console.ReadLine() ?? "1");

        var selected = scriptures[choice - 1];

        Reference reference;

        if (selected.endVerse.HasValue)
            reference = new Reference(selected.book, selected.chapter, selected.verse, selected.endVerse.Value);
        else
            reference = new Reference(selected.book, selected.chapter, selected.verse);

        var scripture = new Scripture(reference, selected.text);

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