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
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("--------------------------------------------------------");
    }

    public string ToFileFormat()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }
}