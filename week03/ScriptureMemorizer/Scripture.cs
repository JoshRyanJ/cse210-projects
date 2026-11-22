using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ');
        for (int i = 0; i < parts.Length; i++)
        {
            Word word = new Word(parts[i]);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = new List<Word>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleWords.Add(_words[i]);
            }
        }
        if (visibleWords.Count == 0)
        {
            return;
        }

        Random random = new Random();
        int count = numberToHide;
        if (count > visibleWords.Count)
        {
            count = visibleWords.Count;
        }

        for (int i = 0; i < count; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);

        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "_";

        for (int i = 0; i < _words.Count; i++)
        {
            displayText += _words[i].GetDisplayText();
            if (i < _words.Count - 1)
            {
                displayText += "_";
            }
        }

        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                return false;
            }
        }

        return true;

    }
}