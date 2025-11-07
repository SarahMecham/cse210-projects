using System.Collections.Generic;
using System.IO;
using System.Linq;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    //Create a new entry.
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    
    //Display all the entries in the file.
    public void DisplayAll()
    {
        foreach (Entry newEntry in _entries)
        {
            newEntry.Display();
        }
    }

    //Save the new entires to a file.
    public void SaveToFile(string file)
    {
        bool fileExists = File.Exists(file);

        using (StreamWriter writer = new StreamWriter(file, append: true))
        {
            //Writes a header if the file is new.
            if (!fileExists)
            {
                writer.WriteLine("Date,Prompt,Entry");
            }
            
            foreach (Entry newEntry in _entries)
            {
                writer.WriteLine(newEntry.ToFileFormat());
            }
        }
    }

    //Load a file.  
    public void LoadFromFile(string file)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(file);
    
        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split(',');
            
            Entry newEntry = new Entry(
                parts[0].Trim('"'),
                parts[1].Trim('"'),
                parts[2].Trim('"')
            );

            _entries.Add(newEntry);
        } 
    }
}