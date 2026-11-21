using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"Saved entries to.");
    }
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("That file was not found.");
            return;
        }

        //Loading replaces any existing entries currently in the memory.
        _entries.Clear();

        foreach (string line in File.ReadAllLines(filename))
        {
            if (line.Trim() != "")
            {
                _entries.Add(Entry.FromFileString(line));
            }
        }
        Console.WriteLine($"Loaded entries from. ");

    }
}