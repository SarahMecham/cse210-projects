using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    
    public void DisplayAll()
    {
        foreach (Entry newEntry in _entries)
        {
            newEntry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file, append: true))
        {
            foreach (Entry newEntry in _entries)
            {
                writer.WriteLine(newEntry.ToFileFormat());
            }
        }
        _entries.Clear();
    }
    
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }
        _entries.Clear();
    
        foreach (string line in File.ReadLines(file))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry newEntry = new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2]
                };

                _entries.Add(newEntry);
            }
        } 
    }
}