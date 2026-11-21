using System;
public class Entry
{
    private const string Separator = "~|~";
    private string _date;
    private string _prompt;
    private string _response;
    private int _mood;

    public Entry(string date, string prompt, string response, int mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} (Mood: {_mood} /10)");
        Console.WriteLine($"Prompt:  ");
        Console.WriteLine($"Response  ");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return string.Join(Separator, _date, _prompt, _response, _mood);
    }

    public static Entry FromFileString(string Line)

    {
        string[] parts = Line.Split(Separator);

        //Default mood to 0 if loading an older entry missing the mood field.
        int mood = 0;
        if (parts.Length > 3)
        {
            int.TryParse(parts[3], out mood);
        }

        return new Entry(parts[0], parts[1], parts[2], mood);
    }

}