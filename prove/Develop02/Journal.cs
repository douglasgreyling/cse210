using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        // Configure JsonSerializer to include public fields
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true // This enables field serialization
        };

        // Serialize the entries to JSON
        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(file, json);
        Console.WriteLine("Entries saved to file successfully!\n");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true // This enables field deserialization
            };

            string json = File.ReadAllText(file);
            _entries = JsonSerializer.Deserialize<List<Entry>>(json, options) ?? new List<Entry>();
            Console.WriteLine("Entries loaded from file successfully!\n");
        }
        else
        {
            Console.WriteLine("File not found.\n");
        }
    }
}
