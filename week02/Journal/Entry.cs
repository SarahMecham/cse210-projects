using System;
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry()
    {
        //Assign today's date.
        _date = DateTime.Now.ToShortDateString();

        //Generate a prompt.
        PromptGenerator promptGen = new PromptGenerator();
        _promptText = promptGen.GetRandomPrompt();

        //Get user entry.
        Console.WriteLine(_promptText);
        _entryText = Console.ReadLine();
    }

    //Constructor for loading only.
    public Entry(string date, string prompt, string text)
    {
        _date = date;
        _promptText = prompt;
        _entryText = text;
    }

    //Display Entries.
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("--------------------------------------------------------");
    }

    //Store strings seperated by a comma for use in a .csv file that can be converted to a spreadsheet.
    public string ToFileFormat()
    {
        return $"\"{_date}\",\"{_promptText}\",\"{_entryText}\"";
    }
}